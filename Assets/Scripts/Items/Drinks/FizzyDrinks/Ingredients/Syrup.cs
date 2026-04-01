using UnityEngine;

public class Syrup : FizzyDrinkIngredients {
    public enum Type { Null = -1, Lemon, Orange, Strawberry };
    [Header("Ingredient Types")]
    public bool hasLemon;
    public bool hasOrange;
    public bool hasStrawberry;


    void Start() { SetMemberVariables(Drinks.Priorities.second); }

    override public bool SetIngredient(ref FizzyDrink input, ref int priority) {
        if (!CanChangeVariables(input, IngredientType.Syrup)) return false;
        Syrup inputSyrup = input.GetSyrup();

        if (!inputSyrup.SetState(this.GetState())) return false;
        priority++;

        MenuManager.instance.SetInteractionType(GetState().ToString() + " Syrup");
        return true;
    }

    // getters / setters
    override public void PushBackBools() {
        bools.Add(hasLemon);
        bools.Add(hasOrange);
        bools.Add(hasStrawberry);
    }

    public bool SetState(Type type) {
        switch (type) {
            case Type.Lemon: hasLemon = true; break;
            case Type.Orange: hasOrange = true; break;
            case Type.Strawberry: hasStrawberry = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public Type GetState() {
        if (hasLemon) return Type.Lemon;
        else if (hasOrange) return Type.Orange;
        else if (hasStrawberry) return Type.Strawberry;
        return Type.Null;
    }

    public bool HasState() {
        return GetState() != Type.Null;
    }

}
