using Unity.VisualScripting;
using UnityEngine;

public class FizzyDrinks : MonoBehaviour {
    [HideInInspector] public enum Priorities { first, second, third };
    [SerializeField] private Soda soda;
    [SerializeField] private Syrup syrup;
    [SerializeField] private Fruit fruit;

    void Start() {
        soda = gameObject.GetComponent<Soda>();
        syrup = gameObject.GetComponent<Syrup>();
        fruit = gameObject.GetComponent<Fruit>();

        SetAllOff();
    }

    public void DrinkInteract(ref FizzyDrinks input, ref int priority) {
        // TODO: make this into a function with casts
        if (soda && IsMatching(soda.priority, priority)) {
            if (!input.soda) return;
            if (!input.soda.CanHaveManyIngredient()) return;

            input.soda.SetOne(soda.GetTrue());
            priority++;
            return;
        }
        else if (syrup && IsMatching(syrup.priority, priority)) {
            if (!input.syrup) return;
            if (!input.syrup.CanHaveManyIngredient()) return;

            input.syrup.SetOne(syrup.GetTrue());
            priority++;
            return;
        }
        else if (fruit && IsMatching(fruit.priority, priority)) {
            if (!input.fruit) return;
            if (!input.fruit.CanHaveManyIngredient()) return;

            input.fruit.SetOne(fruit.GetTrue());
            return;
        }

    }


    bool IsMatching(Priorities priority, int checkedPriority) {
        return priority == (Priorities)checkedPriority;
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
