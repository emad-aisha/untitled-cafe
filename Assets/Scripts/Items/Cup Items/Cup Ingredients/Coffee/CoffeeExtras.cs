using UnityEngine;

public class CoffeeExtra : CupType {
    public enum CoffeeExtraType {
        Null,
        MilkFoam, Chocolate, Sweetener
    }

    [Header("Coffee Extra Class Variables")]
    [SerializeField] private CoffeeExtraType type;

    // getters
    public CoffeeExtraType GetCoffeeExtraType() { return type; }

    // overides
    public new void Interact() {
        Debug.Log("Coffee Extra Class Called");
    }
}
