using UnityEngine;

public class FizzyDrink : Drinks {
    [SerializeField] Soda soda;
    [SerializeField] Syrup syrup;
    [SerializeField] Fruit fruit;

    void Start() {
        soda = gameObject.GetComponent<Soda>();
        syrup = gameObject.GetComponent<Syrup>();
        fruit = gameObject.GetComponent<Fruit>();
        price = 0;
    }

    public void Interact(ref FizzyDrink input, ref int priority) {
        if (soda && IsMatching(soda.priority, priority)) { soda.SetIngredient(ref input, ref priority); }
        else if (syrup && IsMatching(syrup.priority, priority)) { syrup.SetIngredient(ref input, ref priority); }
        else if (fruit && IsMatching(fruit.priority, priority)) { fruit.SetIngredient(ref input, ref priority); }
    }

    bool IsMatching(Priorities priority, int checkedPriority) { return priority == (Priorities)checkedPriority; }

    public bool IsActive() {
        bool result = true;
        if (soda.IsAllOff() && syrup.IsAllOff() && fruit.IsAllOff()) result = false;
        return result;
    }


    // getters
    public Soda GetSoda() { return soda; }
    public Syrup GetSyrup() { return syrup; }
    public Fruit GetFruit() { return fruit; }

    // setters
    public void SetSoda(Soda newSoda) { soda = newSoda; }
    public void SetSyrup(Syrup newSyrup) { syrup = newSyrup; }
    public void SetFruit(Fruit newFruit) { fruit = newFruit; }
}
