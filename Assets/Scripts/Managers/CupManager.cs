using UnityEngine;

public class CupManager : MonoBehaviour {
    static public CupManager instance;

    Cup cupObject;

    Liquid currLiquid;
    Syrup currSyrup;

    // coffee
    CoffeeShot currCoffeeShot;
    CoffeeExtra currCoffeeExtra;

    // toppings
    Fruit currFruit;
    Dessert currDessert;
    Drizzle currDrizzle;
    

    void Start() {
        if (instance) instance = this;


    }


}
