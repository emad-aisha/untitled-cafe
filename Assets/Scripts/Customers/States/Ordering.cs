using UnityEngine;

public class Ordering : State {

    public CustomerState Update(ref CustomerInformation info, bool canOrder) {
        if (canOrder) {
            Drink drink = GetActiveDrink(info.drinks);
            MenuManager.instance.SetCustomerOrder(drink.drinkName);
            MenuManager.instance.SetCustomerPrice(drink.price.ToString());
            return CustomerState.Waiting;
        }
        else return CustomerState.Ordering;
    }
}
