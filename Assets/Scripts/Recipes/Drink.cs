using UnityEngine;
using System.Collections.Generic;
using Ingredients = System.Collections.Generic.Dictionary<string, bool>;
using System.Linq;

public class Drink : MonoBehaviour {
    public enum TYPE { FizzyDrink, Coffee }
    public TYPE ingType;

    // children need a enum
    [SerializeField] public IngredientsData ingredientData;
    [SerializeField] public List<ListWrapper> internalData;

    public Dictionary<string, Ingredients> ingredients; // use "0" and stuff

    void Start() {
        // TODO: fix lol
        InitializeDictionary();
        KeyValuePair<string, bool> entry = new();

        // should work for any type
        for (int a = 0; a < internalData.Count; a++) {
            for (int i = 0; i < ingredients[a.ToString()].Count; i++) {
                entry = ingredients[a.ToString()].ElementAt(i);
                if (!entry.Value) continue;
                Debug.Log(entry.Key + " " + entry.Value);
            }
        }
    }

    // init
    public void InitializeInternalData() {
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
