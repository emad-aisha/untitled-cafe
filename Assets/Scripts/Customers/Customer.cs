using UnityEngine;


public enum CustomerState { Idle, Ordering, Waitng, Eating, Leaving, Null };
public class Customer : MonoBehaviour {
    [SerializeField] int party = 3; // TODO: make randomized

    // states
    CustomerState currentState = CustomerState.Idle;
    Idle idleState = new();

    Seating seat;

    // TODO: put in it's own class...
    // possible orders
    public enum DrinkOrder { FizzyDrink, Coffee };
    [SerializeField] DrinkOrder orderChecker;
    [SerializeField] Drink[] drinks;

    Seating personalSeat;


    void Start() {
        CustomerManager.instance.numberOfCustomers++;

    }

    void OnDestroy() {
        CustomerManager.instance.numberOfCustomers--;
    }


    void Update() {
        // TODO: turn into switch
        currentState = currentState switch {
            CustomerState.Idle => idleState.Update(ref seat, ref drinks, party),
            CustomerState.Ordering => CustomerState.Null,
            CustomerState.Waitng => CustomerState.Null,
            CustomerState.Eating => CustomerState.Null,
            CustomerState.Leaving => CustomerState.Null,
            _ => CustomerState.Null
        };

    }
}
