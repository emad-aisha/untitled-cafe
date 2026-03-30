using UnityEngine;

public class Cup {
    // drinks
    private FizzyDrinks fizzy;
    private Coffee coffee;

    private int currPriority;

    // constructor
    public Cup(FizzyDrinks fizzyDrink, Coffee coffeeDrink, int priority) { SetAllMembers(fizzyDrink, coffeeDrink, priority); }

    // interface override
    public void Interact(Collider interactable) {
        FizzyDrinks inputFizzyDrink = interactable.GetComponent<FizzyDrinks>();
        Coffee inputCoffee = interactable.GetComponent<Coffee>();

        if (inputFizzyDrink != null) {
            inputFizzyDrink.Interact(ref fizzy, ref currPriority);
            return;
        }
        if (inputCoffee != null) {
            inputCoffee.Interact(ref coffee, ref currPriority);
            return;
        }
    }

    // getters
    public FizzyDrinks GetFizzyDrink() { return fizzy; }
    public int GetCurrPriority() { return currPriority; }

    // setters
    public void SetAllMembers(FizzyDrinks newFizzyDrink, Coffee newCoffee, int newPriority) {
        SetFizzyDrink(newFizzyDrink);
        SetCoffee(newCoffee);
        SetCurrPriority(newPriority);
    }
    void SetFizzyDrink(FizzyDrinks newFizzyDrink) { fizzy = newFizzyDrink; }
    void SetCoffee(Coffee newCoffee) { coffee = newCoffee; }
    void SetCurrPriority(int newPriority) { currPriority = newPriority; }
}
