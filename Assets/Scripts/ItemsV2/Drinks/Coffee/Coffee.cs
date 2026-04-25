using UnityEngine;


public class Coffee : Drink {
    // TODO: simplify
    [SerializeField] CoffeeIngredients ingredients;
    void Start() {
        drinkData = new();
        drinkData = ingredients.baseIngredient;
    }


}
