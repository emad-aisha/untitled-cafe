using UnityEngine;


public enum FizzyDrinkIngredients { Soda, Syrup, Fruit, Null = -1 };
public class FizzyDrink : Drink {
    [Header("Personal")]
    [SerializeField] Soda soda;
    [SerializeField] Syrup syrup;
    [SerializeField] Fruit fruit;

    void Start() { SetMemberVariables(DrinkType.FizzyDrink); }

    public override void Interact(ref Drink input, ref int priority) {
        switch ((Priorities)priority) {
            case Priorities.First: SetIngredient(ref input, FizzyDrinkIngredients.Soda, ref priority); break;
            case Priorities.Second: SetIngredient(ref input, FizzyDrinkIngredients.Syrup, ref priority); break;
            case Priorities.Third: SetIngredient(ref input, FizzyDrinkIngredients.Fruit, ref priority); break;
            default: Debug.Log("Priority too high or low"); break;
        }

        ShowDrinkInfo(ref input);
    }

    // setters
    override protected void SetIngredients() {
        ingredients = new Ingredient[3];
        soda.Set();
        syrup.Set();
        fruit.Set();

        ingredients.At(FizzyDrinkIngredients.Soda) = soda.ing;
        ingredients.At(FizzyDrinkIngredients.Syrup) = syrup.ing;
        ingredients.At(FizzyDrinkIngredients.Fruit) = fruit.ing;
    }
    override public void SetAllOff() {
        GetSoda().SetAllStates();
        GetSyrup().SetAllStates();
        GetFruit().SetAllStates();
    }
    public void Set(Soda _soda, Syrup _syrup, Fruit _fruit) {
        soda = _soda;
        syrup = _syrup;
        fruit = _fruit;
    }


    // getters
    public Ingredient GetSoda() { return ingredients.At(FizzyDrinkIngredients.Soda); }
    public Ingredient GetSyrup() { return ingredients.At(FizzyDrinkIngredients.Syrup); }
    public Ingredient GetFruit() { return ingredients.At(FizzyDrinkIngredients.Fruit); }

    public override bool IsEveryStateOff() { return GetSoda().IsAllOff() && GetSyrup().IsAllOff() && GetFruit().IsAllOff(); }
}
