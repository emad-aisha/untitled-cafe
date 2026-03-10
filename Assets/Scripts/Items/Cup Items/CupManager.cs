using UnityEngine;

public class CupManager : MonoBehaviour {
    private Cup cupObject;

    private Liquid currLiquid;
    private Syrup currSyrup;

    // coffee
    private CoffeeShot currCoffeeShot;
    private CoffeeExtra currCoffeeExtra;

    // toppings
    private Fruit currFruit;
    private Dessert currDessert;
    private Drizzle currDrizzle;




    // getters
    Liquid GetLiquid() { return currLiquid; }
    Syrup GetSyrup()   { return currSyrup; }

    CoffeeShot GetCoffeeShot()   { return currCoffeeShot; }
    CoffeeExtra GetCoffeeExtra() { return currCoffeeExtra; }

    Fruit GetFruit()     { return currFruit; }
    Dessert GetDessert() { return currDessert; }
    Drizzle GetDrizzle() { return currDrizzle; }


    // setters
    void SetLiquid(Liquid newLiquid) { currLiquid = newLiquid; }
    void SetSyrup(Syrup newSyrup)    { currSyrup = newSyrup; }

    void SetCoffeeShot(CoffeeShot newCoffeeShot)    { currCoffeeShot = newCoffeeShot; }
    void SetCoffeeExtra(CoffeeExtra newCoffeeExtra) { currCoffeeExtra = newCoffeeExtra; }

    void SetFruit(Fruit newFruit)       { currFruit = newFruit; }
    void SetDessert(Dessert newDessert) { currDessert = newDessert; }
    void SetDrizzle(Drizzle newDrizzle) { currDrizzle = newDrizzle; }

}
