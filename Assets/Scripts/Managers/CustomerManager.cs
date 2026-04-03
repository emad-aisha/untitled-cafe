using UnityEngine;

public class CustomerManager : MonoBehaviour {
    static public CustomerManager instance;

    public int numberOfCustomers = 0;
    public Seating[] seats; // TODO: sorted from smalllest NO of chairs to largest

    void Awake() {
        if (instance == null) instance = this;
        SetSeats();
    }


    // setters
    void SetSeats() {
        GameObject[] seatingObjects = GameObject.FindGameObjectsWithTag("Seat");

        seats = new Seating[seatingObjects.Length];
        for (int i = 0; i < seatingObjects.Length; i++) { seats[i] = seatingObjects[i].GetComponent<Seating>(); }
    }

    // getters
    public Seating GetFreeTable() {
        for (int i = 0; i < seats.Length; i++) {
            if (seats[i].IsFree) {
                seats[i].IsFree = false;
                return seats[i];
            }
        }
        Debug.Log("couldn't find a seat");
        return null;
    }

}
