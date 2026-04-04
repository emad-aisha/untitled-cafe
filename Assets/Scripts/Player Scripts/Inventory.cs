using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] Drink myFizzyDrink;
    [SerializeField] Drink myCoffee;

    private int currPriority;
    public int currPrice;


    public void Interact(Collider interactable) {
        FizzyDrink inputFizzyDrink = interactable.GetComponent<FizzyDrink>();
        Coffee inputCoffee = interactable.GetComponent<Coffee>();

        if (inputFizzyDrink != null && myCoffee.IsEveryStateOff()) {
            inputFizzyDrink.Interact(ref myFizzyDrink, ref currPriority);
            // TODO: fix this
            //currPrice = FizzyDrinkManager.instance.SetFinalDrinkCost(myFizzyDrink);
        }

        if (inputCoffee != null) {
            inputCoffee.Interact(ref myCoffee, ref currPriority);
            //currPrice = CoffeeManager.instance.SetFinalDrinkCost(myCoffee);
        }
    }

}
