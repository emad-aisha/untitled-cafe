using UnityEngine;
/*

public class DrinkManager : MonoBehaviour {
    public static DrinkManager instance;
    void Start() { if (instance == null) instance = this; }

    // TODO: refactor
    enum FizzyDrinkCosts {
        Null = 0,
        RegularSoda = 3,
        FlavoredSoda = 4,
        Mohito = 5
    };
    public int SetFinalDrink(FizzyDrink fizzyDrink) {
        FizzyDrinkCosts cost = FizzyDrinkCosts.Null;
        string finalDrink = GetFinalDrinkName(fizzyDrink);
        string syrup = GetSyrupName(fizzyDrink);
        string fruit = GetFruitName(fizzyDrink);

        cost = GetCost(finalDrink, syrup);

        string finalDrinkName = syrup + " " + finalDrink + " " + fruit;
        if (finalDrinkName.StartsWith(" ")) finalDrinkName = finalDrinkName.Substring(1);

        MenuManager.instance.SetDrinkInformation("FizzyDrinks", finalDrinkName, (int)cost);
        return (int)cost;
    }

    // name
    string GetFinalDrinkName(FizzyDrink fizzyDrink) {
        bool hasFruit = fizzyDrink.GetFruit().HasState();
        bool hasSoda = fizzyDrink.GetSoda().HasState();

        if (hasFruit) { return "Mohito"; }
        else if (hasSoda) { return "Soda"; }
        else return "";
    }
    string GetSyrupName(FizzyDrink fizzyDrink) {
        bool hasSyrup = fizzyDrink.GetSyrup().HasState();

        if (hasSyrup) return fizzyDrink.GetSyrup().GetState().ToString();
        return "";
    }
    string GetFruitName(FizzyDrink fizzyDrink) {
        bool hasFruit = fizzyDrink.GetFruit().HasState();

        if (hasFruit) return "with " + fizzyDrink.GetFruit().GetState().ToString();
        else return "";
    }

    // pricing
    FizzyDrinkCosts GetCost(string finalDrinkName, string syrupName) {
        FizzyDrinkCosts finalCost = FizzyDrinkCosts.Null;
        if (finalDrinkName == "Soda") finalCost = FizzyDrinkCosts.RegularSoda;
        if (syrupName != "") finalCost = FizzyDrinkCosts.FlavoredSoda;

        if (finalDrinkName == "Mohito") finalCost = FizzyDrinkCosts.Mohito;

        return finalCost;
    }
}
*/
