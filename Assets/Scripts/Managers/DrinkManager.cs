using UnityEngine;

public class DrinkManager : MonoBehaviour {
    public static DrinkManager instance;

    void Start() { if (instance == null) instance = this; }

    public void SetFinalCoffeeDrink(Coffee coffee) {
        string espresso = GetEspressoType(coffee);
        string liquid = GetLiquid(coffee);
        string final = GetFinal(coffee);

        string finalDrink = "";
        if (liquid == "Americano") finalDrink = espresso + " " + liquid;
        if (liquid == "") finalDrink = espresso;

        if (liquid == "Milk") { finalDrink = espresso + " " + final; }

        MenuManager.instance.SetBaseInteraction("Coffee");
        MenuManager.instance.SetFinalDrink(finalDrink);
    }

    string GetEspressoType(Coffee coffee) {
        if (coffee.GetEspresso().hasDecaf) return "Decaf";
        return "";
    }
    string GetLiquid(Coffee coffee) {
        if (coffee.GetLiquid().hasWater) return "Americano";
        if (coffee.GetLiquid().hasMilk) return "Milk";
        return "";
    }
    string GetFinal(Coffee coffee) {
        if (coffee.GetExtras().hasChocolate) return "Mocha";
        else if (coffee.GetExtras().hasMilkFoam) return "Cappucino";
        return "Macchiato";
    }


    public void SetFinalFizzyDrink(FizzyDrinks fizzyDrink) {
        string final = GetFinalDrink(fizzyDrink);
        string syrup = GetSyrup(fizzyDrink);
        string fruit = GetFruit(fizzyDrink);

        string finalDrink = syrup + " " + final + " " + fruit;

        MenuManager.instance.SetBaseInteraction("FizzyDrinks");
        MenuManager.instance.SetFinalDrink(finalDrink);
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
