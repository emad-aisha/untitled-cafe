using UnityEngine;


public class FizzyDrink : Drink {
    [SerializeField] FizzyDrinkIngredient ingredients;
    void Start() {
        drinkData = new();
        drinkData = ingredients.baseIngredient;
    }


}
