using System;
using UnityEngine;

public class FizzyDrinkIngredients : FizzyDrinks {
    [Header("Base Class Variables")]
    [SerializeField] public bool isMachine;
    [HideInInspector] public bool canHaveMultiple;
    [HideInInspector] public Priorities priority;

    virtual public void SetAllOff(bool isMachine) { }
    virtual public bool AllIsOff() { return false; }
    virtual public void SetOne() { }

    // TODO: rename this
    virtual public bool CanHaveManyIngredient() {
        if (canHaveMultiple) return true;
        else if (!canHaveMultiple && AllIsOff()) return true;
        return false;
    }
}
