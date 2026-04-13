using UnityEngine;

public class IdleState : State {
    float internalTimer = 0;

    public override void UpdateState() {
        if (internalTimer < info.waitTime) { internalTimer += Time.deltaTime; }
        else {
            if (info.personalSeat == null) info.personalSeat = CustomerManager.instance.GetFreeTable(info.party);
            if (info.personalSeat == null) { info.currentState = CustomerState.Leaving; return; }

            SetRandomizedDrink(ref info);
            info.currentState = CustomerState.Ordering;
        }
    }

    // setters
    void SetRandomizedDrink(ref CustomerInformation info) {
        DrinkType drinkChosen = (DrinkType)Random.Range(0, (int)DrinkType.Count);

        FizzyDrinkManager fizzyDrinkManager = new();
        CoffeeManager coffeeManager = new();

        Drink drink = info.GetDrink(drinkChosen);
        switch (drinkChosen) {
            case DrinkType.FizzyDrink: drink.RandomizeDrink(); break;
            case DrinkType.Coffee: drink.RandomizeDrink(); break;
            default: Debug.Log("Didn't Randomize"); break;
        }

        if (info.isDebugging) Debug.Log(drink.drinkName);
        MenuManager.instance.SetCustomerOrder("Ready");
    }
}
