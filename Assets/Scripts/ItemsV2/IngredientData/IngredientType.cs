using UnityEngine;
// TODO: organize

// syrup, fruit, etc
public enum Priority { First = 0, Second = 1, Third = 2 };

public class IngredientType {
    public int priority;
    public string name;
    public Ingredient[] ingredients;

    public IngredientType(string _name = "null", int _priority = -1) {
        name = _name;
        priority = _priority;
    }
}
