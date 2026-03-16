using UnityEngine;

public class FizzyDrinkIngredients : FizzyDrinks {
    [Header("Base Class Variables")]
    [SerializeField] public bool isMachine;
    protected Priorities priority;

    virtual public void SetAllOff(bool isMachine) { }
    virtual public bool AllIsOff() { return false; }
}
