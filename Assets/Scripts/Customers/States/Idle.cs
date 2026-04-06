using UnityEngine;

public class Idle {
    float waitTimer = 2; // TODO: randomize
    float internalTimer = 0;

    public CustomerState Update(ref State info) {
        if (internalTimer < waitTimer) internalTimer += Time.deltaTime;
        else {
            info.personalSeat = CustomerManager.instance.GetFreeTable(info.party);
            if (info.personalSeat == null) return CustomerState.Leaving;

            SetRandomizedDrink(ref info.drinks);
            internalTimer = 0;

            return CustomerState.Ordering;
        }
        return CustomerState.Idle;
    }

    void SetRandomizedDrink(ref Drink[] drinks) {
        DrinkType drinkChosen = (DrinkType)Random.Range(0, (int)DrinkType.Count);
        CoffeeManager coffeeManager = new();
        FizzyDrinkManager fizzyDrinkManager = new();

        switch (drinkChosen) {
            case DrinkType.FizzyDrink: SetDrink(ref drinks, fizzyDrinkManager, DrinkType.FizzyDrink); break;
            case DrinkType.Coffee: SetDrink(ref drinks, coffeeManager, DrinkType.Coffee); break;
            default: Debug.Log("Didn't Randomize"); break;
        }
        MenuManager.instance.SetCustomerOrder("Ready");
    }

    void SetDrink(ref Drink[] drinks, NameManager nameManager, DrinkType drinkType) {
        switch (drinkType) {
            case DrinkType.FizzyDrink: drinks[(int)DrinkType.FizzyDrink].RandomizeDrink(); break;
            case DrinkType.Coffee: drinks[(int)DrinkType.Coffee].RandomizeDrink(); break;
            default: Debug.Log("error"); break;
        }

        Debug.Log(nameManager.SetName(drinks[(int)drinkType]));
        MenuManager.instance.SetCustomerOrder(nameManager.SetName(drinks[(int)drinkType]));
    }

}
