using UnityEngine;

public class FizzyDrinkManager : Name {
    public FizzyDrinkManager(Drink drink) : base(drink) { }

    // TODO: refactor?
    public override string SetName(Drink drink) {
        SetIngredientTypes(drink);
        return FinalDrinkLogic();
    }

    public override float SetCost() {
        float cost = GetCostType<FizzyDrinkIngredients>() switch {
            FizzyDrinkIngredients.Soda => 3,
            FizzyDrinkIngredients.Syrup => 4,
            FizzyDrinkIngredients.Fruit => 5,
            _ => 0
        };
        return cost;
    }

    // helper
    protected override void SetIngredientTypes(Drink drink) {
        if (types == null) types = new int[drink.ingredients.Length];

        int sodaType = drink.ingredients.At(FizzyDrinkIngredients.Soda).GetActiveStateIndex();
        int syrupType = drink.ingredients.At(FizzyDrinkIngredients.Syrup).GetActiveStateIndex();
        int fruitType = drink.ingredients.At(FizzyDrinkIngredients.Fruit).GetActiveStateIndex();

        types.At(FizzyDrinkIngredients.Soda) = sodaType;
        types.At(FizzyDrinkIngredients.Syrup) = syrupType;
        types.At(FizzyDrinkIngredients.Fruit) = fruitType;
    }

    // TODO: refactor
    protected override string FinalDrinkLogic() {
        string finalDrink = "";

        if (InRange(types.At(FizzyDrinkIngredients.Soda), SodaType.Count)) finalDrink = "Soda";

        if (InRange(types.At(FizzyDrinkIngredients.Syrup), SyrupType.Count))
            finalDrink = ((SyrupType)types.At(FizzyDrinkIngredients.Syrup)).ToString() + " " + finalDrink;

        if (InRange(types.At(FizzyDrinkIngredients.Fruit), FruitType.Count))
            finalDrink += " with " + ((FruitType)types.At(FizzyDrinkIngredients.Fruit)).ToString();

        if (finalDrink.StartsWith(" ")) finalDrink = finalDrink.Substring(1);
        return finalDrink;
    }

}
