using System;
using UnityEngine;

[Serializable]
public class CustomerInformation : MonoBehaviour {
    [Header("General")]
    [SerializeField] GameObject drinkObject;
    public int party; // TODO: make randomized

    [Header("Idle State - Timer")]
    [Range(0.5f, 1f)] public float minTime;
    [Range(5f, 20f)] public float maxTime;
    public float waitTime;

    [Header("Ordering State - Debugging")]
    public bool canOrder = false;

    [Header("Waiting State - Debugging")]
    public float tip;
    public bool stopWaiting = false;

    public float discountTime = 30; // changes with upgrades
    public float leaveTime = 60;

    [Header("Eating")]
    public float eatingTime = 5; // TODO: randomize

    [Header("Leaving")]
    public float leavingTime = 2; // TODO: randomize

    [Header("Debugging")]
    public GameObject customer;
    public bool isDebugging;
    public Seating personalSeat;
    public Drink[] drinks;
    public CustomerState currentState;

    void Start() {
        // TODO: clean up
        customer = gameObject;
        if (leaveTime < discountTime) leaveTime = discountTime + 30;

        currentState = CustomerState.Idle;
        waitTime = GetRandomWaitTime();

        drinks = new Drink[(int)DrinkType.Count];

        drinks[(int)DrinkType.FizzyDrink] = drinkObject.GetComponent<FizzyDrink>();
        drinks[(int)DrinkType.Coffee] = drinkObject.GetComponent<Coffee>();
    }


    // state helpers
    public void CanOrder() { canOrder = true; }
    public void StopWaiting(Drink drink) {
        if (drink == null) { Debug.Log("no drink lol"); return; }
        if (isDebugging) Debug.Log(drink.drinkName + " and " + DrinkManager.instance.GetActiveDrink(drinks).drinkName);

        // TODO: implement wrong drink check
        if (drink.drinkName == DrinkManager.instance.GetActiveDrink(drinks).drinkName) stopWaiting = true;
    }

    public Drink GetActiveDrink() { return DrinkManager.instance.GetActiveDrink(drinks); }
    public Drink GetDrink(DrinkType drinkType) { return DrinkManager.instance.GetDrink(drinks, drinkType); }

    public float GetRandomWaitTime() {
        if (isDebugging) return 0.5f;
        return UnityEngine.Random.Range(minTime, maxTime);
    }
}
