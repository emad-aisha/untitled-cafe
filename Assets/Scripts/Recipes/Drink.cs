using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Ingredients = System.Collections.Generic.Dictionary<string, bool>;

public class Drink : MonoBehaviour {
    [SerializeReference] public IngredientsData ingredientData; // for initialization
    public List<ListWrapper> internalData; // for initialization
    public int type = -1; // for initialization (-1 = All)

    public Dictionary<string, Ingredients> ingredients; // able to use numbers or name
    // TODO: make anotheer dictionary, so i can use ints to loop thru things instead of, element at
    // or a string/int struct and a .at to use either or
    // TODO: make a bool for drinks where order matters

    void Start() {
        InitializeDictionary();
    }

    // TODO: cleanup?
    virtual public void Interact(Drink otherDrink, ref int priority) { }

    // set ingredients
    virtual protected bool SetIngredientByPriority(Drink otherDrink, ref int priority) {
        if (IsOutOfBounds(priority)) return false;
        if (IsTypeActive(priority)) return false;
        // TODO: add another check here so I dont have to keep overriding

        ingredients[priority.ToString()] = new(otherDrink.ingredients[priority.ToString()]);
        priority++;
        return true;
    }

    virtual protected bool SetIngredient(Drink otherDrink, string prefferedType = "null", bool allowMultipleIngredients = false) {
        int index = otherDrink.GetActiveType();
        if (IsOutOfBounds(index)) return false;
        if (prefferedType != "null" && !otherDrink.IsTypeActive(prefferedType)) return false; // check if active ingredient is prefferedType

        if (allowMultipleIngredients) {
            string key = GetActiveIngredient(otherDrink.ingredients[index.ToString()]);
            ingredients[index.ToString()][key] = otherDrink.ingredients[index.ToString()][key];
        }
        else {
            ingredients[index.ToString()] = new(otherDrink.ingredients[index.ToString()]);
        }
        return true;
    }


    // checks
    public bool IsOutOfBounds(int ingredientType) {
        if (ingredientType >= internalData.Count) { Debug.Log("priority out of bounds"); return true; }
        if (ingredientType < 0) { Debug.Log("priority out of bounds"); return true; }
        return false;
    }


    // is active
    public bool IsActive() {
        KeyValuePair<string, bool> entry = new();

        for (int type = 0; type < internalData.Count; type++) {
            for (int i = 0; i < ingredients[type.ToString()].Count; i++) {
                entry = ingredients[type.ToString()].ElementAt(i);
                if (entry.Value) return true;
            }
        }
        return false;
    }

    public bool IsTypeActive(int ingredientType) {
        KeyValuePair<string, bool> entry = new();
        for (int i = 0; i < ingredients[ingredientType.ToString()].Count; i++) {
            entry = ingredients[ingredientType.ToString()].ElementAt(i);
            if (entry.Value) return true;
        }
        return false;
    }
    public bool IsTypeActive(string ingredientType) {
        KeyValuePair<string, bool> entry = new();
        for (int i = 0; i < ingredients[ingredientType].Count; i++) {
            entry = ingredients[ingredientType].ElementAt(i);
            if (entry.Value) return true;
        }
        return false;
    }


    // get active
    public int GetActiveType() {
        KeyValuePair<string, bool> entry = new();

        for (int type = 0; type < internalData.Count; type++) {
            for (int i = 0; i < ingredients[type.ToString()].Count; i++) {
                entry = ingredients[type.ToString()].ElementAt(i);
                if (entry.Value) return type;
            }
        }

        return -1;
    }

    public string GetActiveIngredient(Ingredients ingredients) {
        for (int i = 0; i < ingredients.Count; i++) {
            KeyValuePair<string, bool> entry = ingredients.ElementAt(i);
            if (entry.Value) return entry.Key;
        }

        return "null";
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
    protected void PrintActiveIngredients() {
        KeyValuePair<string, bool> entry = new();

        for (int type = 0; type < internalData.Count; type++) {
            for (int i = 0; i < ingredients[type.ToString()].Count; i++) {
                entry = ingredients[type.ToString()].ElementAt(i);
                if (!entry.Value) continue;

                Debug.Log(ingredientData.Type.ToString() + ": " + entry.Key + " is " + entry.Value);
            }
        }
    }
}
