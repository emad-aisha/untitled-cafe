using UnityEngine;

public enum Priorities { First, Second, Third };
public abstract class Drink : MonoBehaviour {
    // each needs it's own enum
    protected enum CoffeeIngredients { Espresso, Liquid, Extras };
    protected enum FizzyDrinkType { Soda, Syrup, Fruit };

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

    // generally helpful functions
    protected void SetIngredient(ref Drink input, CoffeeIngredients ingredientType, ref int priority) {
        if (ingredients[(int)ingredientType].SetIngredient(ref input.ingredients[(int)ingredientType], ref priority)) {
            MenuManager.instance.SetInteractionType(ingredientType.ToString());
        }
    }
    protected void SetIngredient(ref Drink input, FizzyDrinkType ingredientType, ref int priority) {
        if (ingredients[(int)ingredientType].SetIngredient(ref input.ingredients[(int)ingredientType], ref priority)) {
            MenuManager.instance.SetInteractionType(ingredientType.ToString());
        }
    }
}
