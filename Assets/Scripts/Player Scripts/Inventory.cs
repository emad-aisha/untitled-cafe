using UnityEngine;

public class Inventory : MonoBehaviour {
    // cup item
    enum Type { Null, FizzyDrink, Coffee };
    [SerializeField] FizzyDrinks myFizzyDrink;
    [SerializeField] Coffee myCoffee;

    private int currPriority;
    public int currPrice;

    public void Interact(Collider interactable) {
        FizzyDrinks inputFizzyDrink = interactable.GetComponent<FizzyDrinks>();
        Coffee inputCoffee = interactable.GetComponent<Coffee>();

        if (inputFizzyDrink != null && !myCoffee.IsActive()) { FizzyDrinkInteract(inputFizzyDrink); }
        if (inputCoffee != null && !myFizzyDrink.IsActive()) { CoffeeInteract(inputCoffee); }
    }

    void FizzyDrinkInteract(FizzyDrinks inputFizzyDrink) {
        inputFizzyDrink.Interact(ref myFizzyDrink, ref currPriority);
        currPrice = DrinkManager.instance.SetFinalDrink(myFizzyDrink);
    }
    void CoffeeInteract(Coffee inputCoffee) {
        inputCoffee.Interact(ref myCoffee, ref currPriority);
        currPrice = DrinkManager.instance.SetFinalDrink(myCoffee);
    }

    bool IsOthersActive(Type drinkType) {
        bool result = false;

        switch (drinkType) {
            case Type.Null: Debug.Log("null"); break;
            case Type.FizzyDrink: break;
            case Type.Coffee: break;
        }

        return result;
    }

}
