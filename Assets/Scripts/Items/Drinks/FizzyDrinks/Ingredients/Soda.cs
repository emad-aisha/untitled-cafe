using System.Collections.Generic;
using UnityEngine;
/*
public class Soda : FizzyDrinkIngredients {
    [Header("Ingredient Types")]
    public bool hasSoda;


    void Start() { SetMemberVariables(Drinks.Priorities.First); }

    override public bool SetIngredient(ref FizzyDrink input, ref int priority) {
        if (!CanChangeVariables(input, IngredientType.Soda)) return false;
        Soda inputSoda = input.GetSoda();

        if (!inputSoda.SetState(this.GetState())) return false;
        priority++;

        MenuManager.instance.SetInteractionType("Soda");
        return true;
    }

    // getters / setters
    override public void PushBackBools() {
        bools.Add(hasSoda);
    }

    public bool SetState(SodaType type) {
        switch (type) {
            case SodaType.Soda: hasSoda = true; break;
            case SodaType.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public SodaType GetState() {
        if (hasSoda) return SodaType.Soda;
        return SodaType.Null;
    }

    public bool HasState() { return GetState() != SodaType.Null; }

}
*/
