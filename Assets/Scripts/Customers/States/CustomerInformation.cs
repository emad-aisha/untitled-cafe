using System;

[Serializable]
public class CustomerInformation {
    public Drink[] drinks;
    public int party; // TODO: make randomized
    public Seating personalSeat;

    public bool isDebugging;
}
