using UnityEngine;

public enum CoffeeIngredients { Espresso, Liquid, Extras, Null = -1 };
public enum FizzyDrinkIngredients { Soda, Syrup, Fruit, Null = -1 };
public enum Priorities { First, Second, Third };

public enum DrinkType { Null = -1, FizzyDrink, Coffee, Count };
public abstract class Drink : MonoBehaviour {
    // each needs it's own enum

    [Header("Base Class Variables")]
    public Ingredient[] ingredients;

    // TODO: rename
    // and make everything less ugly
    public string finalDrinkName;
    public int price;

    void Start() {
        SetIngredients();
        finalDrinkName = "";
        price = 0;
        price = 0;
    }

    // overrides
    abstract public void Interact(ref Drink drink, ref int priority);
    abstract protected void SetIngredients();
    abstract public bool IsEveryStateOff();
    abstract public void SetAllOff();

    //abstract public Drink RandomizeDrink(Drink blank);

    public void RandomizeDrinkV2(int[] ingredientMaxes) {
        int[] ingredientType = new int[ingredients.Length];
        RandomizeAndSet(ingredientType, ingredientMaxes);
    }

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
    public void ResetInfo() {
        for (int i = 0; i < ingredients.Length; i++) {
            ingredients[i].SetAllStates();
        }
        finalDrinkName = "";
        price = 0;
    }

    // personal functions
    void RandomizeAndSet(int[] ingredientType, int[] ingredientMaxes) {
        for (int i = 0; i < ingredientType.Length; i++) {
            // randomly set each type
            if (i == 0) ingredientType[0] = Random.Range(0, ingredientMaxes[0]);
            else ingredientType[i] = Random.Range(-1, ingredientMaxes[i]);

            if (ingredientType[i] == -1) break;
            // set type if available
            ingredients[i].SetState(ingredientType[i], true);
        }
    }
}
