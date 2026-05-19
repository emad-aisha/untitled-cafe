using UnityEngine;

public class Coffee : Drink {
    public enum Ingredient {
        Espresso = 0, Liquid = 1, Extra = 2,
        All = -1, None = -2
    }

    // dont use ingredients with numbers here cuz it can prob change?
    public override void Interact(Drink otherDrink, ref int priority) {
        Debug.Log("coffee");



    }
}
