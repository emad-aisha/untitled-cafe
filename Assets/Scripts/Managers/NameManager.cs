using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
struct OrderData {
    public string[] drinkType;
    public string filler;
}

public class NameManager : MonoBehaviour {
    [SerializeField] IngredientType ingredientType;
    //[SerializeField] OrderData data;

    public void SetName(ref string name, IngredientsWrapper ingredients) {
        name = ingredientType switch {
            IngredientType.Coffee => "not implemented yet",
            IngredientType.FizzyDrink => SetFizzyDrinkName(ingredients),
            _ => ""
        };
    }

    string SetFizzyDrinkName(IngredientsWrapper ingredients) {
        string drinkName = "";

        string soda = ingredients.GetActiveIngredient(ingredients["soda"]);
        string syrup = ingredients.GetActiveIngredient(ingredients["syrup"]);

        List<string> fruits = new();
        string[] fruit = ingredients.GetActiveIngredients(ingredients["fruit"]);
        string citrus = ingredients.GetActiveIngredient(ingredients["citrus"]);

        for (int i = 0; i < fruit.Length; i++) {
            if (fruit[i] != "") fruits.Add(fruit[i]);
        }
        if (citrus != "") fruits.Add(citrus);

        if (syrup != "") drinkName = syrup + " ";
        if (soda != "") drinkName += soda + " ";

        if (fruits.Count != 0) {
            drinkName += "with ";

            string seperator = fruits.Count switch {
                2 => "and ",
                1 => "",
                _ => ", "
            };

            for (int i = 0; i < fruits.Count; i++) {
                if (i == fruits.Count - 1) drinkName += fruits[i] + " ";
                else if (seperator == ", " && i == fruits.Count - 2) drinkName += fruits[i] + " " + "and ";
                else if (seperator != ", ") drinkName += fruits[i] + " " + seperator;
                else if (seperator == ", ") drinkName += fruits[i] + seperator;
            }
        }

        MenuManager.instance.SetDrinkName(drinkName);
        return drinkName;
    }

}
