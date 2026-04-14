using UnityEngine;

public class CoffeeManager : Name {
    // TODO: fix how this is worked
    CoffeeIngredients costType;
    // setters
    public override string SetName(Drink drink) {
        Ingredient espresso = drink.ingredients.At(CoffeeIngredients.Espresso);
        Ingredient liquid = drink.ingredients.At(CoffeeIngredients.Liquid);
        Ingredient extras = drink.ingredients.At(CoffeeIngredients.Extras);

        int espressoState = espresso.GetAnyStateIndex();
        int liquidState = liquid.GetAnyStateIndex();
        int extrasState = extras.GetAnyStateIndex();

        return DrinkNameLogic(espressoState, liquidState, extrasState);
    }

    public override float SetCost() {
        float price = costType switch {
            CoffeeIngredients.Espresso => 3,
            CoffeeIngredients.Liquid => 5,
            CoffeeIngredients.Extras => 7,
            _ => 0
        };

        if (price == 0) Debug.Log("Error with Price");
        return price;
    }

    // helper
    string DrinkNameLogic(int espressoState, int liquidState, int extrasState) {
        string finalName = "";
        if ((EspressoType)espressoState == EspressoType.Decaf) finalName = "Decaf ";

        if (extrasState != -1) {
            costType = CoffeeIngredients.Extras;
            switch ((ExtrasType)extrasState) {
                case ExtrasType.MilkFoam: finalName += "Latte"; break;
                case ExtrasType.Chocolate: finalName += "Mocha"; break;
                default: Debug.Log("error"); break;
            }
        }
        else if (liquidState != -1) {
            costType = CoffeeIngredients.Liquid;
            switch ((LiquidType)liquidState) {
                case LiquidType.Milk: finalName += "Macchiato"; break;
                case LiquidType.Water: finalName += "Americano"; break;
                default: Debug.Log("error"); break;
            }
        }
        else if (espressoState != -1) {
            costType = CoffeeIngredients.Espresso;
            switch ((EspressoType)espressoState) {
                case EspressoType.Decaf: finalName = "Decaf Espresso"; break;
                case EspressoType.Espresso: finalName = "Espresso"; break;
                default: Debug.Log("error"); break;
            }
        }

        if (finalName.StartsWith(" ")) finalName = finalName.Substring(1);
        return finalName;
    }
}
