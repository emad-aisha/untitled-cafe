using UnityEngine;
using System;

[Serializable]
public class Fruit : FizzyDrinkIngredients {
    [Header("Derived Class Variables")]
    public bool hasLemon;
    public bool hasStrawberry;
    public bool hasLime;

    void Start() {
        priority = Priorities.third;
        SetAllOff(isMachine);
    }

    public void SetLemon(bool set) {
        SetAllOff(isMachine);
        hasLemon = set;
    }
    public void SetStrawberry(bool set) {
        SetAllOff(isMachine);
        hasStrawberry = set;
    }
    public void SetLime(bool set) {
        SetAllOff(isMachine);
        hasLime = set;
    }

    override public void SetAllOff(bool isMachine) {
        if (!isMachine) return;
        hasLemon = false;
        hasStrawberry = false;
        hasLime = false;
    }

    override public bool AllIsOff() {
        if (hasLemon | hasStrawberry || hasLime) return false;
        return true;
    }
}
