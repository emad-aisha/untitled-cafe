using UnityEngine;


public class Coffee : Drink {
    [SerializeField] CoffeeIngredients ingredients;
    void Start() { drinkData = ingredients.baseIngredient; }


}
