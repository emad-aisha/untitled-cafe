using UnityEngine;

public class Fruit : FizzyDrinkIngredients {
    public enum Type { Null = -1, Lime, Lemon };
    [Header("Ingredient Types")]
    public bool hasLime;
    public bool hasLemon;


    void Start() { SetMemberVariables(Drinks.Priorities.third); }

    override public bool SetIngredient(ref FizzyDrink input, ref int priority) {
        if (!CanChangeVariables(input, IngredientType.Fruit)) return false;
        Fruit inputFruit = input.GetFruit();

        if (!inputFruit.SetState(this.GetState())) return false;
        priority++;

        MenuManager.instance.SetInteractionType(GetState().ToString());
        return true;
    }

    // getters / setters
    override public void PushBackBools() {
        bools.Add(hasLime);
        bools.Add(hasLemon);
    }

    public bool SetState(Type type) {
        switch (type) {
            case Type.Lime: hasLime = true; break;
            case Type.Lemon: hasLemon = true; break;
            case Type.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public Type GetState() {
        if (hasLemon) return Type.Lemon;
        else if (hasLime) return Type.Lime;
        return Type.Null;
    }

    public bool HasState() {
        return GetState() != Type.Null;
    }

}
