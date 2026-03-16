using System;
using UnityEngine;

[Serializable]
public class Soda : FizzyDrinkIngredients {
    [Header("Derived Class Variables")]
    public bool hasSoda;

    void Start() {
        priority = Priorities.first;
        SetSoda(this);
    }

    override public void SetAllOff(bool isMachine) { hasSoda = false; }
    override public bool AllIsOff() {
        if (!hasSoda) return true;
        return false;
    }

}
