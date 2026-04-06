
using UnityEngine;


public enum CustomerState { Idle, Ordering, Waiting, Eating, Leaving, Null };
public class Customer : MonoBehaviour, IMoney {
    [SerializeField] CustomerInformation info;

    // states
    [SerializeField] Idle idleState;
    [SerializeField] Ordering orderingState;


    [Header("Idle State - Timer")]
    [SerializeField][Range(0.5f, 1)] float minTime;
    [SerializeField][Range(5, 20)] float maxTime;

    [Header("Ordering State - Debugging")]
    [SerializeField] bool CanOrder = false;


    [Header("Debugging")]
    [SerializeField] CustomerState currentState = CustomerState.Idle;


    void Start() {
        SetStates();
        CustomerManager.instance.numberOfCustomers++;
    }

    void Update() {
        currentState = currentState switch {
            CustomerState.Idle => idleState.Update(ref info),
            CustomerState.Ordering => orderingState.Update(ref info, CanOrder),
            CustomerState.Waiting => CustomerState.Null,
            CustomerState.Eating => CustomerState.Null,
            CustomerState.Leaving => CustomerState.Null,
            _ => CustomerState.Null
        };

    }

    public void Interact() {
        if (currentState != CustomerState.Ordering) return;
        CanOrder = true;
    }

    // setters
    void SetStates() {
        idleState = new(GetRandomWaitTime());
        orderingState = new();
    }


    // getters
    float GetRandomWaitTime() {
        if (info.isDebugging) return 0.5f;
        return Random.Range(minTime, maxTime);
    }


    void OnDestroy() {
        CustomerManager.instance.numberOfCustomers--;
    }

}
