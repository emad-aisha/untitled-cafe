using UnityEngine;
using System;

[Serializable]
public class Syrup : FizzyDrinkIngredients {
    [Header("Derived Class Variables")]
    public bool hasLemon;
    public bool hasOrange;
    public bool hasStrawberry;

    void Start() {
        priority = Priorities.second;
        SetAllOff(isMachine);
    }

    public void SetLemon(bool set) {
        SetAllOff(isMachine);
        hasLemon = set;
    }
    public void SetOrange(bool set) {
        SetAllOff(isMachine);
        hasOrange = set;
    }
    public void SetStrawberry(bool set) {
        SetAllOff(isMachine);
        hasStrawberry = set;
    }

    override public void SetAllOff(bool isMachine) {
        if (!isMachine) return;
        hasLemon = false;
        hasOrange = false;
        hasStrawberry = false;
    }

    override public bool AllIsOff() {
        if (hasLemon | hasStrawberry || hasOrange) return false;
        return true;
    }
}
