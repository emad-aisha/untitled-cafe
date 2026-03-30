using UnityEngine;

public class Cup {
    // drinks
    private FizzyDrinks fizzy;

    private int currPriority;

    // constructor
    public Cup(FizzyDrinks fizzyDrink, int priority) { SetAllMembers(fizzyDrink, priority); }

    // interface override
    public void Interact(Collider interactable) {
        FizzyDrinks fizzyDrink = interactable.GetComponent<FizzyDrinks>();

        if (fizzyDrink != null) {
            fizzyDrink.DrinkInteract(ref fizzy, ref currPriority);
            return;
        }
    }

    // getters
    public FizzyDrinks GetFizzyDrink() { return fizzy; }
    public int GetCurrPriority() { return currPriority; }

    // setters
    public void SetAllMembers(FizzyDrinks newFizzyDrink, int newPriority) {
        SetFizzyDrink(newFizzyDrink);
        SetCurrPriority(newPriority);
    }
    public void SetFizzyDrink(FizzyDrinks newFizzyDrink) { fizzy = newFizzyDrink; }
    public void SetCurrPriority(int newPriority) { currPriority = newPriority; }
}
