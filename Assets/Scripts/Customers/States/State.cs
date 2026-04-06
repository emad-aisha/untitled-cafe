using System;
using UnityEngine;

public enum CustomerState { Idle, Ordering, Waitng, Eating, Leaving, Null };
[Serializable]
public class State {
    // TODO: maybe change some to protected
    [SerializeField] public Drink[] drinks;
    [SerializeField] public int party = 3; // TODO: make randomized

    public Seating personalSeat;


}
