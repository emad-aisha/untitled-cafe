using UnityEngine;

public class CoffeeShot : CupType {
    public enum CoffeeShotType {
        Null,
        Espresso, Decaf
    }

    [Header("Coffee Shot Class Variables")]
    [SerializeField] private CoffeeShotType type;

    // getters
    public CoffeeShotType GetCoffeeShotType() { return type; }

    // overides
    override public void Interact() {
        Debug.Log("Coffee Shot Class: " + type.ToString());
    }
}
