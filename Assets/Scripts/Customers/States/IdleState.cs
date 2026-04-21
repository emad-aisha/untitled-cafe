using UnityEngine;

public class IdleState : State {
    float internalTimer = 0;

    public override void UpdateState() {
        if (internalTimer < info.waitTime) { internalTimer += Time.deltaTime; }
        else {
            if (info.personalSeat == null) info.personalSeat = CustomerManager.instance.GetFreeTable(info.party);
            if (info.personalSeat == null) { info.currentState = CustomerState.Leaving; return; }

            info.currentState = CustomerState.Ordering;
        }
    }

}
