using UnityEngine;

public enum DrinkType { Null = -1, FizzyDrink = 0, Coffee = 1 };
public abstract class Drink : MonoBehaviour {
    public Container drinkData;

    // TODO: could prob be put into new class
    public new string name;
    public float price;

    public void Interact(Container otherDrinkData, ref int priority) {
        switch (priority) {
            case (int)Priority.First: SetIngredient(otherDrinkData, ref priority, "Soda"); break;
            case (int)Priority.Second: SetIngredient(otherDrinkData, ref priority, "Syrup"); break;
            case (int)Priority.Third: SetIngredient(otherDrinkData, ref priority, "Fruit"); break;
            default: Debug.Log("Priority too high or low"); break;
        }
    }

    // setters
    public void SetIngredient(Container otherDrinkData, ref int priority, string ingredientType) {
        if (drinkData.GetActiveIngredient(priority - 1).name == otherDrinkData.GetActiveIngredient(priority - 1).name) return;

        drinkData.ingredient.Find(ingredientType) = otherDrinkData.ingredient.Find(ingredientType);
        MenuManager.instance.SetLastInteracted(drinkData.GetActiveIngredient(ingredientType).name);
        priority++;
    }

    // getters
    public ref Data[] GetIngredients() { return ref drinkData.GetIngredient(); }

}
