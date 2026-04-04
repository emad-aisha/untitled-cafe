using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] Drink myFizzyDrink;
    [SerializeField] Drink myCoffee;

    private int currPriority;
    public int currPrice;


    public void Interact(Collider interactable) {
        // TODO: see if i can use one drink
        FizzyDrink inputFizzyDrink = interactable.GetComponent<FizzyDrink>();
        Coffee inputCoffee = interactable.GetComponent<Coffee>();

        if (inputFizzyDrink != null && myCoffee.IsEveryStateOff()) {
            inputFizzyDrink.Interact(ref myFizzyDrink, ref currPriority);
            currPrice = DrinkNameManager.instance.SetDrinkName(myFizzyDrink, NameType.FizzyDrink);
        }

        if (inputCoffee != null) {
            inputCoffee.Interact(ref myCoffee, ref currPriority);
            currPrice = DrinkNameManager.instance.SetDrinkName(inputCoffee, NameType.Coffee);
        }
    }

}
