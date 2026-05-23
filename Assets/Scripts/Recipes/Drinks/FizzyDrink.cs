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

        if (Has("Soda", "Syrup")) {
            if (HasNot("Fruit", "Citrus")) SetIngredient(otherDrink, false, "Fruit", "Citrus");
            else if (Has("Fruit") && HasNot("Citrus")) SetIngredient(otherDrink, false, "Citrus");
            else if (Has("Citrus") && HasNot("Fruit")) SetIngredient(otherDrink, true, "Fruit");
            if (!IsAllActive("Fruit")) SetIngredient(otherDrink, true, "Fruit");
        }
        else {
            if (HasNot("Soda", "Syrup")) SetIngredient(otherDrink, false, "Soda", "Syrup");
            else if (Has("Soda") && HasNot("Syrup")) SetIngredient(otherDrink, false, "Syrup");
            else if (Has("Syrup") && HasNot("Soda")) SetIngredient(otherDrink, false, "Soda");
        }

        if (Has("Soda", "Syrup", "Citrus") && IsAllActive("Fruit")) {
            finishedDrink = true;
            Debug.Log("completed drink");
        }

    }
}
