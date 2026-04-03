using UnityEngine;


public enum CustomerState { Idle, Ordering, Waitng, Eating, Leaving, Null };
public class Customer : MonoBehaviour {
    //parties of 1,2,3 (for num of chairs)

    // states
    CustomerState currentState = CustomerState.Idle;
    Idle idleState = new();

    Seating seat;

    // TODO: put in it's own class
    // possible orders
    [SerializeField] FizzyDrink fizzyDrinkOrder;
    [SerializeField] Coffee coffeeOrder;

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
            CustomerState.Idle => idleState.Update(ref seat, ref fizzyDrinkOrder, ref coffeeOrder),
            CustomerState.Ordering => CustomerState.Null,
            CustomerState.Waitng => CustomerState.Null,
            CustomerState.Eating => CustomerState.Null,
            CustomerState.Leaving => CustomerState.Null,
            _ => CustomerState.Null
        };

    }
}
