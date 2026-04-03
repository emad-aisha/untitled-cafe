using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] FizzyDrink myFizzyDrink;
    [SerializeField] Coffee myCoffee;

    [Header("Debug")]
    [SerializeField] private int currPriority;
    [Header("")]
    public int currMoney = 0;
    public int currPrice;



    public void Interact(Collider interactable) {
        FizzyDrinkInteract(interactable);
        CoffeeInteract(interactable);

        MoneyInteract(interactable);
    }

    void FizzyDrinkInteract(Collider interactable) {
        FizzyDrink inputFizzyDrink = interactable.GetComponent<FizzyDrink>();
        if (inputFizzyDrink != null && myCoffee.IsEveryStateOff()) {
            inputFizzyDrink.Interact(ref myFizzyDrink, ref currPriority);
            currPrice = FizzyDrinkManager.instance.SetFinalDrinkCost(myFizzyDrink);
        }
    }
    void CoffeeInteract(Collider interactable) {
        Coffee inputCoffee = interactable.GetComponent<Coffee>();

        if (inputCoffee != null && myFizzyDrink.IsEveryStateOff()) {
            inputCoffee.Interact(ref myCoffee, ref currPriority);
            currPrice = CoffeeManager.instance.SetFinalDrinkCost(myCoffee);
        }
    }
    void MoneyInteract(Collider interactable) {
        // TODO: change into a variable maybe
        if (interactable.CompareTag("Money")) {
            currMoney += currPrice;
            currPrice = 0;
            currPriority = 0;

            SetAllDrinksOff();
            MenuManager.instance.SetDrinkInformation("nothing", "NULL", 0);
            MenuManager.instance.SetPlayerMoney(currMoney.ToString() + "$");
        }
    }

    // set all off
    void SetAllDrinksOff() {
        myFizzyDrink.SetAllOff();
        myCoffee.SetAllOff();
    }

}
