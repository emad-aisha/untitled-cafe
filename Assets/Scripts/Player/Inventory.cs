using UnityEngine;

public class Inventory : MonoBehaviour {
    // TODO: change into an array of drinks
    // then make drinks use an array to differentiate
    [SerializeField] Drink[] drinks;

    [Header("Debug")]
    [SerializeField] private int currPriority;

    [Header("")]
    public int currMoney = 0;
    public int currPrice;



    public void Interact(Collider interactable) {
        FizzyDrink inputFizzyDrink = interactable.GetComponent<FizzyDrink>();
        Coffee inputCoffee = interactable.GetComponent<Coffee>();
        IMoney money = interactable.GetComponent<IMoney>();

        // TODO: there is probably a way to simplify this
        if (inputFizzyDrink != null && IsOtherDrinksOff(DrinkType.FizzyDrink)) {
            inputFizzyDrink.Interact(ref drinks[(int)DrinkType.FizzyDrink], ref currPriority);
            SetDrinkInfo(drinks[(int)DrinkType.FizzyDrink]);
        }
        else if (inputCoffee != null && IsOtherDrinksOff(DrinkType.Coffee)) {
            inputCoffee.Interact(ref drinks[(int)DrinkType.Coffee], ref currPriority);
            SetDrinkInfo(drinks[(int)DrinkType.Coffee]);
        }
        else if (money != null) {
            AddMoney();
            ResetDrinkInfo();
            money.ResetInfo(currMoney);
        }

    }

    bool IsOtherDrinksOff(DrinkType drinkToCompare) {
        for (int i = 0; i < drinks.Length; i++) {
            if (i == (int)drinkToCompare) continue;
            if (!drinks[i].IsEveryStateOff()) return false;
        }
        return true;
    }

    void SetDrinkInfo(Drink drink) {
        currPrice = drink.price;
        MenuManager.instance.SetFinalDrink(drink.finalDrinkName);
        MenuManager.instance.SetCost(drink.price.ToString());
    }

    void ResetDrinkInfo() {
        for (int i = 0; i < drinks.Length; i++) {
            drinks[i].ResetInfo();
        }
    }
    void AddMoney() {
        currMoney += currPrice;
        currPrice = 0;
        currPriority = 0;
    }
}
