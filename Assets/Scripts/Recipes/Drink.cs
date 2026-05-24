using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
struct InteractData {
    public string originalIngredient;
    public string[] neededIngredients;

    public bool canHaveMultiple;
}

public class Drink : MonoBehaviour {
    // initialization
    [SerializeReference] public IngredientsData ingredientData;
    public List<ListWrapper> internalData;
    public int type = -1;
    public bool hideInternalData; // for inspector

    public IngredientsManager ingredients;
    protected bool finishedDrink = false;

    [SerializeField] InteractData[] interactData;

    void Start() {
        InitializeDictionary();
    }

    // TODO: cleanup?
    virtual public void Interact(Drink otherDrink, ref int priority) {
        // TODO: see if I can clean up
        if (otherDrink.GetActiveType() == -1) return;
        InteractData data = interactData[otherDrink.GetActiveType()];

        if (data.canHaveMultiple) {
            if (Has(data.neededIngredients)) SetIngredient(otherDrink, data.originalIngredient, data.canHaveMultiple);
        }
        else {
            if (Has(data.neededIngredients) && HasNot(data.originalIngredient)) SetIngredient(otherDrink, data.originalIngredient);
        }


    }

    // TODO: hard to read
    virtual protected bool SetIngredient(Drink otherDrink, string prefferedType = "", bool allowMultipleIngredients = false) {
        int index = otherDrink.GetActiveType();
        if (IsOutOfBounds(index)) return false;

        // check if active ingredient is prefferedType
        if (prefferedType != "" && !otherDrink.IsTypeActive(prefferedType)) return false;


        if (allowMultipleIngredients) {
            string key = GetActiveIngredient(otherDrink.ingredients[index]);
            ingredients[index][key] = otherDrink.ingredients[index][key];
            Debug.Log(key);
        }
        else {
            if (IsTypeActive(index)) return false;
            ingredients[index] = otherDrink.ingredients[index];
            Debug.Log(ingredients.At(index));
        }
        return true;
    }


    public bool Has(params string[] name) {
        for (int i = 0; i < name.Length; i++) {
            if (!IsTypeActive(name[i])) return false;
        }
        return true;
    }
    public bool HasNot(params string[] name) {
        for (int i = 0; i < name.Length; i++) {
            if (IsTypeActive(name[i])) return false;
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
        for (int type = 0; type < internalData.Count; type++) {
            for (int i = 0; i < ingredients[type].Count; i++) {
                if (ingredients[type][i]) return true;
            }
        }
        return false;
    }

    public bool IsAllActive(string key) {
        for (int i = 0; i < ingredients[key].Count; i++) {
            if (!ingredients[key][i]) return false;
        }

        return true;
    }
    public bool IsAllActive(int key) {
        for (int i = 0; i < ingredients[key].Count; i++) {
            if (!ingredients[key][i]) return false;
        }

        return true;
    }

    public bool IsTypeActive(int ingredientType) {
        for (int i = 0; i < ingredients[ingredientType].Count; i++) {
            if (ingredients[ingredientType][i]) return true;
        }

        return false;
    }
    public bool IsTypeActive(string ingredientType) {
        for (int i = 0; i < ingredients[ingredientType].Count; i++) {
            if (ingredients[ingredientType][i]) return true;
        }

        return false;
    }


    // get active
    public int GetActiveType() {
        for (int type = 0; type < internalData.Count; type++) {
            for (int i = 0; i < ingredients[type].Count; i++) {
                if (ingredients[type][i]) return type;
            }
        }

        return -1;
    }
    public string GetActiveTypeName() {
        for (int type = 0; type < internalData.Count; type++) {
            for (int i = 0; i < ingredients[type].Count; i++) {
                if (ingredients[type][i]) return ingredients[type].At(i);
            }
        }

        return "";
    }

    public string GetActiveIngredient(Ingredients ingredients) {
        for (int i = 0; i < ingredients.Count; i++) {
            if (ingredients[i]) return ingredients.At(i);
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

        for (int typeId = 0; typeId < internalData.Count; typeId++) {
            string name = ingredientData.Data[typeId].name;

            Ingredients ingredient = new();
            for (int ingredientId = 0; ingredientId < internalData[typeId].data.Count; ingredientId++) {
                string ingredientName = ingredientData.Data[typeId].ingredients[ingredientId].name;
                bool value = internalData[typeId].data[ingredientId];

                ingredient.Add(ingredientName, value);
                ingredient.Add(ingredientId, ingredientName);
            }

            ingredients.Add(typeId, name);
            ingredients.Add(name, ingredient);
        }

    }

    // misc
    protected void PrintActiveIngredients() {
        string name = "";
        bool value = false;
        for (int type = 0; type < internalData.Count; type++) {
            for (int i = 0; i < ingredients[type].Count; i++) {
                name = ingredients[type].At(i);
                value = ingredients[type][i];
                if (!value) continue;

                Debug.Log(ingredientData.Type.ToString() + ": " + name + " is " + value);
            }
        }
    }
}
