using UnityEngine;


public class InteractionManager : MonoBehaviour {
    public static InteractionManager instance;

    void Start() { if (instance == null) instance = this; }

    public bool CanInteract(Drink[] drinks, Drink otherDrink) {
        if (OtherDrinksActive(drinks))
            if (otherDrink.ingredientData.Type != drinks[GetActiveDrinkIndex(drinks)].ingredientData.Type) return false;
        return true;
    }


    public ref Drink GetActiveDrink(Drink[] drinks) {
        int index = GetActiveDrinkIndex(drinks);
        if (index == -1) throw new System.Exception("No Active Drink");
        return ref drinks[index];
    }

    public ref Drink GetDrinkType<Type>(Drink[] drinks) {
        for (int i = 0; i < drinks.Length; i++) {
            if (drinks[i] is Type) return ref drinks[i];
        }
        throw new System.Exception("No Matching Drink Type");
    }


    public int GetActiveDrinkIndex(Drink[] drinks) {
        for (int i = 0; i < drinks.Length; i++) { if (drinks[i].IsActive()) return i; }
        return -1;
    }

    bool OtherDrinksActive(Drink[] drinks) {
        foreach (Drink drink in drinks) { if (drink.IsActive()) return true; }
        return false;
    }


}
