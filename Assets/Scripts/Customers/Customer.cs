using UnityEngine;


public class Customer : MonoBehaviour, IMoney {
    [SerializeField] State info;

    // states
    CustomerState currentState = CustomerState.Idle;
    Idle idleState;


    void Start() {
        idleState = new();
        CustomerManager.instance.numberOfCustomers++;

    }

    void OnDestroy() {
        CustomerManager.instance.numberOfCustomers--;
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
}
