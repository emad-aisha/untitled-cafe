using UnityEngine;

public class Cup {
    private FizzyDrinks fizzy;
    private int currPriority;

    public Cup(FizzyDrinks newFizzyDrink, int newPriority) {
        SetFizzyDrink(newFizzyDrink);
        SetCurrPriority(newPriority);
    }

    public void Interact(Collider interactable) {
        FizzyDrinks fizzyDrink = interactable.GetComponent<FizzyDrinks>();

        if (fizzyDrink != null) {
            fizzyDrink.DrinkInteract(ref fizzy, ref currPriority);
            Debug.Log(currPriority);
            return;
        }
    }

    public FizzyDrinks GetFizzyDrink() { return fizzy; }
    public int GetCurrPriority() { return currPriority; }


    public void SetFizzyDrink(FizzyDrinks newFizzyDrink) { fizzy = newFizzyDrink; }
    public void SetCurrPriority(int newPriority) { currPriority = newPriority; }
}
