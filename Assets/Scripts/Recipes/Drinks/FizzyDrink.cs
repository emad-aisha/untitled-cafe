using UnityEngine;

public class FizzyDrink : Drink {
    public enum Ingredient {
        Soda = 0, Syrup = 1, Fruit = 2, Citrus = 3,
        All = -1, None = -2
    }
    bool finishedDrink = false;

    public override void Interact(Drink otherDrink, ref int priority) {
        if (finishedDrink) {
            Debug.Log("completed drink");
            return;
        }

        if (!IsActive()) {
            if (otherDrink.Has("Soda") || otherDrink.Has("Syrup")) SetIngredient(otherDrink); // set either
        }
        else if (Has("Soda") && HasNo("Syrup")) SetIngredient(otherDrink, "Syrup"); // set syrup
        else if (Has("Syrup") && HasNo("Soda")) SetIngredient(otherDrink, "Soda"); // set soda
        else if (Has("Syrup") && Has("Soda") && (HasNo("Fruit") || HasNo("Citrus"))) {
            if (HasNo("Fruit") && HasNo("Citrus")) {
                if (otherDrink.Has("Fruit") || otherDrink.Has("Citrus")) SetIngredient(otherDrink);
            }
            else if (Has("Fruit") && HasNo("Citrus")) SetIngredient(otherDrink, "Citrus");
            else if (Has("Citrus") && HasNo("Fruit")) {
                SetIngredient(otherDrink, "Fruit", true);
                if (IsFull("Fruit")) finishedDrink = true;
            }
        }
        else {
            if (otherDrink.Has("Fruit")) {
                SetIngredient(otherDrink, "Fruit", true);
                if (IsFull("Fruit")) finishedDrink = true;
            }
        }

    }
}
