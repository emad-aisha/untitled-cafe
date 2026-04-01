using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] FizzyDrink myFizzyDrink;
    //[SerializeField] Coffee myCoffee;

    private int currPriority;
    public int currPrice;

    public void Interact(Collider interactable) {
        FizzyDrink inputFizzyDrink = interactable.GetComponent<FizzyDrink>();

        if (inputFizzyDrink != null) {
            inputFizzyDrink.Interact(ref myFizzyDrink, ref currPriority);
            currPrice = DrinkManager.instance.SetFinalDrink(myFizzyDrink);
        }
    }

}
