using UnityEngine;
/*
public class Fruit : FizzyDrinkIngredients {
    [Header("Ingredient Types")]
    public bool hasLime;
    public bool hasLemon;


    void Start() { SetMemberVariables(Drinks.Priorities.Third); }

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

    public bool SetState(FruitType type) {
        switch (type) {
            case FruitType.Lime: hasLime = true; break;
            case FruitType.Lemon: hasLemon = true; break;
            case FruitType.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public FruitType GetState() {
        if (hasLemon) return FruitType.Lemon;
        else if (hasLime) return FruitType.Lime;
        return FruitType.Null;
    }

    public bool HasState() { return GetState() != FruitType.Null; }

}
*/
