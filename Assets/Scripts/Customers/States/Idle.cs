using UnityEngine;

public class Idle : State {
    float waitTimer;
    float internalTimer = 0;

    public Idle(float waitTime) { waitTimer = waitTime; }

    public CustomerState Update(ref CustomerInformation info) {
        if (internalTimer < waitTimer) internalTimer += Time.deltaTime;
        else {
            info.personalSeat = CustomerManager.instance.GetFreeTable(info.party);
            if (info.personalSeat == null) return CustomerState.Leaving;

            SetRandomizedDrink(info);
            internalTimer = 0;

            return CustomerState.Ordering;
        }
        return CustomerState.Idle;
    }

    // setters
    void SetRandomizedDrink(CustomerInformation info) {
        DrinkType drinkChosen = (DrinkType)Random.Range(0, (int)DrinkType.Count);

        FizzyDrinkManager fizzyDrinkManager = new();
        CoffeeManager coffeeManager = new();

        Drink drink = info.GetDrink(drinkChosen);
        switch (drinkChosen) {
            case DrinkType.FizzyDrink: drink.RandomizeDrink(fizzyDrinkManager); break;
            case DrinkType.Coffee: drink.RandomizeDrink(coffeeManager); break;
            default: Debug.Log("Didn't Randomize"); break;
        }

        if (info.isDebugging) Debug.Log(drink.drinkName);
        MenuManager.instance.SetCustomerOrder("Ready");
    }

}
