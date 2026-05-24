using UnityEngine;

public class NameManager : MonoBehaviour {
    public static NameManager instance;

    void Start() {
        if (instance == null) instance = this;
    }



    void SetFizzyDrinkName(ref string name, IngredientsWrapper ingredients) {
        // syrup soda with fruit, fruit2 and citrus
        string drinkName = "";

        if (false)
            drinkName = "";

    }

}
