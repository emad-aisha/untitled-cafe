using UnityEngine;

public class FizzyDrinks : BaseCup {
    [HideInInspector] protected enum Priorities { first, second, third };
    private Soda soda;
    private Syrup syrup;
    private Fruit fruit;

    void Start() {
        SetAllOff();
    }

    public void DrinkInteract(ref FizzyDrinks input, ref int priority) {
        SetFizzyDrink(this);

        Debug.Log("priority: " + priority);
        switch ((Priorities)priority) {
            case Priorities.first:
                Debug.Log("soda changed");
                if (input.soda.AllIsOff()) input.soda = soda;
                priority++;
                break;

            case Priorities.second:
                Debug.Log("syrup changed");
                if (input.syrup.AllIsOff()) input.syrup = syrup;
                priority++;
                break;

            case Priorities.third:
                Debug.Log("fruit changed");
                if (input.fruit.AllIsOff()) input.fruit = fruit;
                priority++;
                break;

            default:
                Debug.Log("nothing changed");
                break;
        }

    }

    public void SetAllOff() {
        if (soda) soda.SetAllOff(true);
        if (syrup) syrup.SetAllOff(true);
        if (fruit) fruit.SetAllOff(true);
    }

    public Soda GetSoda() { return soda; }
    public Syrup GetSyrup() { return syrup; }
    public Fruit GetFruit() { return fruit; }

    public void SetSoda(Soda newSoda) { soda = newSoda; }
    public void SetSyrup(Syrup newSyrup) { syrup = newSyrup; }
    public void SetFruit(Fruit newFruit) { fruit = newFruit; }
}
