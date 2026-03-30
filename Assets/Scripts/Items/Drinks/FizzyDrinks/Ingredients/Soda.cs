using static FizzyDrinks.Priorities;
using UnityEngine;

public class Soda : FizzyDrinkIngredients {
    public enum Type { Null, Soda };
    [Header("Ingredient Types")]
    public bool hasSoda;


    void Start() { SetAll(first, false); }

    public bool Set(ref Soda input, ref int priority) {
        if (input == null) return false;
        if (!input.CanGetItem()) return false;

        input.SetOne(GetTrue());
        MenuManager.instance.SetInteractionType("Soda");
        if (!canHaveMultiple) priority++;
        return true;
    }

    override public void SetAllOff() { hasSoda = false; }
    override public bool IsAllOff() { return hasSoda == false; }

    public void SetOne(Type type) {
        switch (type) {
            case Type.Soda: hasSoda = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); break;
        }
    }
    public Type GetTrue() {
        if (hasSoda) return Type.Soda;
        return Type.Null;
    }
}
