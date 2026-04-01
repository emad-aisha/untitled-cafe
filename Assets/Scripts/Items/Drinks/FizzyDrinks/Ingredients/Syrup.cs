using static FizzyDrinks.Priorities;
using UnityEngine;

public class Syrup : FizzyDrinkIngredients {
    public enum Type { Null, Lemon, Orange, Strawberry };
    [Header("Ingredient Types")]
    public bool hasLemon;
    public bool hasOrange;
    public bool hasStrawberry;


    void Start() {
        SetAll(second);
        bools.Add(hasLemon);
        bools.Add(hasOrange);
        bools.Add(hasStrawberry);
    }

    public bool Set(ref Syrup input, ref int priority) {
        if (input == null) return false;
        if (!input.CanGetItem()) return false;

        if (!input.SetOne(GetTrue())) return false;
        MenuManager.instance.SetInteractionType(GetTrue().ToString() + " Syrup");
        if (!canHaveMultiple) priority++;
        return true;
    }

    public bool SetOne(Type type) {
        switch (type) {
            case Type.Lemon: hasLemon = true; break;
            case Type.Orange: hasOrange = true; break;
            case Type.Strawberry: hasStrawberry = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public Type GetTrue() {
        if (hasLemon) return Type.Lemon;
        else if (hasOrange) return Type.Orange;
        else if (hasStrawberry) return Type.Strawberry;
        return Type.Null;
    }

}
