using System;
using UnityEngine;

[Serializable]
public class CustomerInformation {
    public Drink[] drinks;
    public int party; // TODO: make randomized
    public Seating personalSeat;

    public bool isDebugging;


    public Drink GetDrink(DrinkType drinkType) {
        for (int i = 0; i < drinks.Length; i++) if (drinks[i].drinkType == drinkType) return drinks[i];
        Debug.Log("Couldn't find the drink");
        return null;
    }

    public Drink GetActiveDrink() {
        for (int i = 0; i < drinks.Length; i++) if (!drinks[i].IsEveryStateOff()) return drinks[i];
        Debug.Log("Couldn't find an active drink");
        return null;
    }
}
