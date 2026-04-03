using System;
using UnityEngine;

public enum SodaType { Soda, Count };
[Serializable]
public class Soda {
    public Ingredient ing;

    [SerializeField] bool hasSoda;



    public void Set() {
        ing = new Ingredient((int)SodaType.Count, Priorities.First);

        ing.SetState((int)SodaType.Soda, hasSoda);
    }

    public void SetDebugVariables() {
        hasSoda = ing.GetState((int)SodaType.Soda);
    }
}
