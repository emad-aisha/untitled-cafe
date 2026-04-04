using UnityEngine;

public class FizzyDrink : Drink {
    [Header("Personal")]
    [SerializeField] Soda soda;
    [SerializeField] Syrup syrup;
    [SerializeField] Fruit fruit;

    override public void Interact(ref Drink input, ref int priority) {

        switch ((Priorities)priority) {
            case Priorities.First: SetIngredient(ref input, FizzyDrinkType.Soda, ref priority); break;
            case Priorities.Second: SetIngredient(ref input, FizzyDrinkType.Syrup, ref priority); break;
            case Priorities.Third: SetIngredient(ref input, FizzyDrinkType.Fruit, ref priority); break;
            default: Debug.Log("Priority too high or low"); break;
        }

        DrinkNameManager.instance.SetDrinkName(input, NameType.FizzyDrink);
    }

    // setters
    override protected void SetIngredients() {
        ingredients = new Ingredient[3];
        soda.Set();
        syrup.Set();
        fruit.Set();

        ingredients[(int)FizzyDrinkType.Soda] = soda.ing;
        ingredients[(int)FizzyDrinkType.Syrup] = syrup.ing;
        ingredients[(int)FizzyDrinkType.Fruit] = fruit.ing;
    }

    // getters
    public Ingredient GetSoda() { return ingredients[(int)FizzyDrinkType.Soda]; }
    public Ingredient GetSyrup() { return ingredients[(int)FizzyDrinkType.Syrup]; }
    public Ingredient GetFruit() { return ingredients[(int)FizzyDrinkType.Fruit]; }


    override public bool IsEveryStateOff() { return GetSoda().IsAllOff() && GetSyrup().IsAllOff() && GetFruit().IsAllOff(); }
}
