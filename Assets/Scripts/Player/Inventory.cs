using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] Drink[] drinks;

    [Header("Debug")]
    [SerializeField] private int currPriority;

    [Header("")]
    public int currMoney = 0;
    public int currPrice;

    public void Interact(Collider interactable) {
        IMoney money = interactable.GetComponent<IMoney>();

        Drink drinkMachine = interactable.GetComponent<Drink>();
        DrinkType drinkType = GetDrinkType(interactable);

        if (drinkMachine != null) { Interact(drinkMachine, drinkType); }
        else if (money != null) {
            AddMoney();
            money.ResetDrinkInfo(ref drinks);
            money.ClearInfo(currMoney);
        }
    }

    // setters
    void SetDrinkInfo(Drink drink) {
        currPrice = drink.price;
        MenuManager.instance.SetFinalDrink(drink.finalDrinkName);
        MenuManager.instance.SetCost(drink.price.ToString());
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
        currMoney += currPrice;
        currPrice = 0;
        currPriority = 0;
    }
}
