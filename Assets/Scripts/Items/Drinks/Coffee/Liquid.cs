using UnityEngine;

public class Liquid : CoffeeIngredients {
    public enum Type { Null, Water, Milk };
    [Header("Ingredient Types")]
    public bool hasWater;
    public bool hasMilk;


    void Start() { SetAll(Coffee.Priorities.second, false); }

    public bool Set(ref Liquid input, ref int priority) {
        if (input == null) return false;
        if (!input.CanGetItem()) return false;

        if (!input.SetOne(GetTrue())) return false;
        MenuManager.instance.SetInteractionType(GetTrue().ToString());
        if (!canHaveMultiple) priority++;
        return true;
    }

    override public void SetAllOff() { hasWater = hasMilk = false; }
    override public bool IsAllOff() { return (hasWater && hasMilk) == false; }

    public bool SetOne(Type type) {
        switch (type) {
            case Type.Water: hasWater = true; break;
            case Type.Milk: hasMilk = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public Type GetTrue() {
        if (hasWater) return Type.Water;
        else if (hasMilk) return Type.Milk;
        return Type.Null;
    }
}
