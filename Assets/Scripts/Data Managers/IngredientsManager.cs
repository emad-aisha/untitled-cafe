using UnityEngine;
using System.Collections.Generic;
using Ingredient = System.Collections.Generic.Dictionary<string, bool>;

// example
// example[1] -> soda type
public class IngredientsManager {
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
}
