using UnityEngine;

public class Inventory : MonoBehaviour {
    // TODO: change into an array of drinks
    // then make drinks use an array to differentiate
    [SerializeField] Drink myFizzyDrink;
    [SerializeField] Drink myCoffee;

    [Header("Debug")]
    [SerializeField] private int currPriority;
    [Header("")]
    public int currMoney = 0;
    public int currPrice;



    public void Interact(Collider interactable) {
        FizzyDrink inputFizzyDrink = interactable.GetComponent<FizzyDrink>();
        Coffee inputCoffee = interactable.GetComponent<Coffee>();

        if (inputFizzyDrink != null && myCoffee.IsEveryStateOff()) {
            inputFizzyDrink.Interact(ref myFizzyDrink, ref currPriority);
            SetDrinkInfo(myFizzyDrink);
        }
        else if (inputCoffee != null && myFizzyDrink.IsEveryStateOff()) {
            inputCoffee.Interact(ref myCoffee, ref currPriority);
            SetDrinkInfo(myCoffee);
        }

        MoneyInteract(interactable);
    }

    void MoneyInteract(Collider interactable) {
        // TODO: make an interface for this?
        if (interactable.CompareTag("Money")) {
            currMoney += currPrice;
            currPrice = 0;
            currPriority = 0;

            myFizzyDrink.ResetInfo();
            myCoffee.ResetInfo();
            SetDrinkInfo("nothing", "0");
            MenuManager.instance.SetPlayerMoney(currMoney.ToString());
        }
    }

    void SetDrinkInfo(Drink drink) {
        currPrice = drink.price;
        MenuManager.instance.SetFinalDrink(drink.finalDrinkName);
        MenuManager.instance.SetCost(drink.price.ToString());
    }
    void SetDrinkInfo(string finalDrink, string cost) {
        MenuManager.instance.SetFinalDrink(finalDrink);
        MenuManager.instance.SetCost(cost);
    }

}
