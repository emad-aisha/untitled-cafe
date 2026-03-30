using UnityEngine;

public class Inventory : MonoBehaviour {
    // cup item
    public Cup cup;
    [SerializeField] FizzyDrinks myFizzyDrink;
    [SerializeField] Coffee myCoffee;


    void Start() { SetBaseCup(); }

    // setters
    void SetBaseCup() {
        cup = new Cup(myFizzyDrink, myCoffee, 0);
    }

}
