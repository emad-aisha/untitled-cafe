using UnityEngine;

public class Idle {
    float waitTimer = 2; // TODO: randomize
    float internalTimer = 0;

    public Idle() { }

    public CustomerState Update(ref Seating seat, ref Drink[] drinks, int party) {
        if (internalTimer < waitTimer) internalTimer += Time.deltaTime;
        else {
            seat = CustomerManager.instance.GetFreeTable(party);
            if (seat == null) return CustomerState.Leaving;

            RandomizeDrink(ref drinks);
            internalTimer = 0;

            return CustomerState.Ordering;
        }
        return CustomerState.Idle;
    }

    void RandomizeDrink(ref Drink[] drinks) {
        DrinkType drinkChosen = (DrinkType)Random.Range(0, (int)DrinkType.Count);
        CoffeeManager coffeeManager = new();
        FizzyDrinkManager fizzyDrinkManager = new();

        // TODO: organize and refactor
        int[] ingredientMaxes;
        switch (drinkChosen) {
            case DrinkType.FizzyDrink:
                ingredientMaxes = new int[3];
                SetFizzyDrink(ref ingredientMaxes, ref drinks);

                Debug.Log(fizzyDrinkManager.SetName(drinks[(int)DrinkType.FizzyDrink]));
                MenuManager.instance.SetCustomerOrder(fizzyDrinkManager.SetName(drinks[(int)DrinkType.FizzyDrink]));
                break;
            case DrinkType.Coffee:
                ingredientMaxes = new int[3];
                SetCoffee(ref ingredientMaxes, ref drinks);

                Debug.Log(coffeeManager.SetName(drinks[(int)DrinkType.Coffee]));
                MenuManager.instance.SetCustomerOrder(coffeeManager.SetName(drinks[(int)DrinkType.Coffee]));
                break;
            default: Debug.Log("Didn't Randomize"); break;
        }
        MenuManager.instance.SetCustomerOrder("Ready");

    }

    void SetFizzyDrink(ref int[] ingredientMaxes, ref Drink[] drinks) {
        ingredientMaxes[(int)FizzyDrinkIngredients.Soda] = (int)SodaType.Count;
        ingredientMaxes[(int)FizzyDrinkIngredients.Syrup] = (int)SyrupType.Count;
        ingredientMaxes[(int)FizzyDrinkIngredients.Fruit] = (int)FruitType.Count;

        drinks[(int)Customer.DrinkOrder.FizzyDrink].RandomizeDrink(ingredientMaxes);
    }

    void SetCoffee(ref int[] ingredientMaxes, ref Drink[] drinks) {
        ingredientMaxes[(int)CoffeeIngredients.Espresso] = (int)EspressoType.Count;
        ingredientMaxes[(int)CoffeeIngredients.Liquid] = (int)LiquidType.Count;
        ingredientMaxes[(int)CoffeeIngredients.Extras] = (int)ExtrasType.Count;

        drinks[(int)Customer.DrinkOrder.Coffee].RandomizeDrink(ingredientMaxes);
    }
}
