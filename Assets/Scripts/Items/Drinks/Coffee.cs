using UnityEngine;

public class Coffee : Drinks {
    public Espresso espresso;
    public Liquid liquid;
    public Extras extras;


    void Start() {
        SetIngredients();
        price = 0;
    }

    public void Interact(ref Coffee input, ref int priority) {
        bool hasMilk = input.GetLiquid().GetState((int)LiquidType.Milk);

        switch ((Priorities)priority) {
            case Priorities.First:
                if (GetEspresso().SetIngredient(ref input.espresso.ing, ref priority)) MenuManager.instance.SetInteractionType("Espresso");
                break;
            case Priorities.Second:
                if (GetLiquid().SetIngredient(ref input.liquid.ing, ref priority)) MenuManager.instance.SetInteractionType("Liquid");
                break;
            case Priorities.Third:
                if (hasMilk && GetExtras().SetIngredient(ref input.extras.ing, ref priority)) MenuManager.instance.SetInteractionType("Extras");
                break;
            default: Debug.Log("Priority too high or low"); break;
        }

        UpdateIngredients(ref input);
        CoffeeManager.instance.SetFinalDrinkName(input);
    }



    // setters
    void SetIngredients() {
        espresso.Set();
        liquid.Set();
        extras.Set();
    }
    void UpdateIngredients(ref Coffee input) {
        input.espresso.SetDebugVariables();
        input.liquid.SetDebugVariables();
        input.extras.SetDebugVariables();
    }

    // getters
    public Ingredient GetEspresso() { return espresso.ing; }
    public Ingredient GetLiquid() { return liquid.ing; }
    public Ingredient GetExtras() { return extras.ing; }

    // viewers
    public override bool IsEveryStateOff() { return GetEspresso().IsAllOff() && GetLiquid().IsAllOff() && GetExtras().IsAllOff(); }
}
