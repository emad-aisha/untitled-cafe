
public class FizzyDrinkInfo {
    // TODO: can refactor to have the drinkName/cost thing change witch type instead of copy pasting over and over

    static public int SetFizzyDrinkInformation(Drink drink) {
        FizzyDrinkIngredients costType = FizzyDrinkIngredients.Null;
        string drinkName = GetFizzyDrinkName(drink, ref costType);
        int cost = GetFizzyDrinkCost(costType);

        MenuManager.instance.SetInteractionType("FizzyDrink");
        MenuManager.instance.SetFinalDrink(drinkName);
        MenuManager.instance.SetCost(cost.ToString());

        return cost;
    }

    static string GetFizzyDrinkName(Drink drink, ref FizzyDrinkIngredients costType) {
        Ingredient soda = drink.ingredients[(int)FizzyDrinkIngredients.Soda];
        Ingredient syrup = drink.ingredients[(int)FizzyDrinkIngredients.Syrup];
        Ingredient fruit = drink.ingredients[(int)FizzyDrinkIngredients.Fruit];

        int sodaType = soda.GetAnyStateIndex();
        int syrupType = syrup.GetAnyStateIndex();
        int fruitType = fruit.GetAnyStateIndex();

        string sodaName = "";
        string syrupName = "";
        string fruitName = "";

        if (sodaType == (int)SodaType.Soda) sodaName = "Soda";
        if (syrupType >= 0 && syrupType < (int)SyrupType.Count) syrupName = ((SyrupType)syrupType).ToString();
        if (fruitType >= 0 && fruitType < (int)FruitType.Count) fruitName = "with " + ((FruitType)fruitType).ToString();

        string finalName = syrupName + " " + sodaName + " " + fruitName;
        if (finalName.StartsWith(" ")) finalName = finalName.Substring(1);

        return finalName;
    }



    static int GetFizzyDrinkCost(FizzyDrinkIngredients costType) {
        int cost = costType switch {
            FizzyDrinkIngredients.Soda => 3,
            FizzyDrinkIngredients.Syrup => 4,
            FizzyDrinkIngredients.Fruit => 5,
            _ => 0
        };
        return cost;
    }

    static bool IsSomething(string input) { return input != ""; }
}
