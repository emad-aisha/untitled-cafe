using static FizzyDrinks.Priorities;
using UnityEngine;

public class Fruit : FizzyDrinkIngredients {
    public enum Type { Null, Lime, Lemon };
    [Header("Ingredient Types")]
    public bool hasLime;
    public bool hasLemon;


    void Start() { SetAll(third, false); }

    public bool Set(ref Fruit input, ref int priority) {
        if (input == null) return false;
        if (!input.CanGetItem()) return false;

        if (!input.SetOne(GetTrue())) return false;
        MenuManager.instance.SetInteractionType(GetTrue().ToString());
        if (!canHaveMultiple) priority++;
        return true;
    }

    override public void SetAllOff() { hasLemon = hasLime = false; }
    override public bool IsAllOff() { return (hasLemon && hasLime) == false; }

    public bool SetOne(Type type) {
        switch (type) {
            case Type.Lime: hasLime = true; break;
            case Type.Lemon: hasLemon = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public Type GetTrue() {
        if (hasLemon) return Type.Lemon;
        else if (hasLime) return Type.Lime;
        return Type.Null;
    }
}
