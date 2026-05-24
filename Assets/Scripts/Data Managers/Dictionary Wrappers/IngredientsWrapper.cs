using UnityEngine;
using System.Collections.Generic;

// example
// example[1] -> soda type
public class IngredientsWrapper {
    Dictionary<string, Ingredients> ingredients = new(); // has all the values
    Dictionary<int, string> ingredient_type_ids = new(); // indexer for types

    public int Count => ingredients.Count;

    // example["Soda"] -> soda type
    public Ingredients this[string key] {
        get {
            if (ingredients.ContainsKey(key.ToLower())) {
                return ingredients[key.ToLower()];
            }
            else {
                throw new System.Exception("Inputted Key does not Exist");
            }
        }
        set {
            if (ingredients.ContainsKey(key.ToLower())) {
                ingredients[key.ToLower()] = value;
            }
        }
    }

    // example[1] -> soda type
    public Ingredients this[int key] {
        get {
            if (ingredient_type_ids.ContainsKey(key)) {
                return ingredients[ingredient_type_ids[key]];
            }
            else {
                throw new System.Exception("Inputted Key does not Exist");
            }
        }
        set {
            if (ingredient_type_ids.ContainsKey(key)) {
                ingredients[ingredient_type_ids[key]] = value;
            }

        }
    }


    public string At(int key) { return ingredient_type_ids[key]; }

    public void Add(string key, Ingredients value) { ingredients.Add(key.ToLower(), value); }
    public void Add(int key, string value) { ingredient_type_ids.Add(key, value.ToLower()); }


    // is active
    public bool IsActive() {
        for (int type = 0; type < this[type].Count; type++) {
            for (int i = 0; i < this[type].Count; i++) {
                if (this[type][i]) return true;
            }
        }
        return false;
    }

    public bool IsAllActive(string key) {
        for (int i = 0; i < this[key].Count; i++) {
            if (!this[key][i]) return false;
        }

        return true;
    }
    public bool IsAllActive(int key) {
        for (int i = 0; i < this[key].Count; i++) {
            if (!this[key][i]) return false;
        }

        return true;
    }

    public bool IsTypeActive(int ingredientType) {
        for (int i = 0; i < this[ingredientType].Count; i++) {
            if (this[ingredientType][i]) return true;
        }

        return false;
    }
    public bool IsTypeActive(string ingredientType) {
        for (int i = 0; i < this[ingredientType].Count; i++) {
            if (this[ingredientType][i]) return true;
        }

        return false;
    }


    // get active
    public int GetActiveType() {
        for (int type = 0; type < Count; type++) {
            for (int i = 0; i < this[type].Count; i++) {
                if (this[type][i]) return type;
            }
        }

        return -1;
    }
    public string GetActiveTypeName() {
        for (int type = 0; type < Count; type++) {
            for (int i = 0; i < this[type].Count; i++) {
                if (this[type][i]) return this[type].At(i);
            }
        }

        return "";
    }

    public string GetActiveIngredient(Ingredients ingredients) {
        for (int i = 0; i < ingredients.Count; i++) {
            if (ingredients[i]) return ingredients.At(i);
        }
        return "";
    }

    public string[] GetActiveIngredients(Ingredients ingredients) {
        string[] strings = new string[ingredients.Count];

        for (int i = 0; i < ingredients.Count; i++) {
            strings[i] = "";
            if (ingredients[i]) strings[i] = ingredients.At(i);
        }
        return strings;
    }
}
