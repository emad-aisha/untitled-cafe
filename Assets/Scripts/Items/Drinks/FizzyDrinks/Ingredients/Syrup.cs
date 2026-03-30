using static FizzyDrinks.Priorities;
using UnityEngine;

public class Syrup : FizzyDrinkIngredients {
    public enum Type { Null, Lemon, Orange, Strawberry };
    [Header("Ingredient Types")]
    public bool hasLemon;
    public bool hasOrange;
    public bool hasStrawberry;


    void Start() { SetAll(second, false); }

    public bool Set(ref Syrup input, ref int priority) {
        if (input == null) return false;
        if (!input.CanGetItem()) return false;

        MenuManager.instance.SetInteractionType(GetTrue().ToString() + " Syrup");
        input.SetOne(GetTrue());
        if (!canHaveMultiple) priority++;
        return true;
    }

    override public void SetAllOff() { hasLemon = hasOrange = hasStrawberry = false; }
    override public bool IsAllOff() { return (hasLemon && hasStrawberry && hasOrange) == false; }

    public void SetOne(Type type) {
        switch (type) {
            case Type.Lemon: hasLemon = true; break;
            case Type.Orange: hasOrange = true; break;
            case Type.Strawberry: hasStrawberry = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); break;
        }
    }
    public Type GetTrue() {
        if (hasLemon) return Type.Lemon;
        else if (hasOrange) return Type.Orange;
        else if (hasStrawberry) return Type.Strawberry;
        return Type.Null;
    }

}
