using UnityEngine;
using System;

[Serializable]
public class Fruit : FizzyDrinkIngredients {
    public enum Type { Null, Lime, Lemon, Strawberry };
    [Header("Derived Class Variables")]
    public bool hasLime;
    public bool hasLemon;
    public bool hasStrawberry;

    void Start() {
        SetFruit(gameObject.GetComponent<Fruit>());
        priority = Priorities.third;
        SetOne();
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

    override public void SetOne() {
        Type type = GetTrue();
        SetAllOff(isMachine);

        switch (type) {
            case Type.Lemon: hasLemon = true; break;
            case Type.Lime: hasLime = true; break;
            case Type.Strawberry: hasStrawberry = true; break;
        }
    }

    public void SetOne(Type type) {
        SetAllOff(isMachine);

        switch (type) {
            case Type.Lemon: hasLemon = true; break;
            case Type.Lime: hasLime = true; break;
            case Type.Strawberry: hasStrawberry = true; break;
        }
    }

    public Type GetTrue() {
        if (hasLemon) return Type.Lemon;
        else if (hasLime) return Type.Lime;
        else if (hasStrawberry) return Type.Strawberry;
        return Type.Null;
    }
}
