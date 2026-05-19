using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;

static class Show {
    public static void All(ref Drink drink, bool value) {
        if (value == false) return;

        // for loop (use entry to get type name)
        for (int i = 0; i < drink.internalData.Count; i++) {
            KeyValuePair<string, Dictionary<string, bool>> entry = drink.ingredients.ElementAt(i * 2);

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

    public static void ShowDictionaryAll(Drink drink, bool value) {
        if (value == false) return;

        // for loop (use entry to get type name)
        for (int i = 0; i < drink.ingredients.Count / 2; i++) {
            KeyValuePair<string, Dictionary<string, bool>> entry = drink.ingredients.ElementAt(i * 2);
            EditorGUILayout.LabelField(entry.Key, EditorStyles.boldLabel);

            ShowDictionaryValues(drink, i);
        }
    }

    public static void ShowDictionaryValues(Drink drink, int section) {
        for (int index = 0; index < drink.ingredients[section.ToString()].Count; index++) {
            KeyValuePair<string, bool> entry = drink.ingredients[section.ToString()].ElementAt(index);

            EditorGUILayout.Toggle("\t" + entry.Key, entry.Value);
        }
    }

    public static void ShowDictionary(Drink drink) {
        for (int i = 0; i < drink.ingredients.Count / 2; i++) {
            KeyValuePair<string, Dictionary<string, bool>> typeEntry = drink.ingredients.ElementAt(i * 2);
            EditorGUILayout.LabelField(typeEntry.Key, EditorStyles.boldLabel);

            for (int j = 0; j < drink.ingredients[i.ToString()].Count; j++) {
                KeyValuePair<string, bool> entry = drink.ingredients[i.ToString()].ElementAt(j); // each ingredient

                EditorGUILayout.Toggle("\t" + entry.Key, entry.Value);
            }
        }
    }

}
