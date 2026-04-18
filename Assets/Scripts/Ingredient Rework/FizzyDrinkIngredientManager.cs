using UnityEngine;
using System;

public class FizzyDrinkIngredientManager : MonoBehaviour {
    [Serializable]
    public struct Soda {
        public bool hasSoda;
    }

    [Serializable]
    public struct Syrup {
        public bool hasStrawberry;
        public bool hasOrange;
        public bool hasLemon;
    }

    [Serializable]
    public struct Fruit {
        public bool hasLemon;
        public bool hasLime;
    }


    enum Ing { Null = -1, Soda, Syrup, Fruit };
    [Header("Initialize")]
    [SerializeField] Soda sodaInit;
    [SerializeField] Syrup syrupInit;
    [SerializeField] Fruit fruitInit;

    public Ingredient1 soda = new();
    public Ingredient1 syrup = new();
    public Ingredient1 fruit = new();


    void Start() {
        SetSodaMap();
        SetSyrupMap();
        SetFruitMap();
    }


    // helpers
    // setters
    void SetSodaMap() {
        // make priority interchanalbe with syrup
        soda.SetPriority(1);
        soda.values.Add("Soda", sodaInit.hasSoda);
    }

    void SetSyrupMap() {
        // make priority interchanalbe with soda
        syrup.SetPriority(2);
        syrup.values.Add("Strawberry", syrupInit.hasStrawberry);
        syrup.values.Add("Orange", syrupInit.hasOrange);
        syrup.values.Add("Lemon", syrupInit.hasLemon);
    }

    void SetFruitMap() {
        // make priority interchanalbe with soda
        fruit.SetPriority(2);
        fruit.values.Add("Lime", fruitInit.hasLime);
        fruit.values.Add("Lemon", fruitInit.hasLemon);
    }

}
