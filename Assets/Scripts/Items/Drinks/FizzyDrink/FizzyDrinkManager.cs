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

        types.At(FizzyDrinkIngredients.Soda) = drink.ingredients.At(FizzyDrinkIngredients.Soda).GetActiveStateIndex();
        types.At(FizzyDrinkIngredients.Syrup) = drink.ingredients.At(FizzyDrinkIngredients.Syrup).GetActiveStateIndex();
        types.At(FizzyDrinkIngredients.Fruit) = drink.ingredients.At(FizzyDrinkIngredients.Fruit).GetActiveStateIndex();
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
