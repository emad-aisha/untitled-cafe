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

        ing.SetState((int)ExtrasType.MilkFoam, hasMilkFoam);
        ing.SetState((int)ExtrasType.Chocolate, hasChocolate);
    }

    public void SetDebugVariables() {
        hasMilkFoam = ing.GetState((int)ExtrasType.MilkFoam);
        hasChocolate = ing.GetState((int)ExtrasType.Chocolate);
    }
}
