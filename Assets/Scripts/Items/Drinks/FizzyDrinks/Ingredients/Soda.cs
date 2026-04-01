using static FizzyDrinks.Priorities;
using UnityEngine;

public class Soda : FizzyDrinkIngredients {
    public enum Type { Null, Soda };
    [Header("Ingredient Types")]
    public bool hasSoda;


    void Start() {
        SetAll(first);
        bools.Add(hasSoda);
    }

    public bool Set(ref Soda input, ref int priority) {
        if (input == null) return false;
        if (!input.CanGetItem()) return false;

        if (!input.SetOne(GetTrue())) return false;
        MenuManager.instance.SetInteractionType("Soda");
        if (!canHaveMultiple) priority++;
        return true;
    }

    public bool SetOne(Type type) {
        switch (type) {
            case Type.Soda: hasSoda = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public Type GetTrue() {
        if (hasSoda) return Type.Soda;
        return Type.Null;
    }
}
