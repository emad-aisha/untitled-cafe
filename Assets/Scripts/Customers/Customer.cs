using UnityEngine;


public enum CustomerState { Idle, Ordering, Waitng, Eating, Leaving, Null };
public class Customer : MonoBehaviour, IMoney {
    CustomerState currentState = CustomerState.Idle;
    [SerializeField] State info;

    // states
    [SerializeField] Idle idleState;


    [Header("Idle State - Timer")]
    [SerializeField][Range(0.5f, 1)] float minTime;
    [SerializeField][Range(5, 20)] float maxTime;
    [SerializeField] bool isDebug;

    void Start() {
        idleState = new(GetRandomWaitTime());
        CustomerManager.instance.numberOfCustomers++;
    }

    void Update() {
        currentState = currentState switch {
            CustomerState.Idle => idleState.Update(ref info),
            CustomerState.Ordering => CustomerState.Null,
            CustomerState.Waitng => CustomerState.Null,
            CustomerState.Eating => CustomerState.Null,
            CustomerState.Leaving => CustomerState.Null,
            _ => CustomerState.Null
        };

    }

    float GetRandomWaitTime() {
        if (isDebug) return 0.5f;
        return Random.Range(minTime, maxTime);
    }

    void OnDestroy() {
        CustomerManager.instance.numberOfCustomers--;
    }

}
