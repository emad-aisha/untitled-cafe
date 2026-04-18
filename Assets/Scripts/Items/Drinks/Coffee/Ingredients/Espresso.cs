using UnityEngine;
using System;

// TODO: change drink types (either ingredient.type or smth else)
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
