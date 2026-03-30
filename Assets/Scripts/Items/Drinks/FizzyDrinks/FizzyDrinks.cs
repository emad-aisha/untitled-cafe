using UnityEngine;

public class FizzyDrinks : MonoBehaviour {
    [HideInInspector] public enum Priorities { first, second, third };
    [SerializeField] Soda soda;
    [SerializeField] Syrup syrup;
    [SerializeField] Fruit fruit;


    void Start() {
        soda = gameObject.GetComponent<Soda>();
        syrup = gameObject.GetComponent<Syrup>();
        fruit = gameObject.GetComponent<Fruit>();
    }

    public void Interact(ref FizzyDrinks input, ref int priority) {
        if (soda && IsMatching(soda.priority, priority)) { soda.Set(ref input.soda, ref priority); }
        else if (syrup && IsMatching(syrup.priority, priority)) { syrup.Set(ref input.syrup, ref priority); }
        else if (fruit && IsMatching(fruit.priority, priority)) { fruit.Set(ref input.fruit, ref priority); }

        DrinkManager.instance.SetFinalFizzyDrink(input);
    }

    bool IsMatching(Priorities priority, int checkedPriority) {
        return priority == (Priorities)checkedPriority;
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
