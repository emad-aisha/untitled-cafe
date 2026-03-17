using System;
using UnityEditor.ShaderGraph;
using UnityEngine;

[Serializable]
public class Soda : FizzyDrinkIngredients {
    public enum Type { Null, Soda };
    [Header("Derived Class Variables")]
    public bool hasSoda;

    void Start() {
        SetSoda(gameObject.GetComponent<Soda>());
        priority = Priorities.first;
        canHaveMultiple = false;

        SetOne();
    }

    override public void SetAllOff(bool isMachine) { hasSoda = false; }
    override public bool AllIsOff() {
        if (!hasSoda) return true;
        return false;
    }

    override public void SetOne() {
        Type type = GetTrue();

        SetAllOff(isMachine);

        switch (type) {
            case Type.Soda: hasSoda = true; break;
        }
    }

    public void SetOne(Type type) {
        if (!canHaveMultiple) SetAllOff(isMachine);

        switch (type) {
            case Type.Soda: hasSoda = true; break;
        }
    }

    public Type GetTrue() {
        if (hasSoda) return Type.Soda;
        return Type.Null;
    }
}
