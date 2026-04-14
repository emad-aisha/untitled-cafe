using UnityEngine;
using System;

public enum ExtrasType { MilkFoam, Chocolate, Count };
[Serializable]
public class Extras {
    public Ingredient ing;

    [SerializeField] bool hasMilkFoam;
    [SerializeField] bool hasChocolate;

    public void Set() {
        ing = new Ingredient((int)ExtrasType.Count, Priorities.Third);

        ing.SetState(ExtrasType.MilkFoam, hasMilkFoam);
        ing.SetState(ExtrasType.Chocolate, hasChocolate);
    }
}
