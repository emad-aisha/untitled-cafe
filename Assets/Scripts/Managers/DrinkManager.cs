using UnityEngine;

public class DrinkManager : MonoBehaviour {
    public static DrinkManager instance;

    void Start() {
        if (instance == null) instance = this;
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
