using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Drink), true)]
public class DrinkEditor : Editor {
    enum Case { All = -1, None = -2 }

    void OnEnable() {
        var drink = (Drink)target;

        if (drink.internalData == null) drink.InitializeInternalData();
        if (drink.ingredients == null) drink.InitializeDictionary();
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        var drink = (Drink)target;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ingredientData"));
        EditorGUILayout.Space();

        if (drink.ingredientData == null) {
            serializedObject.ApplyModifiedProperties();

            // if set to real object, init
            if (drink.ingredientData != null) {
                drink.InitializeInternalData();
                drink.InitializeDictionary();
                serializedObject.ApplyModifiedProperties();
            }
            return;
        }


        SetValue<FizzyDrink.Ingredient>(ref drink.type, drink.ingredientData.Type, IngredientsData.IngredientType.FizzyDrink);
        SetValue<Coffee.Ingredient>(ref drink.type, drink.ingredientData.Type, IngredientsData.IngredientType.Coffee);

        switch (drink.type) {
            case (int)Case.All: Show.All(ref drink, true); break;
            case (int)Case.None: Show.All(ref drink, false); break;
            default: Show.ShowValues(ref drink, drink.type); break;
        }

        serializedObject.ApplyModifiedProperties();
    }


    void SetValue<IngredientType>(ref int value, IngredientsData.IngredientType drinkType, IngredientsData.IngredientType ingredientType)
    where IngredientType : System.Enum {
        if (drinkType == ingredientType) value = (int)(object)(IngredientType)EditorGUILayout.EnumPopup((IngredientType)(object)value);
    }

}
