using UnityEngine;


public enum FizzyDrinkIngredients { Soda, Syrup, Fruit, Null = -1 };
public class FizzyDrink : Drink {
    [Header("Personal")]
    [SerializeField] Soda soda;
    [SerializeField] Syrup syrup;
    [SerializeField] Fruit fruit;
    FizzyDrinkManager manager;

    void Start() {
        SetMemberVariables(DrinkType.FizzyDrink);
        ingredientMaxes = new int[3];
        ingredientMaxes[(int)FizzyDrinkIngredients.Soda] = (int)SodaType.Count;
        ingredientMaxes[(int)FizzyDrinkIngredients.Syrup] = (int)SyrupType.Count;
        ingredientMaxes[(int)FizzyDrinkIngredients.Fruit] = (int)FruitType.Count;
    }

    override public void Interact(ref Drink input, ref int priority) {
        if (manager == null) manager = new FizzyDrinkManager();

        switch ((Priorities)priority) {
            case Priorities.First: SetIngredient(ref input, FizzyDrinkIngredients.Soda, ref priority); break;
            case Priorities.Second: SetIngredient(ref input, FizzyDrinkIngredients.Syrup, ref priority); break;
            case Priorities.Third: SetIngredient(ref input, FizzyDrinkIngredients.Fruit, ref priority); break;
            default: Debug.Log("Priority too high or low"); break;
        }

        input.drinkName = manager.SetName(input);
        input.price = manager.SetCost();
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
    public override void SetMaxes(ref int[] ingredientMaxes) {
        ingredientMaxes[(int)FizzyDrinkIngredients.Soda] = (int)SodaType.Count;
        ingredientMaxes[(int)FizzyDrinkIngredients.Syrup] = (int)SyrupType.Count;
        ingredientMaxes[(int)FizzyDrinkIngredients.Fruit] = (int)FruitType.Count;
    }

    // getters
    public Ingredient GetSoda() { return ingredients[(int)FizzyDrinkIngredients.Soda]; }
    public Ingredient GetSyrup() { return ingredients[(int)FizzyDrinkIngredients.Syrup]; }
    public Ingredient GetFruit() { return ingredients[(int)FizzyDrinkIngredients.Fruit]; }

    override public bool IsEveryStateOff() { return GetSoda().IsAllOff() && GetSyrup().IsAllOff() && GetFruit().IsAllOff(); }
}
