using UnityEngine;


public enum CustomerState { Null = -1, Idle, Ordering, Waiting, Eating, Leaving, Count };
public class Customer : MonoBehaviour, IInteractable {
    CustomerInformation info;

    [Header("States")]
    [SerializeField] GameObject stateObject;

    State[] states;

    void Start() {
        CustomerManager.instance.numberOfCustomers++;
        info = GetComponent<CustomerInformation>();
        SetStates();
    }

    void Update() { states[(int)info.currentState].UpdateState(); }


    public float Interact(Drink drink) {
        switch (info.currentState) {
            case CustomerState.Ordering: info.CanOrder(); return 0;
            case CustomerState.Waiting:
                if (!info.stopWaiting) { info.StopWaiting(drink); return 0; }
                else return info.GetActiveDrink().price + info.tip;
        }
        return 0;
    }


    // setters
    void SetStates() {
        states = new State[(int)CustomerState.Count];
        for (int i = 0; i < (int)CustomerState.Count; i++) {
            states[i] = i switch {
                (int)CustomerState.Idle => stateObject.GetComponent<IdleState>(),
                (int)CustomerState.Ordering => stateObject.GetComponent<OrderingState>(),
                (int)CustomerState.Waiting => stateObject.GetComponent<WaitingState>(),
                (int)CustomerState.Eating => stateObject.GetComponent<EatingState>(),
                (int)CustomerState.Leaving => stateObject.GetComponent<LeavingState>(),
                _ => null
            };

            if (states[i]) states[i].SetCustomerInfo(info);
        }
    }

    void OnDestroy() {
        CustomerManager.instance.numberOfCustomers--;
    }

}
