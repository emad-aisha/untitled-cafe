using UnityEngine;

public class Inventory : MonoBehaviour {
    // cup item
    public Cup cup;
    [SerializeField] FizzyDrinks myFizzyDrink;


    void Start() { SetBaseCup(); }

    // setters
    void SetBaseCup() { cup = new Cup(myFizzyDrink, 0); }

}
