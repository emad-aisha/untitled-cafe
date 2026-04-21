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
    //public Drink[] drinks;
    public CustomerState currentState;

}
