using System;
using UnityEngine;

public class Idle {
    float waitTimer = 2; // TODO: randomize
    float internalTimer = 0;

    Seating seat;

    public Idle() { }

    public CustomerState Update(ref FizzyDrink fizzyDrinkOrder) {
        if (internalTimer < waitTimer) internalTimer += Time.deltaTime;
        else {
            seat = CustomerManager.instance.GetFreeTable();
            if (seat == null) return CustomerState.Leaving;

            RandomizeFizzyDrink(ref fizzyDrinkOrder);
            MenuManager.instance.SetCustomerOrder(FizzyDrinkManager.instance.SetFinalDrinkName(fizzyDrinkOrder, false));
            internalTimer = 0;

            return CustomerState.Ordering;
        }
        return CustomerState.Idle;
    }


    void RandomizeFizzyDrink(ref FizzyDrink fizzyDrinkOrder) {
        Soda soda = new();
        Syrup syrup = new();
        Fruit fruit = new();

        SetFizzyDrinkIngredients(ref soda, ref syrup, ref fruit);
        fizzyDrinkOrder.Set(soda, syrup, fruit);
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
    int GetRandomIndex(int minNumber, int maxNumber) { return UnityEngine.Random.Range(minNumber, maxNumber); }
}
