using UnityEngine;

public class Interaction : MonoBehaviour {
    [SerializeField] Drink[] drinks;
    private int currPriority;


    public void Interact(Collider interactable) {
        Customer customer = interactable.GetComponent<Customer>();
        Drink drink = interactable.GetComponent<Drink>();

        if (customer) CustomerSystem(customer);
        if (drink) DrinkSystem(drink);
    }

    void CustomerSystem(Customer customer) {
        Debug.Log("customer");
    }

    void DrinkSystem(Drink otherDrink) {
        if (OtherDrinksActive())
            if (otherDrink.ingredientData.Type != drinks[GetActiveDrinkIndex()].ingredientData.Type) return;

        Debug.Log("drink");
    }



    int GetActiveDrinkIndex() {
        for (int i = 0; i < drinks.Length; i++) {
            if (drinks[i].IsActive()) return i;
        }
        return -1;
    }

    bool OtherDrinksActive() {
        foreach (Drink dirnk in drinks) {
            if (dirnk.IsActive()) return true;
        }
        return false;
    }
}
