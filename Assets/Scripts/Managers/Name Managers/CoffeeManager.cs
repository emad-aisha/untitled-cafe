using UnityEngine;

public class CoffeeManager : MonoBehaviour {
    static public CoffeeManager instance;
    enum Drinks {
        Nothing = 0,
        Espresso = 3,
        Liquid = 5,
        Extra = 6
    };


    void Start() { if (instance == null) instance = this; }

    public void SetFinalDrinkName(Coffee coffee) {
        string espresso = GetEspresso(coffee);
        string liquid = GetLiquid(coffee);
        string extra = GetExtra(coffee);

        string finalDrinkName = "";
        if (espresso != "") finalDrinkName = espresso;
        if (espresso == "Decaf") {
            if (liquid != "") finalDrinkName = espresso + " " + liquid;
            if (extra != "") finalDrinkName = espresso + " " + extra;
        }
        else {
            if (liquid != "") finalDrinkName = liquid;
            if (extra != "") finalDrinkName = extra;
        }

        MenuManager.instance.SetDrinkInformation("Coffee", finalDrinkName, 0);
    }

    public int SetFinalDrinkCost(Coffee coffee) {
        Drinks cost = Drinks.Nothing;

        string espresso = GetEspresso(coffee);
        string liquid = GetLiquid(coffee);
        string extra = GetExtra(coffee);

        if (espresso != "") cost = Drinks.Espresso;
        if (liquid != "") cost = Drinks.Liquid;
        if (extra != "") cost = Drinks.Extra;

        MenuManager.instance.SetCost(((int)cost).ToString());
        return (int)cost;
    }


    string GetEspresso(Coffee coffee) {
        if (coffee.GetEspresso().GetState((int)EspressoType.Decaf)) return "Decaf";
        return "Espresso";
    }
    string GetLiquid(Coffee coffee) {
        if (coffee.GetLiquid().GetState((int)LiquidType.Water)) return "Americano";
        if (coffee.GetLiquid().GetState((int)LiquidType.Milk)) return "Machiatto";
        return "";
    }
    string GetExtra(Coffee coffee) {
        if (coffee.GetExtras().GetState((int)ExtrasType.Chocolate)) return "Mocha";
        if (coffee.GetExtras().GetState((int)ExtrasType.MilkFoam)) return "Cappucino";
        return "";
    }

}
