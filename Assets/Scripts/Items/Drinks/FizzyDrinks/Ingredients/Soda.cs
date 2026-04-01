using UnityEngine;

public class Soda : FizzyDrinkIngredients {
    public enum Type { Null = -1, Soda };
    [Header("Ingredient Types")]
    public bool hasSoda;


    void Start() { SetMemberVariables(Drinks.Priorities.first); }

    override public bool SetIngredient(ref FizzyDrink input, ref int priority) {
        if (!CanChangeVariables(input, IngredientType.Soda)) return false;
        Soda inputSoda = input.GetSoda();

        if (!inputSoda.SetState(this.GetState())) return false;
        priority++;

        MenuManager.instance.SetInteractionType("Soda");
        return true;
    }

    // getters / setters
    override public void PushBackBools() {
        bools.Add(hasSoda);
    }

    public bool SetState(Type type) {
        switch (type) {
            case Type.Soda: hasSoda = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public Type GetState() {
        if (hasSoda) return Type.Soda;
        return Type.Null;
    }

    public bool HasState() {
        return GetState() != Type.Null;
    }

}
