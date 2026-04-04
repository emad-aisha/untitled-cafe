
public class CoffeeInfo {
    enum Names {
        Decaf, Espresso,
        Macchiato, Americano,
        Latte, Mocha
    };

    static public int SetCoffeeInformation(Drink drink) {
        CoffeeIngredients costType = CoffeeIngredients.Null;
        string drinkName = GetCoffeeName(drink, ref costType);
        int cost = GetCoffeeCost(costType);

        MenuManager.instance.SetInteractionType("Coffee");
        MenuManager.instance.SetFinalDrink(drinkName);
        MenuManager.instance.SetCost(cost.ToString());

        return cost;
    }
    static public void SetCustomerCoffeeInformation(Drink drink) {
        CoffeeIngredients ignore = CoffeeIngredients.Null;
        string drinkName = GetCoffeeName(drink, ref ignore);

        MenuManager.instance.SetCustomerOrder(drinkName);
    }


    static string GetCoffeeName(Drink drink, ref CoffeeIngredients costType) {
        Ingredient espresso = drink.ingredients[(int)CoffeeIngredients.Espresso];
        Ingredient liquid = drink.ingredients[(int)CoffeeIngredients.Liquid];
        Ingredient extras = drink.ingredients[(int)CoffeeIngredients.Extras];

        int espressoType = espresso.GetAnyStateIndex();
        int liquidType = liquid.GetAnyStateIndex();
        int extrasType = extras.GetAnyStateIndex();

        string espressoName = "";
        string liquidName = "";
        string extrasName = "";
        SetNames(ref espressoName, ref liquidName, ref extrasName, espressoType, liquidType, extrasType);

        return FinalNameLogic(espressoName, liquidName, extrasName, ref costType);
    }
    static void SetNames(ref string espresso, ref string liquid, ref string extras, int espressoType, int liquidType, int extrasType) {
        espresso = (EspressoType)espressoType switch {
            EspressoType.Decaf => Names.Decaf.ToString(),
            EspressoType.Regular => Names.Espresso.ToString(),
            _ => ""
        };

        liquid = (LiquidType)liquidType switch {
            LiquidType.Water => Names.Americano.ToString(),
            LiquidType.Milk => Names.Macchiato.ToString(),
            _ => ""
        };

        extras = (ExtrasType)extrasType switch {
            ExtrasType.MilkFoam => Names.Latte.ToString(),
            ExtrasType.Chocolate => Names.Mocha.ToString(),
            _ => ""
        };
    }
    static string FinalNameLogic(string espresso, string liquid, string extras, ref CoffeeIngredients costType) {
        string finalName = "";
        if (espresso == Names.Decaf.ToString()) { costType = CoffeeIngredients.Espresso; finalName = espresso; }

        if (IsSomething(extras)) { costType = CoffeeIngredients.Extras; finalName += " " + extras; }
        else if (IsSomething(liquid)) { costType = CoffeeIngredients.Liquid; finalName += " " + liquid; }
        else if (IsSomething(espresso)) { costType = CoffeeIngredients.Espresso; finalName = espresso; }

        if (finalName.StartsWith(" ")) finalName = finalName.Substring(1);
        return finalName;
    }


    static int GetCoffeeCost(CoffeeIngredients costType) {
        int cost = costType switch {
            CoffeeIngredients.Espresso => 3,
            CoffeeIngredients.Liquid => 5,
            CoffeeIngredients.Extras => 6,
            _ => 0
        };

        return cost;
    }

    static bool IsSomething(string input) { return input != ""; }
}
