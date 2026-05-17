using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

using static FizzyDrink.Ingredient;

[CustomEditor(typeof(FizzyDrink)), CanEditMultipleObjects]
public class FizzyDrinkEditor : Editor {

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("ingredientData"));
        EditorGUILayout.Space();

        var fizzyDrink = (FizzyDrink)target;
        if (fizzyDrink.ingredients == null) fizzyDrink.Initialize();

        fizzyDrink.type = (FizzyDrink.Ingredient)EditorGUILayout.EnumPopup(fizzyDrink.type);

        // TODO: fix
        switch (fizzyDrink.type) {
            case None: Show.All(ref fizzyDrink, false); break;
            case All: Show.All(ref fizzyDrink, true); break;
            case Soda: Show.ShowValues(ref fizzyDrink, Soda); break;
            case Syrup: Show.ShowValues(ref fizzyDrink, Syrup); break;
            case Fruit: Show.ShowValues(ref fizzyDrink, Fruit); break;
        }

        serializedObject.ApplyModifiedProperties();
    }

}

static class Show {
    public static void All(ref FizzyDrink drink, bool value) {
        if (value == false) return;

        EditorGUILayout.LabelField("Soda", EditorStyles.boldLabel);
        ShowValues(ref drink, Soda);
        EditorGUILayout.LabelField("Syrup", EditorStyles.boldLabel);
        ShowValues(ref drink, Syrup);
        EditorGUILayout.LabelField("Fruit", EditorStyles.boldLabel);
        ShowValues(ref drink, Fruit);
    }

    public static void ShowValues(ref FizzyDrink drink, FizzyDrink.Ingredient section) {
        for (int index = 0; index < drink.internalData[(int)section].data.Count; index++) {
            KeyValuePair<string, bool> entry = drink.ingredients[section.ToString()].ElementAt(index);

            drink.internalData[(int)section].data[index] = EditorGUILayout.Toggle("\t" + entry.Key, drink.internalData[(int)section].data[index]);
        }
    }

}
