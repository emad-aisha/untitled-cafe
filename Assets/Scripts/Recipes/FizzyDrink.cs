using UnityEngine;

public class FizzyDrink : Drink {
    public enum Ingredient {
        Soda = 0, Syrup = 1, Fruit = 2,
        All = -2, None = -1
    }

    public Ingredient type;

}
