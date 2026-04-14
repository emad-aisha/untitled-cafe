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

        ing.SetState(SyrupType.Strawberry, hasStrawberry);
        ing.SetState(SyrupType.Lemon, hasLemon);
        ing.SetState(SyrupType.Orange, hasOrange);
    }

    public void SetDebugVariables() {
        hasStrawberry = ing.GetState(SyrupType.Strawberry);
        hasLemon = ing.GetState(SyrupType.Lemon);
        hasOrange = ing.GetState(SyrupType.Orange);
    }
}
