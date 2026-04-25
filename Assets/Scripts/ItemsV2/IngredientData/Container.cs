using UnityEngine;
// TODO: organize

// fizzy, coffee, etc
// TODO: do i need this????
public class Container {
    public static int end = -1;

    public string name;
    public IngredientType[] types;

    public Container(string _name = "null") {
        end++;
        name = _name;
    }

    public bool IsActive() {
        for (int i = 0; i < types.Length; i++) {
            for (int j = 0; j < types[i].ingredients.Length; j++) {
                if (types[i].ingredients[j].value) return true;
            }
        }
        return false;
    }

    public ref Ingredient GetActiveIngredient(int ingredientType) {
        for (int j = 0; j < types[ingredientType].ingredients.Length; j++) {
            if (types[ingredientType].ingredients[j].value)
                return ref types[ingredientType].ingredients[j];
        }
        return ref ArrayExtension.nullIng;
    }

    public ref Ingredient GetActiveIngredient(string ingredientType) {
        for (int i = 0; i < types.Find(ingredientType).Length; i++) {
            if (types.Find(ingredientType)[i].value)
                return ref types.Find(ingredientType)[i];
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

    public ref IngredientType[] GetTypes() { return ref types; }
}
