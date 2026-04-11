using UnityEngine;

public enum DrinkType { Null = -1, FizzyDrink, Coffee, Count };
public enum Priorities { First, Second, Third };
public abstract class Drink : MonoBehaviour {
    [Header("Base Class Variables")]
    public DrinkType drinkType;
    public int[] ingredientMaxes;

    public Ingredient[] ingredients;
    public string drinkName;
    public float price;

    protected void SetMemberVariables(DrinkType type) {
        drinkType = type;
        SetIngredients();
        SetInfoOff();
    }


    abstract public void Interact(ref Drink drink, ref int priority);
    public void RandomizeDrink(NameManager nameManager) {
        int[] ingredientType = new int[ingredients.Length];

        for (int i = 0; i < ingredientType.Length; i++) {
            // randomly set each type
            if (i == 0) ingredientType[0] = Random.Range(0, ingredientMaxes[0]);
            else ingredientType[i] = Random.Range(-1, ingredientMaxes[i]);

            if (ingredientType[i] == -1) break;
            // set type if available
            ingredients[i].SetState(ingredientType[i], true);
        }
        drinkName = nameManager.SetName(this);
        price = nameManager.SetCost();
    }

    // setters
    abstract public void SetAllOff();
    abstract protected void SetIngredients();
    public void ResetInfo() {
        for (int i = 0; i < ingredients.Length; i++) ingredients[i].SetAllStates();
        SetInfoOff();
    }
    abstract public void SetMaxes(ref int[] ingredientMaxes);

    abstract public bool IsEveryStateOff();

    // private functions
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

    void SetInfoOff() {
        drinkName = "";
        price = 0;
    }

}
