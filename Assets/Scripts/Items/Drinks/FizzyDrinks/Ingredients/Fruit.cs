using static FizzyDrinks.Priorities;
using UnityEngine;

public class Fruit : FizzyDrinkIngredients {
    public enum Type { Null, Lime, Lemon, Strawberry };
    [Header("Ingredient Types")]
    public bool hasLime;
    public bool hasLemon;
    public bool hasStrawberry;


    void Start() { SetAll(third, true); }

    public bool Set(ref Fruit input, ref int priority) {
        if (input == null) return false;
        if (!input.CanGetItem()) return false;

        MenuManager.instance.SetInteractionType(GetTrue().ToString());
        input.SetOne(GetTrue());
        if (!canHaveMultiple) priority++;
        return true;
    }

    override public void SetAllOff() { hasLemon = hasStrawberry = hasLime = false; }
    override public bool IsAllOff() { return (hasLemon && hasStrawberry && hasLime) == false; }

    public void SetOne(Type type) {
        switch (type) {
            case Type.Lime: hasLime = true; break;
            case Type.Lemon: hasLemon = true; break;
            case Type.Strawberry: hasStrawberry = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); break;
        }
    }
    public Type GetTrue() {
        if (hasLemon) return Type.Lemon;
        else if (hasLime) return Type.Lime;
        else if (hasStrawberry) return Type.Strawberry;
        return Type.Null;
    }
}
