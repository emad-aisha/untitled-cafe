using UnityEngine;

public class OrderingState : State {


    public override void UpdateState() {
        if (info.canOrder) {
            Drink drink = info.GetActiveDrink();
            MenuManager.instance.SetCustomerOrder(drink.drinkName);
            MenuManager.instance.SetCustomerPrice(drink.price.ToString());

            info.currentState = CustomerState.Waiting;
        }
    }

}
