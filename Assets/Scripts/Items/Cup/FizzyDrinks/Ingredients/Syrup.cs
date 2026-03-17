using UnityEngine;
using System;

[Serializable]
public class Syrup : FizzyDrinkIngredients {
    public enum Type { Null, Lemon, Orange, Strawberry };

    [Header("Derived Class Variables")]
    public bool hasLemon;
    public bool hasOrange;
    public bool hasStrawberry;

    void Start() {
        SetSyrup(gameObject.GetComponent<Syrup>());
        priority = Priorities.second;
        SetOne();
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

    override public void SetOne() {
        Type type = GetTrue();

        SetAllOff(isMachine);

        switch (type) {
            case Type.Lemon: hasLemon = true; break;
            case Type.Orange: hasOrange = true; break;
            case Type.Strawberry: hasStrawberry = true; break;
        }
    }

    public void SetOne(Type type) {
        SetAllOff(isMachine);

        switch (type) {
            case Type.Lemon: hasLemon = true; break;
            case Type.Orange: hasOrange = true; break;
            case Type.Strawberry: hasStrawberry = true; break;
        }
    }

    public Type GetTrue() {
        if (hasLemon) return Type.Lemon;
        else if (hasOrange) return Type.Orange;
        else if (hasStrawberry) return Type.Strawberry;
        return Type.Null;
    }

}
