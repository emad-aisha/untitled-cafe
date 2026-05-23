using UnityEngine;
using UnityEditor;


static class Show {
    public static string Capitalized(string name) {
        return name.Substring(0, 1).ToUpper() + name.Substring(1);
    }

    public static void All(ref Drink drink, bool value) {
        if (value == false) return;

        for (int i = 0; i < drink.internalData.Count; i++) {
            EditorGUILayout.LabelField(Capitalized(drink.ingredients.At(i)), EditorStyles.boldLabel);
            ShowValues(ref drink, i);
        }
    }

    public static void ShowValues(ref Drink drink, int section) {
        for (int index = 0; index < drink.internalData[section].data.Count; index++) {
            string name = drink.ingredients[section].At(index);

            drink.internalData[section].data[index] = EditorGUILayout.Toggle("\t" + Capitalized(name), drink.internalData[section].data[index]);
        }
    }


    public static void ShowDictionaryAll(Drink drink, bool value) {
        if (value == false) return;

        for (int i = 0; i < drink.ingredients.Count; i++) {
            string name = drink.ingredients.At(i);
            EditorGUILayout.LabelField(Capitalized(name), EditorStyles.boldLabel);
            ShowDictionaryValues(drink, i);
        }
    }

    public static void ShowDictionaryValues(Drink drink, int section) {
        for (int index = 0; index < drink.ingredients[section].Count; index++) {
            string name = drink.ingredients[section].At(index);
            bool value = drink.ingredients[section][index];

            EditorGUILayout.Toggle("\t" + Capitalized(name), value);
        }
    }

    public static void ShowDictionary(Drink drink) {
        for (int i = 0; i < drink.ingredients.Count; i++) {
            string typeName = drink.ingredients.At(i);
            EditorGUILayout.LabelField(typeName, EditorStyles.boldLabel);

            for (int j = 0; j < drink.ingredients[i].Count; j++) {
                string name = drink.ingredients[i].At(j);
                bool value = drink.ingredients[i][j];

                EditorGUILayout.Toggle("\t" + Capitalized(name), value); // each ingredient
            }
        }
    }

}
