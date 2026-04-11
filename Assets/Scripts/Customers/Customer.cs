
using UnityEngine;


public enum CustomerState { Idle, Ordering, Waiting, Eating, Leaving, Null };
public class Customer : MonoBehaviour, IMoney {
    [SerializeField] CustomerInformation info;

    // states - TODO: change into one big class
    [SerializeField] Idle idleState;
    [SerializeField] Ordering orderingState;
    [SerializeField] Waiting waitingState;
    void SetStates() {
        idleState = new(GetRandomWaitTime());
        orderingState = new();
        waitingState = new();
    }


    [Header("Idle State - Timer")]
    [SerializeField][Range(0.5f, 1)] float minTime;
    [SerializeField][Range(5, 20)] float maxTime;

    [Header("Ordering State - Debugging")]
    [SerializeField] bool canOrder = false;

    [Header("Waiting State - Debugging")]
    [SerializeField] bool stopWaiting = false;


    [Header("Debugging")]
    [SerializeField] CustomerState currentState;


    void Start() {
        SetStates();
        CustomerManager.instance.numberOfCustomers++;
        currentState = CustomerState.Idle;
    }

    void Update() {
        currentState = currentState switch {
            CustomerState.Idle => idleState.Update(ref info),
            CustomerState.Ordering => orderingState.Update(ref info, canOrder),
            CustomerState.Waiting => waitingState.Update(ref info, stopWaiting),
            CustomerState.Eating => CustomerState.Null,
            CustomerState.Leaving => CustomerState.Leaving,
            _ => CustomerState.Null // TODO: maybe switch this to leaving
        };
        if (currentState == CustomerState.Leaving) { Destroy(gameObject); }
    }

    public void Interact(Drink drink) {
        switch (currentState) {
            case CustomerState.Ordering:
                canOrder = true;
                break;
            case CustomerState.Waiting:
                Debug.Log(drink.drinkName);
                Debug.Log(info.GetActiveDrink().drinkName);
                if (drink.drinkName == info.GetActiveDrink().drinkName) stopWaiting = true;
                break;
        }
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
