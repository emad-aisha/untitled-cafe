using UnityEngine;


public enum CoffeeIngredients { Espresso, Liquid, Extras, Null = -1 };
public class Coffee : Drink {
    [Header("Personal")]
    [SerializeField] Espresso espresso;
    [SerializeField] Liquid liquid;
    [SerializeField] Extras extras;

    void Start() { SetMemberVariables(DrinkType.Coffee); }

    override public void Interact(ref Drink input, ref int priority) {
        bool hasMilk = input.ingredients[(int)CoffeeIngredients.Liquid].GetState((int)LiquidType.Milk);

        switch ((Priorities)priority) {
            case Priorities.First: SetIngredient(ref input, (int)CoffeeIngredients.Espresso, ref priority); break;
            case Priorities.Second: SetIngredient(ref input, (int)CoffeeIngredients.Liquid, ref priority); break;
            case Priorities.Third: if (hasMilk) SetIngredient(ref input, (int)CoffeeIngredients.Extras, ref priority); break;
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

        ingredients[(int)CoffeeIngredients.Espresso] = espresso.ing;
        ingredients[(int)CoffeeIngredients.Liquid] = liquid.ing;
        ingredients[(int)CoffeeIngredients.Extras] = extras.ing;
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
    public Ingredient GetEspresso() { return ingredients[(int)CoffeeIngredients.Espresso]; }
    public Ingredient GetLiquid() { return ingredients[(int)CoffeeIngredients.Liquid]; }
    public Ingredient GetExtras() { return ingredients[(int)CoffeeIngredients.Extras]; }

    public override bool IsEveryStateOff() { return GetEspresso().IsAllOff() && GetLiquid().IsAllOff() && GetExtras().IsAllOff(); }
}
