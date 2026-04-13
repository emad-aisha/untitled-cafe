using System;
using UnityEngine;

public enum FruitType { Lime, Lemon, Count };
[Serializable]
public class Fruit {
    public Ingredient ing;

    [SerializeField] bool hasLime;
    [SerializeField] bool hasLemon;


    public void Set() {
        ing = new Ingredient((int)FruitType.Count, Priorities.Third, (int)FruitType.Count);

        ing.SetState((int)FruitType.Lime, hasLime);
        ing.SetState((int)FruitType.Lemon, hasLemon);
    }

    public void SetDebugVariables() {
        hasLime = ing.GetState((int)FruitType.Lime);
        hasLemon = ing.GetState((int)FruitType.Lemon);
    }
}
