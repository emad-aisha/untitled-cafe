using UnityEngine;

public class Coffee : Drink {
    public enum Ingredient {
        Espresso = 0, Liquid = 1, Extra = 2,
        All = -1, None = -2
    }


    //override protected bool SetIngredient(ref Drink otherDrink, ref int priority) {
    //    if (IsTypeActive(priority) || (Ingredient)priority != Ingredient.Extra) return false;
    //
    //      ingredients[priority.ToString()] = otherDrink.ingredients[priority.ToString()];
    //     if ((Ingredient)priority != Ingredient.Extra) priority++;
    //    return true;
    //}
}
