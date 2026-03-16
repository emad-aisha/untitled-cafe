using UnityEngine;

public class BaseCup : MonoBehaviour, IInteractable {
    // BaseCup cup;

    private FizzyDrinks fizzy;
    private int currPriority;

    virtual public void Interact(Collider interactable) {
        Debug.Log("basecup");
        FizzyDrinks fizzyDrink = interactable.GetComponent<FizzyDrinks>();


        if (fizzyDrink != null) {
            Debug.Log("call drinkInteract");
            fizzyDrink.DrinkInteract(ref fizzy, ref currPriority);

            Debug.Log(fizzy.GetSoda().hasSoda);
            Debug.Log(currPriority);
            return;
        }
    }

    public FizzyDrinks GetFizzyDrink() { return fizzy; }
    public int GetCurrPriority() { return currPriority; }


    public void SetFizzyDrink(FizzyDrinks newFizzyDrink) { fizzy = newFizzyDrink; }
    public void SetCurrPriority(int newPriority) { currPriority = newPriority; }
}
