using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] FizzyDrink myFizzyDrink;
    [SerializeField] Coffee myCoffee;

    private int currPriority;
    public int currPrice;


    public void Interact(Collider interactable) {
        FizzyDrink inputFizzyDrink = interactable.GetComponent<FizzyDrink>();
        Coffee inputCoffee = interactable.GetComponent<Coffee>();

        if (inputFizzyDrink != null && myCoffee.IsEveryStateOff()) {
            inputFizzyDrink.Interact(ref myFizzyDrink, ref currPriority);
            currPrice = FizzyDrinkManager.instance.SetFinalDrinkCost(myFizzyDrink);
        }
        if (inputCoffee != null && myFizzyDrink.IsEveryStateOff()) {
            inputCoffee.Interact(ref myCoffee, ref currPriority);
            currPrice = CoffeeManager.instance.SetFinalDrinkCost(myCoffee);
        }
    }

}
