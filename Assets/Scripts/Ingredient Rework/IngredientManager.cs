using UnityEngine;

public class IngredientManager : MonoBehaviour {
    public static IngredientManager instance;
    void Start() { if (instance == null) instance = this; }

    public bool isActive(params bool[] values) {
        for (int i = 0; i < values.Length; i++) { if (values[i]) return true; }
        return false;
    }
}
