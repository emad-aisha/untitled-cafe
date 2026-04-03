using UnityEngine;
/*
public class Syrup : FizzyDrinkIngredients {
    [Header("Ingredient Types")]
    public bool hasLemon;
    public bool hasOrange;
    public bool hasStrawberry;


    void Start() { SetMemberVariables(Drinks.Priorities.Second); }

    override public bool SetIngredient(ref FizzyDrink input, ref int priority) {
        if (!CanChangeVariables(input, IngredientType.Syrup)) return false;
        Syrup inputSyrup = input.GetSyrup();

        if (!inputSyrup.SetState(this.GetState())) return false;
        priority++;

        MenuManager.instance.SetInteractionType(GetState().ToString() + " Syrup");
        return true;
    }

    // getters / setters
    override public void PushBackBools() {
        bools.Add(hasLemon);
        bools.Add(hasOrange);
        bools.Add(hasStrawberry);
    }

    public bool SetState(SyrupType type) {
        switch (type) {
            case SyrupType.Lemon: hasLemon = true; break;
            case SyrupType.Orange: hasOrange = true; break;
            case SyrupType.Strawberry: hasStrawberry = true; break;
            case SyrupType.Null: Debug.Log("Tried to set nothing"); return false;
        }
        return true;
    }
    public SyrupType GetState() {
        if (hasLemon) return SyrupType.Lemon;
        else if (hasOrange) return SyrupType.Orange;
        else if (hasStrawberry) return SyrupType.Strawberry;
        return SyrupType.Null;
    }

    public bool HasState() { return GetState() != SyrupType.Null; }

}
*/
