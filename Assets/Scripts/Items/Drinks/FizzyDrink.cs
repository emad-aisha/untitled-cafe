using UnityEngine;

public class FizzyDrink : Drink {
    [Header("Personal")]
    [SerializeField] Soda soda;
    [SerializeField] Syrup syrup;
    [SerializeField] Fruit fruit;

    override public void Interact(ref Drink input, ref int priority) {

        switch ((Priorities)priority) {
            case Priorities.First: SetIngredient(ref input, FizzyDrinkIngredients.Soda, ref priority); break;
            case Priorities.Second: SetIngredient(ref input, FizzyDrinkIngredients.Syrup, ref priority); break;
            case Priorities.Third: SetIngredient(ref input, FizzyDrinkIngredients.Fruit, ref priority); break;
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

        ingredients[(int)FizzyDrinkIngredients.Soda] = soda.ing;
        ingredients[(int)FizzyDrinkIngredients.Syrup] = syrup.ing;
        ingredients[(int)FizzyDrinkIngredients.Fruit] = fruit.ing;
    }

    public void Set(Soda _soda, Syrup _syrup, Fruit _fruit) {
        SetSoda(_soda);
        SetSyrup(_syrup);
        SetFruit(_fruit);
    }
    public void SetSoda(Soda _soda) { soda = _soda; }
    public void SetSyrup(Syrup _syrup) { syrup = _syrup; }
    public void SetFruit(Fruit _fruit) { fruit = _fruit; }

    // getters
    public Ingredient GetSoda() { return ingredients[(int)FizzyDrinkIngredients.Soda]; }
    public Ingredient GetSyrup() { return ingredients[(int)FizzyDrinkIngredients.Syrup]; }
    public Ingredient GetFruit() { return ingredients[(int)FizzyDrinkIngredients.Fruit]; }


    override public bool IsEveryStateOff() { return GetSoda().IsAllOff() && GetSyrup().IsAllOff() && GetFruit().IsAllOff(); }
    override public void SetAllOff() {
        GetSoda().SetAllStates();
        GetSyrup().SetAllStates();
        GetFruit().SetAllStates();
    }
}
