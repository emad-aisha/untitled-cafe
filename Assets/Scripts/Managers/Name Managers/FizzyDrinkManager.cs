/*
using UnityEngine;
public class FizzyDrinkManager : MonoBehaviour {
    public static FizzyDrinkManager instance;
    enum Costs {
        Nothing = 0,
        RegularSoda = 3,
        FlavoredSoda = 4,
        Mohito = 6
    };

    void Start() { if (instance == null) instance = this; }


    public void SetFinalDrinkName(FizzyDrink fizzyDrink) {
        string finalName = GetSoda(fizzyDrink);
        string flavor = GetFlavor(fizzyDrink);
        string fruit = GetFruit(fizzyDrink);

        string finalDrinkName = flavor + " " + finalName;
        if (IsFruit(fizzyDrink)) finalDrinkName += " with " + fruit;
        if (finalDrinkName.StartsWith(" ")) finalDrinkName = finalDrinkName.Substring(1);

        MenuManager.instance.SetDrinkInformation("Fizzy Drink", finalDrinkName, 0);
    }
    // helper
    string GetSoda(FizzyDrink fizzyDrink) {
        if (fizzyDrink.GetSoda().GetState((int)SodaType.Soda)) return "Soda";
        return "";
    }
    string GetFlavor(FizzyDrink fizzyDrink) {
        int index = fizzyDrink.GetSyrup().GetAnyStateIndex();
        if (index == -1) return "";
        return ((SyrupType)index).ToString();
    }
    string GetFruit(FizzyDrink fizzyDrink) {
        int index = fizzyDrink.GetFruit().GetAnyStateIndex();
        if (index == -1) return "";
        return ((FruitType)index).ToString();
    }



    public int SetFinalDrinkCost(FizzyDrink fizzyDrink) {
        bool soda = IsSoda(fizzyDrink);
        bool flavor = IsFlavor(fizzyDrink);
        bool fruit = IsFruit(fizzyDrink);

        Costs cost = Costs.Nothing;

        if (soda) cost = Costs.RegularSoda;
        if (flavor) cost = Costs.FlavoredSoda;
        if (fruit) cost = Costs.Mohito;

        MenuManager.instance.SetCost(((int)cost).ToString());

        return (int)cost;
    }
    // helper
    bool IsSoda(FizzyDrink fizzyDrink) {
        if (fizzyDrink.GetSoda().GetState((int)SodaType.Soda)) return true;
        return false;
    }
    bool IsFlavor(FizzyDrink fizzyDrink) {
        int index = fizzyDrink.GetSyrup().GetAnyStateIndex();
        if (index == -1) return false;
        return true;
    }
    bool IsFruit(FizzyDrink fizzyDrink) {
        int index = fizzyDrink.GetFruit().GetAnyStateIndex();
        if (index == -1) return false;
        return true;
    }

}

*/
