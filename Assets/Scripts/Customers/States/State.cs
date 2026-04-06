using UnityEngine;


public class State {
    public Drink GetDrink(DrinkType drinkType, Drink[] drinks) {
        for (int i = 0; i < drinks.Length; i++) if (drinks[i].drinkType == drinkType) return drinks[i];

        Debug.Log("Couldn't find the drink");
        return null;
    }

    public Drink GetActiveDrink(Drink[] drinks) {
        for (int i = 0; i < drinks.Length; i++) if (!drinks[i].IsEveryStateOff()) return drinks[i];

        Debug.Log("Couldn't find an active drink");
        return null;
    }
}
