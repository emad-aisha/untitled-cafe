using UnityEngine;
using System;

public class CoffeeIngredients : BaseIngredient {
    [Serializable]
    public struct Espresso {
        public bool hasDecaf;
        public bool hasEspresso;
    }
    [Serializable]
    public struct Liquid {
        public bool hasWater;
        public bool hasMilk;
    }
    [Serializable]
    public struct Extras {
        public bool hasMilkFoam;
        public bool hasChocolate;
    }

    [SerializeField] Espresso espressoInit;
    [SerializeField] Liquid liquidInit;
    [SerializeField] Extras extrasInit;

    Ingredient[] espresso;
    Ingredient[] liquid;
    Ingredient[] extras;

    void Start() { SetMemberVariables("Coffee"); }

    // setters
    protected override void SetIngredients() {
        data = new Data[3];

        SetEspresso();
        SetLiquid();
        SetExtras();
    }

    void SetEspresso() {
        espresso = new Ingredient[2];
        espresso[0] = new Ingredient("Espresso", espressoInit.hasEspresso);
        espresso[1] = new Ingredient("Decaf", espressoInit.hasDecaf);

        SetData("Espresso", Priority.First, espresso);
    }
    void SetLiquid() {
        liquid = new Ingredient[2];
        liquid[0] = new Ingredient("Water", liquidInit.hasWater);
        liquid[1] = new Ingredient("Milk", liquidInit.hasMilk);

        SetData("Liquid", Priority.Second, liquid);
    }
    void SetExtras() {
        extras = new Ingredient[2];
        extras[0] = new Ingredient("MilkFoam", extrasInit.hasMilkFoam);
        extras[1] = new Ingredient("Chocolate", extrasInit.hasChocolate);

        SetData("Extras", Priority.Third, extras);
    }

}
