using UnityEngine;

public abstract class Ingredients : MonoBehaviour {
    [SerializeField] public bool isMachine;
    [HideInInspector] public bool canHaveMultiple;

    abstract public void SetAllOff();
    abstract public bool IsAllOff();
    //public bool SetOne(Type type)


    virtual public bool CanGetItem() {
        if (canHaveMultiple) return true;               // can have multiple so it doesn't matter if there's items or not
        if (!canHaveMultiple && IsAllOff()) return true; // can't have multiple but if nothing else, then it's fine
        return false;
    }
}
