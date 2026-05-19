using UnityEngine;

public class Interaction : MonoBehaviour {
    [SerializeField] Drink[] drinks;
    [SerializeField] private int currPriority;

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
        if (!InteractionManager.instance.CanInteract(drinks, otherDrink)) return;
        Drink activeDrink;

        if (InteractionManager.instance.GetActiveDrinkIndex(drinks) == -1) {
            if (otherDrink is Coffee) activeDrink = InteractionManager.instance.GetDrinkType<Coffee>(drinks);
            else if (otherDrink is FizzyDrink) activeDrink = InteractionManager.instance.GetDrinkType<FizzyDrink>(drinks);
            else throw new System.Exception("No Matching Drink Type");
        }
        else activeDrink = InteractionManager.instance.GetActiveDrink(drinks);

        activeDrink.Interact(otherDrink, ref currPriority);
        InteractionManager.instance.GetDrinkType<FizzyDrink>(drinks) = activeDrink;

        Debug.Log("drink");
    }

}
