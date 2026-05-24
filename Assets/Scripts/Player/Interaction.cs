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
            activeDrink = InteractionManager.instance.GetDrinkType(drinks, otherDrink.ingredientData.Type);
        }
        else activeDrink = InteractionManager.instance.GetActiveDrink(drinks);

        activeDrink.Interact(otherDrink, ref currPriority);
    }

}
