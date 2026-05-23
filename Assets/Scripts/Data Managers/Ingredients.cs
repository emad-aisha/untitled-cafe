using UnityEngine;
using System.Collections.Generic;


public class Ingredients {
    Dictionary<string, bool> ingredients = new();
    Dictionary<int, string> ingredient_ids = new();

    public int Count => ingredients.Count;

    // ingredients["Strawberry"] -> value
    public bool this[string key] {
        get {
            if (ingredients.ContainsKey(key.ToLower())) {
                return ingredients[key.ToLower()];
            }
            else {
                throw new System.Exception("Inputted Key does not Exist");
            }
        }
        set {
            ingredients[key.ToLower()] = value;
        }
    }

    // ingredients[1] -> value
    public bool this[int key] {
        get {
            if (ingredient_ids.ContainsKey(key)) {
                return ingredients[ingredient_ids[key]];
            }
            else {
                throw new System.Exception("Inputted Key does not Exist");
            }
        }
        set {
            ingredients[ingredient_ids[key]] = value;
        }
    }

    // ingredients.At(1) -> key
    public string At(int key) { return ingredient_ids[key]; }

    public void Add(string key, bool value) { ingredients.Add(key.ToLower(), value); }
    public void Add(int key, string value) { ingredient_ids.Add(key, value.ToLower()); }

}
