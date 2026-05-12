using UnityEngine;

public class OrderingState : State {


    public override void UpdateState() {
        if (info.canOrder) {

            info.currentState = CustomerState.Waiting;
        }
    }

}
