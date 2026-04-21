using UnityEngine;

// fizzy, coffee, etc
public class Container {
    public static int end = -1;

    public string name;
    public Data[] ingredient;

    public Container(string _name = "null") {
        end++;
        name = _name;
    }
}

// syrup, fruit, etc
public enum Priority { First = 1, Second = 2, Third = 3 };
public class Data {
    public int priority;
    public string name;
    public Ingredient[] type;

    public Data(string _name = "null", int _priority = -1) {
        name = _name;
        priority = _priority;
    }
}

// lemon, soda, water
public class Ingredient {
    public string name;
    public bool value;

    public Ingredient(string _name = "null", bool _value = false) {
        name = _name;
        value = _value;
    }
}
