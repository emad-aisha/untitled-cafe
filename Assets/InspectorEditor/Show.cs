using UnityEngine;
using UnityEditor;


static class Show {
    public static void All(ref Drink drink, bool value) {
        if (value == false) return;

        for (int i = 0; i < drink.internalData.Count; i++) {
            EditorGUILayout.LabelField(drink.ingredients.At(i), EditorStyles.boldLabel);
            ShowValues(ref drink, i);
        }
    }

    public static void ShowValues(ref Drink drink, int section) {
        for (int index = 0; index < drink.internalData[section].data.Count; index++) {
            string name = drink.ingredients[section].At(index);

            drink.internalData[section].data[index] = EditorGUILayout.Toggle("\t" + name, drink.internalData[section].data[index]);
        }
    }


    public static void ShowDictionaryAll(Drink drink, bool value) {
        if (value == false) return;

        for (int i = 0; i < drink.ingredients.Count; i++) {
            string name = drink.ingredients.At(i);
            EditorGUILayout.LabelField(name, EditorStyles.boldLabel);
            ShowDictionaryValues(drink, i);
        }
    }

    public static void ShowDictionaryValues(Drink drink, int section) {
        for (int index = 0; index < drink.ingredients[section].Count; index++) {
            string name = drink.ingredients[section].At(index);
            bool value = drink.ingredients[section][index];

            EditorGUILayout.Toggle("\t" + name, value);
        }
    }

    public static void ShowDictionary(Drink drink) {
        for (int i = 0; i < drink.ingredients.Count; i++) {
            string typeName = drink.ingredients.At(i);
            EditorGUILayout.LabelField(typeName, EditorStyles.boldLabel);

            for (int j = 0; j < drink.ingredients[i].Count; j++) {
                string name = drink.ingredients[i].At(j);
                bool value = drink.ingredients[i][j];

                EditorGUILayout.Toggle("\t" + name, value); // each ingredient
            }
        }
    }

}
