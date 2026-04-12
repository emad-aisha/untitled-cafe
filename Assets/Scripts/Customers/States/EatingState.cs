using UnityEngine;

public class EatingState : State {
    float internalTimer = 0;

    public override void UpdateState() {
        if (internalTimer < info.eatingTime) { internalTimer += Time.deltaTime; }
        else {
            info.currentState = CustomerState.Leaving;
        }
    }
}
