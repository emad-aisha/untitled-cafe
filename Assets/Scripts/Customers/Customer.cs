
using UnityEngine;


public enum CustomerState { Null = -1, Idle, Ordering, Waiting, Eating, Leaving, Count };
public class Customer : MonoBehaviour, IMoney {
    CustomerInformation info;

    [Header("States")]
    [SerializeField] GameObject stateObject;

    State[] states;

    void Start() {
        CustomerManager.instance.numberOfCustomers++;
        info = GetComponent<CustomerInformation>();
        SetStates();
    }


    void Update() {
        switch (info.currentState) {
            case CustomerState.Idle: states[(int)CustomerState.Idle].UpdateState(); break;
            case CustomerState.Ordering: states[(int)CustomerState.Ordering].UpdateState(); break;
            case CustomerState.Waiting: states[(int)CustomerState.Waiting].UpdateState(); break;
            case CustomerState.Eating: break;
            case CustomerState.Leaving: break;
            default: Debug.Log("error"); break;
        }

        if (info.currentState == CustomerState.Leaving) { Destroy(gameObject); }
    }

    public void Interact(Drink drink) {
        switch (info.currentState) {
            case CustomerState.Ordering: info.CanOrder(); break;
            case CustomerState.Waiting: info.StopWaiting(drink); break;
        }
    }


    // setters
    void SetStates() {
        states = new State[(int)CustomerState.Count];
        for (int i = 0; i < (int)CustomerState.Count; i++) {
            states[i] = i switch {
                (int)CustomerState.Idle => stateObject.GetComponent<IdleState>(),
                (int)CustomerState.Ordering => stateObject.GetComponent<OrderingState>(),
                (int)CustomerState.Waiting => stateObject.GetComponent<WaitingState>(),
                (int)CustomerState.Eating => null,
                (int)CustomerState.Leaving => null,
                _ => null
            };

            if (states[i]) states[i].SetCustomerInfo(info);
        }
    }

    void OnDestroy() {
        CustomerManager.instance.numberOfCustomers--;
    }

}
