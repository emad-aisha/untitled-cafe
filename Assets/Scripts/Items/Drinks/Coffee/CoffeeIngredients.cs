using UnityEngine;

public class CoffeeIngredients : Ingredients {
    [HideInInspector] public Coffee.Priorities priority;
    protected Coffee parent;

    override public void SetAllOff() { Debug.Log("Called CoffeeIngredients's SetAllOff"); }
    override public bool IsAllOff() { Debug.Log("Called CoffeeIngredients's IsAllOff"); return false; }

    protected void SetAll(Coffee.Priorities _priority, bool _canHaveMultiple) {
        parent = gameObject.GetComponent<Coffee>();
        SetCoffee(ref parent);
        priority = _priority;
        canHaveMultiple = _canHaveMultiple;
    }
    void SetCoffee(ref Coffee coffee) {
        Espresso espresso = gameObject.GetComponent<Espresso>();
        Liquid liquid = gameObject.GetComponent<Liquid>();
        Extras extras = gameObject.GetComponent<Extras>();

        if (espresso != null) coffee.SetEspresso(espresso);
        if (liquid != null) coffee.SetLiquid(liquid);
        if (extras != null) coffee.SetExtras(extras);
    }

}
