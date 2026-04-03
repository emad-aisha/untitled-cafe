using UnityEngine;

public class FizzyDrink : Drinks {
    public Soda soda;
    public Syrup syrup;
    public Fruit fruit;

    int sodaPriority;
    int syrupPriority;
    int fruitPriority;

    void Start() {
        SetIngredients();
        SetPriorities();
        price = 0;
    }

    public void Interact(ref FizzyDrink input, ref int priority) {

        if (CheckPriorities(sodaPriority, priority)) {
            GetSoda().SetIngredient(ref input.soda.ing, ref priority);
            MenuManager.instance.SetInteractionType("Soda");
        }
        else if (CheckPriorities(syrupPriority, priority)) {
            GetSyrup().SetIngredient(ref input.syrup.ing, ref priority);
            MenuManager.instance.SetInteractionType("Syrup");
        }
        else if (CheckPriorities(fruitPriority, priority)) {
            GetFruit().SetIngredient(ref input.fruit.ing, ref priority);
            MenuManager.instance.SetInteractionType("Fruit");
        }
        FizzyDrinkManager.instance.SetFinalDrinkName(input);
    }

    // setters
    void SetPriorities() {
        sodaPriority = (int)GetSoda().GetPriority();
        syrupPriority = (int)GetSyrup().GetPriority();
        fruitPriority = (int)GetFruit().GetPriority();
    }
    void SetIngredients() {
        soda.Set();
        syrup.Set();
        fruit.Set();
    }

    // getters
    public Ingredient GetSoda() { return soda.ing; }
    public Ingredient GetSyrup() { return syrup.ing; }
    public Ingredient GetFruit() { return fruit.ing; }

    // viewers
    public bool IsEveryStateOff() { return soda.ing.IsAllOff() && syrup.ing.IsAllOff() && fruit.ing.IsAllOff(); }
}
