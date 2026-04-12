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
    public bool stopWaiting = false;
    public float discountTime = 30; // changes with upgrades
    public float leaveTime = 60;

    [Header("Debugging")]
    public bool isDebugging;
    public Seating personalSeat;
    public Drink[] drinks;
    public CustomerState currentState;

    void Start() {
        // TODO: clean up
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
        if (isDebugging) Debug.Log(drink.drinkName + " and " + GetActiveDrink().drinkName);

        if (drink.drinkName == GetActiveDrink().drinkName) stopWaiting = true;
    }


    // TODO: move into drink instance thing
    public Drink GetDrink(DrinkType drinkType) {
        for (int i = 0; i < drinks.Length; i++) if (drinks[i].drinkType == drinkType) return drinks[i];
        Debug.Log("Couldn't find the drink");
        return null;
    }
    public Drink GetActiveDrink() {
        for (int i = 0; i < drinks.Length; i++) if (drinks[i].drinkName != "") return drinks[i];
        Debug.Log("Customer Info: Couldn't find an active drink");
        return null;
    }

    public float GetRandomWaitTime() {
        if (isDebugging) return 0.5f;
        return UnityEngine.Random.Range(minTime, maxTime);
    }
}
