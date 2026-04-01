using UnityEngine;

public class Espresso : CoffeeIngredients {
    public enum Type { Null, Decaf, NonDecaf };
    [Header("Ingredient Types")]
    public bool hasDecaf;
    public bool hasEspresso;


    void Start() { SetAll(Coffee.Priorities.first, false); }

    public bool Set(ref Espresso input, ref int priority) {
        if (input == null) return false;
        if (!input.CanGetItem()) return false;

        if (!input.SetOne(GetTrue())) return false;
        MenuManager.instance.SetInteractionType(GetTrue().ToString());
        if (!canHaveMultiple) priority++;
        return true;
    }

    override public void SetAllOff() { hasDecaf = hasEspresso = false; }
    override public bool IsAllOff() { return hasDecaf == false && hasEspresso == false; }

    public bool SetOne(Type type) {
        switch (type) {
            case Type.Decaf: hasDecaf = true; break;
            case Type.NonDecaf: hasEspresso = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public Type GetTrue() {
        if (hasDecaf) return Type.Decaf;
        else if (hasEspresso) return Type.NonDecaf;
        return Type.Null;
    }
}
