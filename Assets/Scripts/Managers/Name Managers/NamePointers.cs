using UnityEngine;

public class NamePointers : MonoBehaviour {
    public static NamePointers instance;
    void Start() { if (instance == null) instance = this; }

    // TODO: change this name
    public delegate void Name(); // lets me use pointers that take in nothing and return nothing

    static public void CoffeeName() {
        Debug.Log("coffee");
    }

    static public void FizzyDrinkName() {
        Debug.Log("FizzyDrink");
    }

    static public void Error() {
        Debug.Log("error");
    }



}
