using UnityEngine;

public class Idle {
    float waitTimer = 2; // TODO: randomize
    float internalTimer = 0;


    public Idle() { }

    public CustomerState Update(ref Seating seat, ref FizzyDrink fizzyDrinkOrder, ref Coffee coffeeOrder) {
        if (internalTimer < waitTimer) internalTimer += Time.deltaTime;
        else {
            seat = CustomerManager.instance.GetFreeTable();
            if (seat == null) return CustomerState.Leaving;

            bool hasFizzyDrink = RandomizeFizzyDrink(ref fizzyDrinkOrder);
            if (!hasFizzyDrink) RandomizeCoffee(ref coffeeOrder);
            internalTimer = 0;

            return CustomerState.Ordering;
        }
        return CustomerState.Idle;
    }


    bool RandomizeFizzyDrink(ref FizzyDrink fizzyDrinkOrder) {
        if (RandomCheck() == false) return false;

        Soda soda = new();
        Syrup syrup = new();
        Fruit fruit = new();

        SetFizzyDrinkIngredients(ref soda, ref syrup, ref fruit);
        fizzyDrinkOrder.Set(soda, syrup, fruit);

        DrinkNameManager.instance.SetCustomerDrinkName(fizzyDrinkOrder, NameType.FizzyDrink);
        return true;
    }
    void SetFizzyDrinkIngredients(ref Soda soda, ref Syrup syrup, ref Fruit fruit) {
        soda.Set();
        syrup.Set();
        fruit.Set();

        int sodaType = GetRandomIndex(0, (int)SodaType.Count);
        int syrupType = GetRandomIndex(-1, (int)SyrupType.Count);
        int fruitType = GetRandomIndex(-1, (int)FruitType.Count);

        soda.ing.SetState(sodaType, true);
        if (syrupType != -1) syrup.ing.SetState(syrupType, true);
        if (fruitType != -1) fruit.ing.SetState(fruitType, true);
    }

    bool RandomizeCoffee(ref Coffee coffeeOrder) {
        //if (RandomCheck() == false) return false;

        Espresso espresso = new();
        Liquid liquid = new();
        Extras extra = new();

        SetCoffeeIngredients(ref espresso, ref liquid, ref extra);
        coffeeOrder.Set(espresso, liquid, extra);

        DrinkNameManager.instance.SetCustomerDrinkName(coffeeOrder, NameType.Coffee);
        return true;
    }
    void SetCoffeeIngredients(ref Espresso espresso, ref Liquid liquid, ref Extras extras) {
        espresso.Set();
        liquid.Set();
        extras.Set();

        int espressoType = GetRandomIndex(0, (int)EspressoType.Count);
        int liquidType = GetRandomIndex(-1, (int)LiquidType.Count);
        int extrasType = GetRandomIndex(-1, (int)ExtrasType.Count);

        espresso.ing.SetState(espressoType, true);
        if (liquidType != -1) liquid.ing.SetState(liquidType, true);
        if (extrasType != -1) extras.ing.SetState(extrasType, true);
    }

    bool RandomCheck() {
        int willHaveDrink = Random.Range(0, 2); if (willHaveDrink == 0) return false;
        return true;
    }
    int GetRandomIndex(int minNumber, int maxNumber) { return Random.Range(minNumber, maxNumber); }
}
