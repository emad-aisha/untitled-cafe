using UnityEngine;
using System;

public enum EspressoType { Decaf, Espresso, Count };
[Serializable]
public class Espresso {
    public Ingredient ing;

    [SerializeField] bool hasDecaf;
    [SerializeField] bool hasEspresso;

    public void Set() {
        ing = new Ingredient((int)EspressoType.Count, Priorities.First);

        ing.SetState(EspressoType.Decaf, hasDecaf);
        ing.SetState(EspressoType.Espresso, hasEspresso);
    }
}
