using UnityEngine;

public class Extras : CoffeeIngredients {
    public enum Type { Null, MilkFoam, Chocolate };
    [Header("Ingredient Types")]
    public bool hasMilkFoam;
    public bool hasChocolate;


    void Start() { SetAll(Coffee.Priorities.third, false); }

    public bool Set(ref Extras input, ref int priority) {
        if (input == null) return false;
        if (!input.CanGetItem()) return false;

        if (!input.SetOne(GetTrue())) return false;
        MenuManager.instance.SetInteractionType(GetTrue().ToString());
        if (!canHaveMultiple) priority++;
        return true;
    }

    override public void SetAllOff() { hasMilkFoam = hasChocolate = false; }
    override public bool IsAllOff() { return hasMilkFoam == false && hasChocolate == false; }

    public bool SetOne(Type type) {
        switch (type) {
            case Type.MilkFoam: hasMilkFoam = true; break;
            case Type.Chocolate: hasChocolate = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public Type GetTrue() {
        if (hasMilkFoam) return Type.MilkFoam;
        else if (hasChocolate) return Type.Chocolate;
        return Type.Null;
    }
}
