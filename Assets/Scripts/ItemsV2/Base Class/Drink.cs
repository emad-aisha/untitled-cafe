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
            case (int)Priority.First: SetIngredient(otherDrinkData, ref priority); break;
            case (int)Priority.Second: SetIngredient(otherDrinkData, ref priority); break;
            case (int)Priority.Third: SetIngredient(otherDrinkData, ref priority); break;
            default: Debug.Log("Priority too high or low"); break;
        }
    }

    // setters
    // TODO: clean this up
    public void SetIngredient(Container otherDrinkData, ref int priority) {
        // TODO: fix magic numbers 
        // wtf does this even do :sob:
        if (drinkData.GetActiveIngredient(priority).name == otherDrinkData.GetActiveIngredient(priority).name) return;
        if (otherDrinkData.GetActiveIngredient(priority) == ArrayExtension.nullIng) return;

        drinkData.ingredient[priority] = otherDrinkData.ingredient[priority];
        MenuManager.instance.SetLastInteracted(drinkData.GetActiveIngredient(priority).name);
        priority++;
    }

    // getters
    public ref Data[] GetIngredients() { return ref drinkData.GetIngredient(); }

}
