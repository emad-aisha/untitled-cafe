using UnityEngine;

public class CustomerManager : MonoBehaviour {
    static public CustomerManager instance;

    public int numberOfCustomers = 0;
    public Seating[] seats;

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
    public Seating GetFreeTable(int preferedNumOfChairs) {
        int closestIndex = -1;
        int smallestNumOfChairs = 100; // arbitrary long number

        // get table with closest num of chairs
        for (int i = 0; i < seats.Length; i++) {
            if (seats[i].numberOfChairs >= preferedNumOfChairs && seats[i].numberOfChairs < smallestNumOfChairs && seats[i].isFree) {
                closestIndex = i;
                smallestNumOfChairs = seats[closestIndex].numberOfChairs;
            }
        }


        if (closestIndex == -1) { Debug.Log("couldn't find a seat"); return null; }
        else {
            seats[closestIndex].isFree = false;
            return seats[closestIndex];
        }
    }


    // helpers
}
