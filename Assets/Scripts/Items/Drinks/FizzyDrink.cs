using UnityEngine;

public class FizzyDrink : Drinks {
    public Soda soda;
    public Syrup syrup;
    public Fruit fruit;

    void Start() {
        SetIngredients();
        price = 0;
    }

    public void Interact(ref FizzyDrink input, ref int priority) {
        switch ((Priorities)priority) {
            case Priorities.First:
                if (GetSoda().SetIngredient(ref input.soda.ing, ref priority)) MenuManager.instance.SetInteractionType("Soda");
                break;
            case Priorities.Second:
                if (GetSyrup().SetIngredient(ref input.syrup.ing, ref priority)) MenuManager.instance.SetInteractionType("Syrup");
                break;
            case Priorities.Third:
                if (GetFruit().SetIngredient(ref input.fruit.ing, ref priority)) MenuManager.instance.SetInteractionType("Fruit");
                break;
            default: Debug.Log("Priority too high or low"); break;
        }

        UpdateIngredients(ref input);
        FizzyDrinkManager.instance.SetFinalDrinkName(input);
    }

    // setters
    void SetIngredients() {
        soda.Set();
        syrup.Set();
        fruit.Set();
    }
    void UpdateIngredients(ref FizzyDrink input) {
        input.soda.SetDebugVariables();
        input.syrup.SetDebugVariables();
        input.fruit.SetDebugVariables();
    }

    // getters
    public Ingredient GetSoda() { return soda.ing; }
    public Ingredient GetSyrup() { return syrup.ing; }
    public Ingredient GetFruit() { return fruit.ing; }

    // viewers
    override public bool IsEveryStateOff() { return GetSoda().IsAllOff() && GetSyrup().IsAllOff() && GetFruit().IsAllOff(); }
    override public void SetAllOff() {
        GetSoda().SetAllStates();
        GetSyrup().SetAllStates();
        GetFruit().SetAllStates();
    }
}
