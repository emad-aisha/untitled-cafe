using UnityEngine;

// syrup, fruit, etc
public enum Priority { First = 0, Second = 1, Third = 2 };

public class Data {
    public int priority;
    public string name;
    public Ingredient[] type;

    public Data(string _name = "null", int _priority = -1) {
        name = _name;
        priority = _priority;
    }
}
