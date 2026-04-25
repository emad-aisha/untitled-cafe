using UnityEngine;

// lemon, soda, water
public class Ingredient {
    public string name;
    public bool value;

    public Ingredient(string _name = "null", bool _value = false) {
        name = _name;
        value = _value;
    }
}
