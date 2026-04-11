using UnityEngine;

public class Waiting : State {
    float internalTimer = 0;

    float discountTime = 10; // changes with upgrades
    float leaveTime = 20;

    public CustomerState Update(ref CustomerInformation info, bool stopWaiting) {
        if (stopWaiting) {
            // TODO: finish this
            //GameManager.instance.playerMoney;
            Drink drink = info.GetActiveDrink();
            discountTime = drink.price;
            float tip = GetTip(drink);

            return CustomerState.Eating;
        }
        else {
            internalTimer += Time.deltaTime;

            if (internalTimer > leaveTime) return CustomerState.Leaving;
            return CustomerState.Waiting;
        }
    }


    float GetTip(Drink drink) {
        float finalTip = 0;

        if (internalTimer > leaveTime) {
            Debug.Log("left");
            return finalTip;
        }
        else if (internalTimer > discountTime) {
            // TODO: make negative
            Debug.Log("discounted");

            return finalTip;
        }
        else {
            // TODO: set this up
            Debug.Log("regular tip");
            finalTip = (float)drink.price / internalTimer;

            return finalTip;
        }
    }

}
