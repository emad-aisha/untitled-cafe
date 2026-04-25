using UnityEngine;
using System;

// TODO: organize
[Serializable]
public class FizzyDrinkIngredient : BaseIngredient {
    [Serializable]
    struct Soda {
        public bool hasSoda;
    }
    [Serializable]
    struct Syrup {
        public bool hasStrawberry;
        public bool hasOrange;
        public bool hasLemon;
    }
    [Serializable]
    struct Fruit {
        public bool hasLemon;
        public bool hasLime;
    }

    [SerializeField] Soda sodaInit;
    [SerializeField] Syrup syrupInit;
    [SerializeField] Fruit fruitInit;

    Ingredient[] soda;
    Ingredient[] syrup;
    Ingredient[] fruit;

    void Awake() { SetMemberVariables("FizzyDrink"); }

    // setters 
    protected override void SetIngredients() {
        data = new Data[3];

        SetSoda();
        SetSyrup();
        SetFruit();
    }

    // set ingredients
    void SetSoda() {
        soda = new Ingredient[1];
        soda[0] = new Ingredient("Soda", sodaInit.hasSoda);

        SetData("Soda", Priority.First, soda);
    }
    void SetSyrup() {
        syrup = new Ingredient[3];
        syrup[0] = new Ingredient("Orange", syrupInit.hasOrange);
        syrup[1] = new Ingredient("Lemon", syrupInit.hasLemon);
        syrup[2] = new Ingredient("Strawberry", syrupInit.hasStrawberry);

        SetData("Syrup", Priority.Second, syrup);
    }
    void SetFruit() {
        fruit = new Ingredient[2];
        fruit[0] = new Ingredient("Lime", fruitInit.hasLime);
        fruit[1] = new Ingredient("Lemon", fruitInit.hasLemon);

        SetData("Fruit", Priority.Third, fruit);
    }
}
