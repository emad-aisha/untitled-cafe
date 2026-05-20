using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Ingredient = System.Collections.Generic.Dictionary<string, bool>;

public class Drink : MonoBehaviour {
    [SerializeReference] public IngredientsData ingredientData; // for initialization
    public List<ListWrapper> internalData; // for initialization
    public int type = -1; // for initialization (-1 = All)

    //public Dictionary<string, Ingredient> ingredients; // able to use numbers or name
    public IngredientsManager ingredients;

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

        ingredients[priority] = otherDrink.ingredients[priority];
        priority++;
        return true;
    }

    virtual protected bool SetIngredient(Drink otherDrink, string prefferedType = "null", bool allowMultipleIngredients = false) {
        int index = otherDrink.GetActiveType();
        if (IsOutOfBounds(index)) return false;
        if (prefferedType != "null" && !otherDrink.IsTypeActive(prefferedType)) return false; // check if active ingredient is prefferedType

        if (allowMultipleIngredients) {
            string key = GetActiveIngredient(otherDrink.ingredients[index]);
            ingredients[index][key] = otherDrink.ingredients[index][key];
        }
        else {
            ingredients[index] = otherDrink.ingredients[index];
        }
        return true;
    }

    public bool IsFull(string key) {
        bool result = true;

        bool value = false;
        for (int i = 0; i < ingredients[key].Count; i++) {
            value = ingredients[key][i];
            if (!value) result = false;
        }

        return result;
    }

    public bool Has(string name) { return IsTypeActive(name); }
    public bool HasNo(string name) { return !IsTypeActive(name); }

    // checks
    public bool IsOutOfBounds(int ingredientType) {
        if (ingredientType >= internalData.Count) { Debug.Log("priority out of bounds"); return true; }
        if (ingredientType < 0) { Debug.Log("priority out of bounds"); return true; }
        return false;
    }


    // is active
    public bool IsActive() {
        bool value = false;

        for (int type = 0; type < internalData.Count; type++) {
            for (int i = 0; i < ingredients[type].Count; i++) {
                value = ingredients[type][i];
                if (value) return true;
            }
        }
        return false;
    }

    public bool IsTypeActive(int ingredientType) {
        bool value = false;
        for (int i = 0; i < ingredients[ingredientType].Count; i++) {
            value = ingredients[ingredientType][i];
            if (value) return true;
        }

        return false;
    }
    public bool IsTypeActive(string ingredientType) {
        bool value = false;
        for (int i = 0; i < ingredients[ingredientType].Count; i++) {
            value = ingredients[ingredientType][i];
            if (value) return true;
        }

        return false;
    }


    // get active
    public int GetActiveType() {
        bool value = false;
        for (int type = 0; type < internalData.Count; type++) {
            for (int i = 0; i < ingredients[type].Count; i++) {
                value = ingredients[type][i];

                if (value) return type;
            }
        }

        return -1;
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
