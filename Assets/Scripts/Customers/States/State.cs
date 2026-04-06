using System;
using UnityEngine;

[Serializable]
public class State {
    public Drink[] drinks;
    public int party = 3; // TODO: make randomized
    public Seating personalSeat;

}
