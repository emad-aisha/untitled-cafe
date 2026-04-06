using System;
using UnityEngine;

public enum SyrupType { Strawberry, Lemon, Orange, Count };
[Serializable]
public class Syrup {
    public Ingredient ing;

    [SerializeField] bool hasStrawberry;
    [SerializeField] bool hasLemon;
    [SerializeField] bool hasOrange;

    public void Set() {
        ing = new Ingredient((int)SyrupType.Count, Priorities.Second);

        ing.SetState((int)SyrupType.Strawberry, hasStrawberry);
        ing.SetState((int)SyrupType.Lemon, hasLemon);
        ing.SetState((int)SyrupType.Orange, hasOrange);
    }

    public void SetDebugVariables() {
        hasStrawberry = ing.GetState((int)SyrupType.Strawberry);
        hasLemon = ing.GetState((int)SyrupType.Lemon);
        hasOrange = ing.GetState((int)SyrupType.Orange);
    }
}
