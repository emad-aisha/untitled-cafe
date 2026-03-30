using UnityEngine;

public class FizzyDrinkIngredients : Ingredients {
    [HideInInspector] public FizzyDrinks.Priorities priority;
    protected FizzyDrinks parent;

    override public void SetAllOff() { Debug.Log("Called FizzyDrink's SetAllOff"); }
    override public bool IsAllOff() { Debug.Log("Called FizzyDrink's IsAllOff"); return false; }

    protected void SetAll(FizzyDrinks.Priorities _priority, bool _canHaveMultiple) {
        parent = gameObject.GetComponent<FizzyDrinks>();
        SetDrink(ref parent);
        priority = _priority;
        canHaveMultiple = _canHaveMultiple;
    }
    void SetDrink(ref FizzyDrinks fizzyDrink) {
        Soda soda = gameObject.GetComponent<Soda>();
        Syrup syrup = gameObject.GetComponent<Syrup>();
        Fruit fruit = gameObject.GetComponent<Fruit>();

        if (soda != null) fizzyDrink.SetSoda(gameObject.GetComponent<Soda>());
        if (syrup != null) fizzyDrink.SetSyrup(gameObject.GetComponent<Syrup>());
        if (fruit != null) fizzyDrink.SetFruit(gameObject.GetComponent<Fruit>());
    }


}
