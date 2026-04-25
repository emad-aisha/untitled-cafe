using System;
using UnityEngine;
// TODO: sperate
// TODO: organize
// TODO: rename have of this kaka

// fizzy, coffee, etc
public class Container {
    public static int end = -1;

    public string name;
    public Data[] ingredient;

    public Container(string _name = "null") {
        end++;
        name = _name;
    }

    public bool IsActive() {
        for (int i = 0; i < ingredient.Length; i++) {
            for (int j = 0; j < ingredient[i].type.Length; j++) {
                if (ingredient[i].type[j].value) return true;
            }
        }
        return false;
    }

    public ref Ingredient GetActiveIngredient(int ingredientType) {
        for (int j = 0; j < ingredient[ingredientType].type.Length; j++) {
            if (ingredient[ingredientType].type[j].value) return ref ingredient[ingredientType].type[j];
        }
        return ref ArrayExtension.nullIng;
    }

    public ref Ingredient GetActiveIngredient(string ingredientType) {
        for (int i = 0; i < ingredient.Find(ingredientType).Length; i++) {
            if (ingredient.Find(ingredientType)[i].value) return ref ingredient.Find(ingredientType)[i];
        }
        return ref ArrayExtension.nullIng;
    }

    public DrinkType GetDrinkType() {
        DrinkType drinkType = name switch {
            "FizzyDrink" => DrinkType.FizzyDrink,
            "Coffee" => DrinkType.Coffee,
            _ => DrinkType.Null
        };
        return drinkType;
    }

    public ref Data[] GetIngredient() { return ref ingredient; }
}

// syrup, fruit, etc
public enum Priority { First = 1, Second = 2, Third = 3 };
public class Data {
    public int priority;
    public string name;
    public Ingredient[] type;

    public Data(string _name = "null", int _priority = -1) {
        name = _name;
        priority = _priority;
    }
}

// lemon, soda, water
public class Ingredient {
    public string name;
    public bool value;

    public Ingredient(string _name = "null", bool _value = false) {
        name = _name;
        value = _value;
    }
}
