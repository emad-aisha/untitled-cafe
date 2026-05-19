using UnityEngine;

public class FizzyDrink : Drink {
    public enum Ingredient {
        Soda = 0, Syrup = 1, Fruit = 2, Citrus = 3,
        All = -1, None = -2
    }

    // dont use ingredients with numbers here cuz it can prob change?
    public override void Interact(Drink otherDrink, ref int priority) {
        if (!IsActive()) {
            if (otherDrink.IsTypeActive("Soda") || otherDrink.IsTypeActive("Syrup")) SetIngredient(otherDrink); // set either
        }
        else if (IsTypeActive("Soda") && !IsTypeActive("Syrup")) SetIngredient(otherDrink, "Syrup"); // set syrup
        else if (IsTypeActive("Syrup") && !IsTypeActive("Soda")) SetIngredient(otherDrink, "Soda"); // set soda
        else if (IsTypeActive("Syrup") && IsTypeActive("Soda")) {
            if (!IsTypeActive("Fruit") && !IsTypeActive("Citrus")) {
                if (otherDrink.IsTypeActive("Fruit") || otherDrink.IsTypeActive("Citrus")) SetIngredient(otherDrink);
            }
            else if (IsTypeActive("Fruit") && !IsTypeActive("Citrus")) SetIngredient(otherDrink, "Citrus");
            else if (IsTypeActive("Citrus") && !IsTypeActive("Fruit")) SetIngredient(otherDrink, "Fruit", true);
        }
        else {
            Debug.Log("completed drink");
            PrintActiveIngredients();

            Debug.Log("Soda" + IsTypeActive(0));
            Debug.Log("Syrup" + IsTypeActive("Syrup"));
        }

    }
}
