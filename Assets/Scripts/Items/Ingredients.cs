using System.Collections.Generic;
using UnityEngine;

public abstract class Ingredients : MonoBehaviour {
    [SerializeField] public bool isMachine;
    [HideInInspector] public bool canHaveMultiple;
    [HideInInspector] public List<bool> bools;


    virtual public void SetAllOff() { for (int i = 0; i < bools.Count; i++) bools[i] = false; }
    virtual public bool IsAllOff() {
        for (int i = 0; i < bools.Count; i++)
            if (IsOn(bools[i])) return false;

        return true;
    }
    //public bool SetOne(Type type)


    virtual public bool CanGetItem() {
        if (canHaveMultiple) return true;               // can have multiple so it doesn't matter if there's items or not
        if (!canHaveMultiple && IsAllOff()) return true; // can't have multiple but if nothing else, then it's fine
        return false;
    }

    // helpers
    bool IsOn(bool state) {
        if (state == true) return true;
        return false;
    }
}
