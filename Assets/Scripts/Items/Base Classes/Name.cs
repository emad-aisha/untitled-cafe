using UnityEngine;

public abstract class Name {
    protected int[] types;
    public Name(Drink drink) { SetIngredientTypes(drink); }

    abstract public string SetName(Drink drink);
    abstract public float SetCost();

    protected abstract void SetIngredientTypes(Drink drink);
    protected abstract string FinalDrinkLogic();

    // helpers
    protected T GetCostType<T>() where T : System.Enum {
        for (int i = 0; i < types.Length; i++) { if (types[i] != -1) return (T)(object)i; }
        return (T)(object)-1;
    }
    protected bool InRange<U>(int type, U max) where U : System.Enum {
        return type >= 0 && type < (int)(object)max;
    }

}
