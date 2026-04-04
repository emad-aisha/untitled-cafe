using UnityEngine;

public enum CoffeeIngredients { Espresso, Liquid, Extras, Null };
public enum FizzyDrinkIngredients { Soda, Syrup, Fruit, Null };
public enum Priorities { First, Second, Third };
public abstract class Drink : MonoBehaviour {
    // each needs it's own enum

    [Header("Base Class Variables")]
    public Ingredient[] ingredients;
    public int price;

    void Start() {
        SetIngredients();
        price = 0;
    }

    // overrides
    abstract public void Interact(ref Drink drink, ref int priority);
    abstract protected void SetIngredients();
    abstract public bool IsEveryStateOff();
    abstract public void SetAllOff();

    // generally helpful functions
    protected void SetIngredient(ref Drink input, CoffeeIngredients ingredientType, ref int priority) {
        if (ingredients[(int)ingredientType].SetIngredient(ref input.ingredients[(int)ingredientType], ref priority)) {
            MenuManager.instance.SetLastInteracted(ingredientType.ToString());
        }
    }
    protected void SetIngredient(ref Drink input, FizzyDrinkIngredients ingredientType, ref int priority) {
        if (ingredients[(int)ingredientType].SetIngredient(ref input.ingredients[(int)ingredientType], ref priority)) {
            MenuManager.instance.SetLastInteracted(ingredientType.ToString());
        }
    }
}
