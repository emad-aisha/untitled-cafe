using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] Drink[] drinks;
    private int currPriority;


    public void Interact(Collider interactable) {
        Customer customer = interactable.GetComponent<Customer>();
        Drink drink = interactable.GetComponent<Drink>();
        Trash trash = interactable.GetComponent<Trash>();

        // TODO: make less ugly
        if (drink) { UpdateCurrDrink(drink); }
        else if (customer) { UpdateCustomer(customer); }
        else if (trash) { UpdateTrash(trash); }
    }

    // Base Functions for each if
    void UpdateCurrDrink(Drink drinkMachine) {
        DrinkType currDrink = drinkMachine.drinkType;
        if (!IsOtherDrinksOff(currDrink)) return;

        drinkMachine.Interact(ref drinks.At(currDrink), ref currPriority);
        MenuManager.instance.SetDrinkInfo(drinks.At(currDrink).drinkName, drinks.At(currDrink).price.ToString("#.00"));
    }
    void UpdateCustomer(Customer customer) {
        UpdateMoney(customer.Interact(DrinkManager.instance.GetActiveDrink(drinks)));

        ResetCustomerDrinkInfo();
        MenuManager.instance.SetInteractionTypes("ignore", "Customer");
    }
    void UpdateTrash(Trash trash) {
        UpdateMoney(0);
    }


    // misc
    void UpdateMoney(float money) {
        GameManager.instance.playerMoney += money;

        ResetDrinkInfo();
        UpdateMoneyInfo();
    }

    bool IsOtherDrinksOff(DrinkType drinkToCompare) {
        for (int i = 0; i < drinks.Length; i++) {
            if (i == (int)drinkToCompare) continue;
            if (drinks[i].IsEveryStateOn()) return false;
        }
        return true;
    }

    // UI updates
    void UpdateMoneyInfo() { MenuManager.instance.SetPlayerMoney(GameManager.instance.playerMoney.ToString()); }

    void ResetDrinkInfo() {
        for (int i = 0; i < drinks.Length; i++) drinks[i].ResetInfo();
        currPriority = 0;

        MenuManager.instance.SetDrinkInfo("nothing", "0");
    }
    void ResetCustomerDrinkInfo() { MenuManager.instance.SetCustomerInfo("", "0"); }
}
