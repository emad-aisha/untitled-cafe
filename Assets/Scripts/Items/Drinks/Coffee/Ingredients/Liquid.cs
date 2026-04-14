using UnityEngine;
using System;

public enum LiquidType { Water, Milk, Count };
[Serializable]
public class Liquid {
    public Ingredient ing;

    [SerializeField] bool hasWater;
    [SerializeField] bool hasMilk;

    public void Set() {
        ing = new Ingredient((int)LiquidType.Count, Priorities.Second);

        ing.SetState(LiquidType.Water, hasWater);
        ing.SetState(LiquidType.Milk, hasMilk);
    }
}
