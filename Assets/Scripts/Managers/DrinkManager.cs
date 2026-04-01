using UnityEngine;

public class DrinkManager : MonoBehaviour {
    public static DrinkManager instance;
    void Start() { if (instance == null) instance = this; }

    enum CoffeeDrink {
        Null = 0,
        Espresso = 5,
        EspressoWithLiquid = 7,
        EspressoWith1Extra = 9,
    }
    public int SetFinalDrink(Coffee coffee) {
        CoffeeDrink costType = CoffeeDrink.Null;
        string espresso = GetEspressoType(coffee);
        string liquid = GetLiquid(coffee);
        string final = GetFinal(coffee);

        // TODO: turn into it's own function
        if (espresso == "Decaf" || espresso == "Espresso") costType = CoffeeDrink.Espresso;
        if (liquid == "Americano" || liquid == "Macchiato") costType = CoffeeDrink.EspressoWithLiquid;
        if (final == "Mocha" || final == "Cappucino") costType = CoffeeDrink.EspressoWith1Extra;
        if (espresso == "Espresso") espresso = "";

        string finalDrink = "";
        if (liquid == "Americano") finalDrink = espresso + " " + liquid;
        if (liquid == "") finalDrink = espresso;

        if (liquid == "Macchiato") { finalDrink = espresso + " " + final; }

        MenuManager.instance.SetBaseInteraction("Coffee");
        MenuManager.instance.SetFinalDrink(finalDrink);
        MenuManager.instance.SetCost(((int)costType).ToString());
        return (int)costType;
    }

    string GetEspressoType(Coffee coffee) {
        if (coffee.GetEspresso().hasDecaf) return "Decaf";
        if (coffee.GetEspresso().hasEspresso) return "Espresso";
        return "";
    }
    string GetLiquid(Coffee coffee) {
        if (coffee.GetLiquid().hasWater) return "Americano";
        if (coffee.GetLiquid().hasMilk) return "Macchiato";
        return "";
    }
    string GetFinal(Coffee coffee) {
        if (coffee.GetExtras().hasChocolate) return "Mocha";
        else if (coffee.GetExtras().hasMilkFoam) return "Cappucino";
        return "Macchiato";
    }



    enum FizzyDrink {
        Null = 0,
        RegularSoda = 3,
        FlavoredSoda = 4,
        Mohito = 5
    };
    public int SetFinalDrink(FizzyDrinks fizzyDrink) {
        FizzyDrink costType = FizzyDrink.Null;
        string final = GetFinalDrink(fizzyDrink);
        string syrup = GetSyrup(fizzyDrink);
        string fruit = GetFruit(fizzyDrink);

        if (final == "Soda") costType = FizzyDrink.RegularSoda;
        if (syrup != "") costType = FizzyDrink.FlavoredSoda;
        if (final == "Mohito") costType = FizzyDrink.Mohito;


        string finalDrink = syrup + " " + final + " " + fruit;

        MenuManager.instance.SetBaseInteraction("FizzyDrinks");
        MenuManager.instance.SetFinalDrink(finalDrink);
        MenuManager.instance.SetCost(((int)costType).ToString());
        return (int)costType;
    }

    string GetFinalDrink(FizzyDrinks fizzyDrink) {
        bool hasFruit = fizzyDrink.GetFruit().GetTrue() != Fruit.Type.Null;
        bool hasSoda = fizzyDrink.GetSoda().hasSoda;

        if (hasFruit) { return "Mohito"; }
        else if (hasSoda) { return "Soda"; }
        else return "";
    }
    string GetSyrup(FizzyDrinks fizzyDrink) {
        bool hasSyrup = fizzyDrink.GetSyrup().GetTrue() != Syrup.Type.Null;

        if (hasSyrup) return fizzyDrink.GetSyrup().GetTrue().ToString();
        return "";
    }
    string GetFruit(FizzyDrinks fizzyDrink) {
        bool hasFruit = fizzyDrink.GetFruit().GetTrue() != Fruit.Type.Null;

        if (hasFruit) return "with " + fizzyDrink.GetFruit().GetTrue().ToString();
        else return "";
    }
}
