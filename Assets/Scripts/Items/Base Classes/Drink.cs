using UnityEngine;

public enum DrinkType { Null = -1, FizzyDrink, Coffee, Count };
public enum Priorities { First, Second, Third };
public abstract class Drink : MonoBehaviour {
    [Header("Base Class Variables")]
    [HideInInspector] public DrinkType drinkType;
    public Ingredient[] ingredients;

    protected Name nameManager;
    public string drinkName;
    public float price;


    public void RandomizeDrink() {
        int ingredientType = 0;

        for (int i = 0; i < ingredients.Length; i++) {
            ingredientType = GetRandomIngredient(i);
            if (ingredientType != -1) ingredients[i].SetState(ingredientType, true);
            else break;
        }

        SetDrinkInfo(nameManager.SetName(this), nameManager.SetCost());
    }


    // abstract
    abstract public void Interact(ref Drink drink, ref int priority);
    abstract protected void SetIngredients();
    abstract public void SetAllOff();
    abstract public bool IsEveryStateOff();


    // setters
    public void SetIngredient<T>(ref Drink input, T ingredientType, ref int priority) where T : System.Enum {
        int ingredientIndex = (int)(object)ingredientType;

        bool canSetIngredient = ingredients[ingredientIndex].SetIngredient(ref input.ingredients[ingredientIndex], ref priority);
        if (canSetIngredient) { SetBaseType(ingredientType); }
    }

    protected void SetMemberVariables(DrinkType type) {
        drinkType = type;
        SetIngredients();
        SetNameManager();
        SetDrinkInfo("", 0);
    }
    private void SetNameManager() {
        nameManager = drinkType switch {
            DrinkType.FizzyDrink => new FizzyDrinkManager(this),
            DrinkType.Coffee => new CoffeeManager(this),
            _ => null
        };
        if (nameManager == null) Debug.Log("No Name Manager Set");
    }
    public void ResetInfo() {
        foreach (Ingredient ing in ingredients) ing.SetAllStates(false);
        SetDrinkInfo("", 0);
    }

    // drinkname + price
    void SetDrinkInfo(string newdrinkName, float newPrice) {
        drinkName = newdrinkName;
        price = newPrice;
    }
    protected void SetDrinkInfo(ref Drink drink) {
        drink.drinkName = nameManager.SetName(drink);
        drink.price = nameManager.SetCost();
    }
    protected void ShowDrinkInfo(ref Drink drink) {
        SetDrinkInfo(ref drink);
        MenuManager.instance.SetBaseType(drinkType.ToString());
    }


    // getters
    private int GetRandomIngredient(int index) {
        if (index == 0) return Random.Range(0, ingredients[0].GetMax());
        else return Random.Range(-1, ingredients[index].GetMax());
    }


    // TODO: use this more 
    void SetBaseType<T>(T enumValue) where T : System.Enum { MenuManager.instance.SetLastInteracted(enumValue.ToString()); }

}
