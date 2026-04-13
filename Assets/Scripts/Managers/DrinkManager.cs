using UnityEngine;

public class DrinkManager : MonoBehaviour {
    public static DrinkManager instance;
    void Start() { if (instance == null) instance = this; }

    public Drink GetActiveDrink(Drink[] drinks) {
        for (int i = 0; i < drinks.Length; i++) if (!drinks[i].IsEveryStateOff()) return drinks[i];
        Debug.Log("Couldn't find an active drink"); return null;
    }

    public Drink GetDrink(Drink[] drinks, DrinkType drinkType) {
        for (int i = 0; i < drinks.Length; i++) if (drinks[i].drinkType == drinkType) return drinks[i];
        Debug.Log("Couldn't find the drink");
        return null;
    }
}
