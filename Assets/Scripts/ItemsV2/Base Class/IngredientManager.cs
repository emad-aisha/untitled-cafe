using UnityEngine;

public class IngredientManager : MonoBehaviour {
    public static IngredientManager instance;

    void Start() { if (instance == null) instance = this; }


}
