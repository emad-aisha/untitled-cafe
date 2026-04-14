using UnityEngine;

public class FizzyDrinkManager : Name {
    FizzyDrinkIngredients costType;

    public override string SetName(Drink drink) {
        Ingredient soda = drink.ingredients.At(FizzyDrinkIngredients.Soda);
        Ingredient syrup = drink.ingredients.At(FizzyDrinkIngredients.Syrup);
        Ingredient fruit = drink.ingredients.At(FizzyDrinkIngredients.Fruit);

        int sodaType = soda.GetAnyStateIndex();
        int syrupType = syrup.GetAnyStateIndex();
        int fruitType = fruit.GetAnyStateIndex();

        SetCostType(sodaType, syrupType, fruitType);
        return FinalDrinkLogic(sodaType, syrupType, fruitType);
    }

    public override float SetCost() {
        float cost = costType switch {
            FizzyDrinkIngredients.Soda => 3,
            FizzyDrinkIngredients.Syrup => 4,
            FizzyDrinkIngredients.Fruit => 5,
            _ => 0
        };
        return cost;
    }

    // helper
    string FinalDrinkLogic(int sodaType, int syrupType, int fruitType) {
        string finalDrink = "";

        // TODO: refactor
        if (sodaType == (int)SodaType.Soda) finalDrink = "Soda";
        if (syrupType >= 0 && syrupType < (int)SyrupType.Count) finalDrink = ((SyrupType)syrupType).ToString() + " " + finalDrink;
        if (fruitType >= 0 && fruitType < (int)FruitType.Count) finalDrink += " with " + ((FruitType)fruitType).ToString();

        if (finalDrink.StartsWith(" ")) finalDrink = finalDrink.Substring(1);

        return finalDrink;
    }

    void SetCostType(int sodaType, int syrupType, int fruitType) {
        if (sodaType != -1) costType = FizzyDrinkIngredients.Soda;
        if (syrupType != -1) costType = FizzyDrinkIngredients.Syrup;
        if (fruitType != -1) costType = FizzyDrinkIngredients.Fruit;
    }

}
