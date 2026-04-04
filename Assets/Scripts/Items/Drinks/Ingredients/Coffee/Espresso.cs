using UnityEngine;
using System;

public enum EspressoType { Decaf, Regular, Count };
[Serializable]
public class Espresso {
    public Ingredient ing;

    [SerializeField] bool hasDecaf;
    [SerializeField] bool hasEspresso;

    public void Set() {
        ing = new Ingredient((int)EspressoType.Count, Priorities.First);

        ing.SetState((int)EspressoType.Decaf, hasDecaf);
        ing.SetState((int)EspressoType.Regular, hasEspresso);
    }
}
