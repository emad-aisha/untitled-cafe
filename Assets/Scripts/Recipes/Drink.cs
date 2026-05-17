using UnityEngine;
using System.Collections.Generic;
using Ingredients = System.Collections.Generic.Dictionary<string, bool>;
using System.Linq;

public class Drink : MonoBehaviour {
    // children need a enum
    [SerializeField] public IngredientsData ingredientData;
    [SerializeField] public List<test> internalData;

    public Dictionary<string, Ingredients> ingredients; // use "0" and stuff

    void Start() {
        InitializeDictionary();

        KeyValuePair<string, bool> entry = ingredients["Soda"].ElementAt(0);
        Debug.Log(entry.Key + " " + entry.Value);

        for (int i = 0; i < 3; i++) {
            entry = ingredients["Syrup"].ElementAt(i);
            if (!entry.Value) continue;
            Debug.Log(entry.Key + " " + entry.Value);
        }

        for (int i = 0; i < 2; i++) {
            entry = ingredients["Fruit"].ElementAt(i);
            if (!entry.Value) continue;
            Debug.Log(entry.Key + " " + entry.Value);
        }
    }

    public void Initialize() {
        InitializeDictionary();
        InitializeInternalData();
    }

    // init
    void InitializeInternalData() {
        internalData = new();

        for (int typeIndex = 0; typeIndex < ingredientData.Data.Count; typeIndex++) {
            test data = new();

            for (int index = 0; index < ingredientData.Data[typeIndex].ingredients.Count; index++) {
                data.data.Add(false);
            }
            internalData.Add(data);
        }
    }

    void InitializeDictionary() {
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

}
