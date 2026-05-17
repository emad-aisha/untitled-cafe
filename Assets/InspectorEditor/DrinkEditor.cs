using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

// TODO: organize and put into seperate files/folders
[CustomEditor(typeof(Drink), true)]
public class DrinkEditor : Editor {
    enum Case { All = -2, None = -1 }
    int value = (int)Case.All;

    void OnEnable() {
        var drink = (Drink)target;

        if (drink.internalData == null) drink.InitializeInternalData();
        if (drink.ingredients == null) drink.InitializeDictionary();
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        var drink = (Drink)target;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ingredientData"));

        SetValue<FizzyDrink.Ingredient>(drink.ingredientData.Type, IngredientsData.IngredientType.FizzyDrink);
        SetValue<Coffee.Ingredient>(drink.ingredientData.Type, IngredientsData.IngredientType.Coffee);

        switch (value) {
            case (int)Case.All: Show.All(ref drink, true); break;
            case (int)Case.None: Show.All(ref drink, false); break;
            default: Show.ShowValues(ref drink, value); break;
        }

        serializedObject.ApplyModifiedProperties();
    }

    void SetValue<IngredientType>(IngredientsData.IngredientType drinkType, IngredientsData.IngredientType ingredientType) where IngredientType : System.Enum {
        if (drinkType == ingredientType) value = (int)(object)(IngredientType)EditorGUILayout.EnumPopup((IngredientType)(object)value);
    }

}

static class Show {
    public static void All(ref Drink drink, bool value) {
        if (value == false) return;

        // for loop (use entry to get type name)
        for (int i = 0; i < drink.internalData.Count; i++) {
            KeyValuePair<string, Dictionary<string, bool>> entry = drink.ingredients.ElementAt(i * 2); // every even entry is a name

            EditorGUILayout.LabelField(entry.Key, EditorStyles.boldLabel);
            ShowValues(ref drink, i);
        }
    }

    public static void ShowValues(ref Drink drink, int section) {
        for (int index = 0; index < drink.internalData[section].data.Count; index++) {
            KeyValuePair<string, bool> entry = drink.ingredients[section.ToString()].ElementAt(index);

            drink.internalData[section].data[index] = EditorGUILayout.Toggle("\t" + entry.Key, drink.internalData[section].data[index]);
        }
    }

}
