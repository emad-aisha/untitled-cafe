using UnityEngine;

public class IngredientManager : MonoBehaviour {
    public static IngredientManager instance;
    public static Container[] ingredients;

    void Start() { if (instance == null) instance = this; }


}
