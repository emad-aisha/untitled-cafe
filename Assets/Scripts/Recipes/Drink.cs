using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Ingredients = System.Collections.Generic.Dictionary<string, bool>;

public class Drink : MonoBehaviour {
    public IngredientsData ingredientData; // for initialization
    public List<ListWrapper> internalData; // for initialization
    public int type = -1; // for initialization (-1 = All)

    public Dictionary<string, Ingredients> ingredients; // able to use numbers or name

    void Start() {
        InitializeDictionary();
    }

    // init
    public void InitializeInternalData() {
        if (ingredientData == null) return;
        internalData = new();

        for (int typeIndex = 0; typeIndex < ingredientData.Data.Count; typeIndex++) {
            ListWrapper data = new();

            for (int index = 0; index < ingredientData.Data[typeIndex].ingredients.Count; index++) {
                data.data.Add(false);
            }
            internalData.Add(data);
        }
    }

    public void InitializeDictionary() {
        if (internalData == null) return;
        ingredients = new();

        for (int typeIndex = 0; typeIndex < internalData.Count; typeIndex++) {
            string typeName = ingredientData.Data[typeIndex].name;
            string typePriority = typeIndex.ToString();

            Ingredients entries = new();
            for (int index = 0; index < internalData[typeIndex].data.Count; index++) {
                string name = ingredientData.Data[typeIndex].ingredients[index].name;
                entries.Add(name, internalData[typeIndex].data[index]);
            }

            ingredients.Add(typeName, entries);
            ingredients.Add(typePriority, entries);
        }
    }


    // misc
    // print
    void PrintActiveIngredients() {
        KeyValuePair<string, bool> entry = new();

        for (int a = 0; a < internalData.Count; a++) {
            for (int i = 0; i < ingredients[a.ToString()].Count; i++) {
                entry = ingredients[a.ToString()].ElementAt(i);
                if (!entry.Value) continue;

                Debug.Log(ingredientData.Type.ToString() + ": " + entry.Key + " is " + entry.Value);
            }
        }
    }
}
