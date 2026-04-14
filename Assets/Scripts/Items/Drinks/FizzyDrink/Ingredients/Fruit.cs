using System;
using UnityEngine;

public enum FruitType { Lime, Lemon, Count };
[Serializable]
public class Fruit {
    public Ingredient ing;

    [SerializeField] bool hasLime;
    [SerializeField] bool hasLemon;


    public void Set() {
        ing = new Ingredient((int)FruitType.Count, Priorities.Third);

        ing.SetState(FruitType.Lime, hasLime);
        ing.SetState(FruitType.Lemon, hasLemon);
    }

    public void SetDebugVariables() {
        hasLime = ing.GetState(FruitType.Lime);
        hasLemon = ing.GetState(FruitType.Lemon);
    }
}
