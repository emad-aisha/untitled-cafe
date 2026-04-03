using System.Collections.Generic;
using UnityEngine;
/*
public abstract class Ingredients : MonoBehaviour {
    [HideInInspector] public List<bool> bools;

    public enum FizzyDrinkIngredient { Null, Soda, Syrup, Fruit };
    public enum CoffeeIngredient { Null, Espresso, Liquid, Extras };

    // generic ingredient functions
    public void SetAllOff() { for (int i = 0; i < bools.Count; i++) bools[i] = false; }
    public bool IsAllOff() { return !IsAnyOn(); }
    public bool CanGetItem() { return IsAllOff(); }

    // different per ingredient
    abstract public void PushBackBools();
    virtual public bool CanChangeVariables(FizzyDrink input, FizzyDrinkIngredient type) {
        Debug.Log("Ingredients.CanChangeVariables(FizzyDrink) called");
        return false;
    }
    abstract public void SetMemberVariables(Drinks.Priorities _priority);


    // personal functions
    bool IsOn(bool state) { return state == true; }
    bool IsAnyOn() {
        for (int i = 0; i < bools.Count; i++)
            if (IsOn(bools[i]))
                return true;
        return false;
    }

}
*/
