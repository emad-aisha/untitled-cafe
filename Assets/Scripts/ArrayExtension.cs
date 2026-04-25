using UnityEngine;
using System;

public static class ArrayExtension {
    public static Ingredient nullIng = new();
    public static Ingredient[] nullIngs = { new() };

    // look into Container.ingredient for viable thing
    public static ref Ingredient[] Find(this IngredientType[] types, string name) {
        for (int i = 0; i < types.Length; i++) {
            if (types[i].name.ToLower() == name.ToLower()) return ref types[i].ingredients;
        }
        return ref nullIngs;
    }

    public static ref Ingredient Find(this Ingredient[] ingredients, string name) {
        for (int i = 0; i < ingredients.Length; i++) {
            if (ingredients[i].name.ToLower() == name.ToLower()) return ref ingredients[i];
        }
        return ref nullIng;
    }

}
