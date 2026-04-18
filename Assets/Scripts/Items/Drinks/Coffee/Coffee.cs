using UnityEngine;


public enum CoffeeIngredients { Espresso, Liquid, Extras, Null = -1 };
public class Coffee : Drink {
    [Header("Personal")]
    [SerializeField] Espresso espresso;
    [SerializeField] Liquid liquid;
    [SerializeField] Extras extras;

    void Start() { SetMemberVariables(DrinkType.Coffee); }

    override public void Interact(ref Drink input, ref int priority) {
        bool hasMilk = input.ingredients.At(CoffeeIngredients.Liquid).GetStateValue(LiquidType.Milk);

        switch ((Priorities)priority) {
            case Priorities.First: SetIngredient(ref input, CoffeeIngredients.Espresso, ref priority); break;
            case Priorities.Second: SetIngredient(ref input, CoffeeIngredients.Liquid, ref priority); break;
            case Priorities.Third: if (hasMilk) SetIngredient(ref input, CoffeeIngredients.Extras, ref priority); break;
            default: Debug.Log("Priority too high or low"); break;
        }

        ShowDrinkInfo(ref input);
    }

    // setters
    protected override void SetIngredients() {
        ingredients = new Ingredient[3];
        espresso.Set();
        liquid.Set();
        extras.Set();

        ingredients.At(CoffeeIngredients.Espresso) = espresso.ing;
        ingredients.At(CoffeeIngredients.Liquid) = liquid.ing;
        ingredients.At(CoffeeIngredients.Extras) = extras.ing;
    }
    public override void SetAllOff() {
        GetEspresso().SetAllStates();
        GetLiquid().SetAllStates();
        GetExtras().SetAllStates();

    }
    public void Set(Espresso _espresso, Liquid _liquid, Extras _extras) {
        espresso = _espresso;
        liquid = _liquid;
        extras = _extras;
    }

    // getters
    public Ingredient GetEspresso() { return ingredients.At(CoffeeIngredients.Espresso); }
    public Ingredient GetLiquid() { return ingredients.At(CoffeeIngredients.Liquid); }
    public Ingredient GetExtras() { return ingredients.At(CoffeeIngredients.Extras); }

    public override bool IsEveryStateOn() { return GetEspresso().IsActive() && GetLiquid().IsActive() && GetExtras().IsActive(); }
}
