using UnityEngine;

public abstract class FizzyDrinkIngredients : Ingredients {
    public enum IngredientType { Null, Soda, Syrup, Fruit };

    [HideInInspector] public Drinks.Priorities priority;
    protected FizzyDrink parent;


    protected void SetMemberVariables(Drinks.Priorities _priority) {
        parent = gameObject.GetComponent<FizzyDrink>();
        SetParent(ref parent);
        PushBackBools();

        priority = _priority;
    }
    void SetParent(ref FizzyDrink fizzyDrink) {
        Soda soda = gameObject.GetComponent<Soda>();
        Syrup syrup = gameObject.GetComponent<Syrup>();
        Fruit fruit = gameObject.GetComponent<Fruit>();

        if (soda) fizzyDrink.SetSoda(soda);
        if (syrup) fizzyDrink.SetSyrup(syrup);
        if (fruit) fizzyDrink.SetFruit(fruit);
    }

    public bool CanChangeVariables(FizzyDrink input, IngredientType type) {
        Soda soda = input.GetSoda();
        Syrup syrup = input.GetSyrup();
        Fruit fruit = input.GetFruit();

        bool result = true;
        switch (type) {
            case IngredientType.Soda: if (soda == null || !soda.CanGetItem()) result = false; break;
            case IngredientType.Syrup: if (syrup == null || !syrup.CanGetItem()) result = false; break;
            case IngredientType.Fruit: if (fruit == null || !fruit.CanGetItem()) result = false; break;
        }
        return result;
    }

    abstract public bool SetIngredient(ref FizzyDrink input, ref int priority);
}
