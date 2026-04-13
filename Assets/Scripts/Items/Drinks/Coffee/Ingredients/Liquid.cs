using UnityEngine;
using System;

public enum LiquidType { Water, Milk, Count };
[Serializable]
public class Liquid {
    public Ingredient ing;

    [SerializeField] bool hasWater;
    [SerializeField] bool hasMilk;

    public void Set() {
        ing = new Ingredient((int)LiquidType.Count, Priorities.Second, (int)LiquidType.Count);

        ing.SetState((int)LiquidType.Water, hasWater);
        ing.SetState((int)LiquidType.Milk, hasMilk);
    }
}
