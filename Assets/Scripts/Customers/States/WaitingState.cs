using UnityEngine;

public class WaitingState : State {
    float internalTimer = 0;

    public override void UpdateState() {
        if (info.stopWaiting) {
            // TODO: finish this
            //GameManager.instance.playerMoney;
            Drink drink = info.GetActiveDrink();
            float tip = GetTip(drink);

            info.currentState = CustomerState.Eating;
        }
        else {
            internalTimer += Time.deltaTime;

            if (internalTimer > info.leaveTime) {
                info.currentState = CustomerState.Leaving;
                Debug.Log("left");
            }
            else
                info.currentState = CustomerState.Waiting;
        }
    }


    float GetTip(Drink drink) {
        float finalTip = 0;

        if (internalTimer > info.leaveTime) {
            Debug.Log("left");
            return finalTip;
        }
        else if (internalTimer > info.discountTime) {
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
