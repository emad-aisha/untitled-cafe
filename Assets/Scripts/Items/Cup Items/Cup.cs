using UnityEngine;

public class Cup : MonoBehaviour {
    private Liquid liquid;
    private Syrup syrup;

    // coffee
    private CoffeeShot coffeeShot;
    private CoffeeExtra coffeeExtra;

    // toppings
    private Fruit fruit;
    private Dessert dessert;
    private Drizzle drizzle;



    // getters
    Liquid GetLiquid() { return liquid; }
    Syrup GetSyrup()   { return syrup; }

    CoffeeShot GetCoffeeShot()   { return coffeeShot; }
    CoffeeExtra GetCoffeeExtra() { return coffeeExtra; }

    Fruit GetFruit()     { return fruit; }
    Dessert GetDessert() { return dessert; }
    Drizzle GetDrizzle() { return drizzle; }

    // setters
    void SetLiquid(Liquid newLiquid) { liquid = newLiquid; }
    void SetSyrup(Syrup newSyrup)    { syrup = newSyrup; }

    void SetCoffeeShot(CoffeeShot newCoffeeShot)    { coffeeShot = newCoffeeShot; }
    void SetCoffeeExtra(CoffeeExtra newCoffeeExtra) { coffeeExtra = newCoffeeExtra; }

    void SetFruit(Fruit newFruit)       { fruit = newFruit; }
    void SetDessert(Dessert newDessert) { dessert = newDessert; }
    void SetDrizzle(Drizzle newDrizzle) { drizzle = newDrizzle; }
}
