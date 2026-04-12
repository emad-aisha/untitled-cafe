using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] Drink[] drinks;

    [Header("Debug")]
    [SerializeField] private int currPriority;
    [SerializeField] private float currPrice;

    // TODO: refactor
    public void Interact(Collider interactable) {
        Money money = interactable.GetComponent<Money>();
        Customer customer = interactable.GetComponent<Customer>();

        Drink drinkMachine = interactable.GetComponent<Drink>();
        DrinkType drinkType = GetDrinkType(interactable);

        if (drinkMachine) { Interact(drinkMachine, drinkType); }
        else if (customer) { customer.Interact(GetActiveDrink()); }
        else if (money != null) {
            money.Interact(GetActiveDrink());
            AddMoney();
            ResetDrinkInfo(ref drinks);
            ClearInfo(GameManager.instance.playerMoney);
        }
    }

    // setters
    void SetDrinkInfo(Drink drink) {
        currPrice = drink.price;
        MenuManager.instance.SetFinalDrink(drink.drinkName);
        MenuManager.instance.SetCost(drink.price.ToString("#.00"));
    }

    // getters
    DrinkType GetDrinkType(Collider interactable) {
        FizzyDrink fizzyComponent = interactable.GetComponent<FizzyDrink>();
        Coffee coffeeComponent = interactable.GetComponent<Coffee>();

        if (fizzyComponent != null) return DrinkType.FizzyDrink;
        else if (coffeeComponent != null) return DrinkType.Coffee;

        return DrinkType.Null;
    }


    void Interact(Drink drinkMachine, DrinkType drink) {
        if (!IsOtherDrinksOff(drink)) return;

        drinkMachine.Interact(ref drinks[(int)drink], ref currPriority);
        SetDrinkInfo(drinks[(int)drink]);
    }
    bool IsOtherDrinksOff(DrinkType drinkToCompare) {
        for (int i = 0; i < drinks.Length; i++) {
            if (i == (int)drinkToCompare) continue;
            if (!drinks[i].IsEveryStateOff()) return false;
        }
        return true;
    }

    // money help
    void AddMoney() {
        GameManager.instance.playerMoney += currPrice;
        currPrice = 0;
        currPriority = 0;
    }

    public void ClearInfo(float currMoney) {
        MenuManager.instance.SetFinalDrink("nothing");
        MenuManager.instance.SetCost("0");

        MenuManager.instance.SetPlayerMoney(currMoney.ToString());
    }

    public void ResetDrinkInfo(ref Drink[] drinks) {
        for (int i = 0; i < drinks.Length; i++) {
            drinks[i].ResetInfo();
        }
    }

    // TODO: organize into static instance?
    public Drink GetActiveDrink() {
        for (int i = 0; i < drinks.Length; i++) if (!drinks[i].IsEveryStateOff()) return drinks[i];
        Debug.Log("Couldn't find an active drink");
        return null;
    }
}
