using UnityEngine;

public class CoffeeManager : Name {
    public CoffeeManager(Drink drink) : base(drink) { }

    // setters
    public override string SetName(Drink drink) {
        SetIngredientTypes(drink);
        return FinalDrinkLogic();
    }

    public override float SetCost() {
        float price = GetCostType<CoffeeIngredients>() switch {
            CoffeeIngredients.Espresso => 3,
            CoffeeIngredients.Liquid => 5,
            CoffeeIngredients.Extras => 7,
            _ => 0
        };

        if (price == 0) Debug.Log("Error with Price");
        return price;
    }

    // helper
    protected override void SetIngredientTypes(Drink drink) {
        if (types == null) types = new int[drink.ingredients.Length];

        types.At(CoffeeIngredients.Espresso) = drink.ingredients.At(CoffeeIngredients.Espresso).GetActiveStateIndex();
        types.At(CoffeeIngredients.Liquid) = drink.ingredients.At(CoffeeIngredients.Liquid).GetActiveStateIndex();
        types.At(CoffeeIngredients.Extras) = drink.ingredients.At(CoffeeIngredients.Extras).GetActiveStateIndex();
    }

    protected override string FinalDrinkLogic() {
        string finalName = "";

        if (types.At(CoffeeIngredients.Espresso) == (int)EspressoType.Decaf) finalName = "Decaf ";

        if (types.At(CoffeeIngredients.Extras) != -1) {
            switch ((ExtrasType)types.At(CoffeeIngredients.Extras)) {
                case ExtrasType.MilkFoam: finalName += "Latte"; break;
                case ExtrasType.Chocolate: finalName += "Mocha"; break;
                default: Debug.Log("error"); break;
            }
        }
        else if (types.At(CoffeeIngredients.Liquid) != -1) {
            switch ((LiquidType)types.At(CoffeeIngredients.Liquid)) {
                case LiquidType.Milk: finalName += "Macchiato"; break;
                case LiquidType.Water: finalName += "Americano"; break;
                default: Debug.Log("error"); break;
            }
        }
        else if (types.At(CoffeeIngredients.Espresso) != -1) {
            switch ((EspressoType)types.At(CoffeeIngredients.Espresso)) {
                case EspressoType.Decaf: finalName = "Decaf Espresso"; break;
                case EspressoType.Espresso: finalName = "Espresso"; break;
                default: Debug.Log("error"); break;
            }
        }

        if (finalName.StartsWith(" ")) finalName = finalName.Substring(1);

        return finalName;
    }
}
