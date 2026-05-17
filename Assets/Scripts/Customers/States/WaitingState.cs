using UnityEngine;

public class WaitingState : State {
    float internalTimer = 0;

    public override void UpdateState() {
        if (info.stopWaiting) {
            //GameManager.instance.playerMoney;

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



}
