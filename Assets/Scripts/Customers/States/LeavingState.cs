using UnityEngine;

public class LeavingState : State {
    float internalTimer = 0;

    public override void UpdateState() {
        if (internalTimer < info.leavingTime) { internalTimer += Time.deltaTime; }
        else Destroy(info.customer);
    }
}
