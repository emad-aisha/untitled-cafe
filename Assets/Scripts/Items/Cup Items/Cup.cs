using UnityEngine;

public class Cup {
    public Liquid.LiquidType liquid;
    public Syrup.SyrupType syrup;

    // coffee
    public CoffeeShot.CoffeeShotType coffeeShot;
    public CoffeeExtra.CoffeeExtraType coffeeExtra;

    // toppings
    public Fruit.FruitType fruit;
    public Dessert.DessertType dessert;
    public Drizzle.DrizzleType drizzle;

    public Cup() {
        liquid = Liquid.LiquidType.Null;
        syrup = Syrup.SyrupType.Null;

        coffeeShot = CoffeeShot.CoffeeShotType.Null;
        coffeeExtra = CoffeeExtra.CoffeeExtraType.Null;

        fruit = Fruit.FruitType.Null;
        dessert = Dessert.DessertType.Null;
        drizzle = Drizzle.DrizzleType.Null;
    }

}
