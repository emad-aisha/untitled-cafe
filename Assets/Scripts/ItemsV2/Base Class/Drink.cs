using System;
using UnityEngine;

public enum DrinkType { Null = -1, FizzyDrink = 0, Coffee = 1 };
public abstract class Drink : MonoBehaviour {
    public Container drinkData;

    // TODO: could prob be put into new class
    public new string name;
    public float price;

    public void Interact(Container otherDrinkData, ref int priority) {
        switch (priority) {
            case (int)Priority.First: SetIngredient(otherDrinkData, ref priority, 0); break;
            case (int)Priority.Second: SetIngredient(otherDrinkData, ref priority, 1); break;
            case (int)Priority.Third: SetIngredient(otherDrinkData, ref priority, 2); break;
            default: Debug.Log("Priority too high or low"); break;
        }
    }

    // setters
    // TODO: clean this up
    public void SetIngredient(Container otherDrinkData, ref int priority, int ingredientType) {
        Debug.Log("CurrDrink: " + drinkData.GetActiveIngredient(priority - 1).name);
        Debug.Log("OtherDrink: " + drinkData.GetActiveIngredient(priority - 1).name);
        // TODO: fix magic numbers 
        // wtf does this even do :sob:
        if (drinkData.GetActiveIngredient(priority - 1).name == otherDrinkData.GetActiveIngredient(priority - 1).name) return;
        if (otherDrinkData.GetActiveIngredient(priority - 1) == ArrayExtension.nullIng) return;

        drinkData.ingredient[ingredientType] = otherDrinkData.ingredient[ingredientType];
        MenuManager.instance.SetLastInteracted(drinkData.GetActiveIngredient(ingredientType).name);
        Debug.Log("Set CurrDrink: " + drinkData.GetActiveIngredient(priority - 1).name);
        priority++;
    }

    // getters
    public ref Data[] GetIngredients() { return ref drinkData.GetIngredient(); }

}
