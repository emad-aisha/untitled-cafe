using UnityEngine;

public class FizzyDrinkIngredients : Ingredients {
    [HideInInspector] public FizzyDrinks.Priorities priority;
    protected FizzyDrinks parent;

    protected void SetAll(FizzyDrinks.Priorities _priority, bool _canHaveMultiple = false) {
        parent = gameObject.GetComponent<FizzyDrinks>();
        SetDrink(ref parent);
        priority = _priority;
        canHaveMultiple = _canHaveMultiple;
    }
    void SetDrink(ref FizzyDrinks fizzyDrink) {
        Soda soda = gameObject.GetComponent<Soda>();
        Syrup syrup = gameObject.GetComponent<Syrup>();
        Fruit fruit = gameObject.GetComponent<Fruit>();

        if (soda != null) fizzyDrink.SetSoda(soda);
        if (syrup != null) fizzyDrink.SetSyrup(syrup);
        if (fruit != null) fizzyDrink.SetFruit(fruit);
    }


}
