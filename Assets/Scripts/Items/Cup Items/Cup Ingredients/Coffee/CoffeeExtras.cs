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
    override public void Interact() {
        Debug.Log("Coffee Extra Class: " + type.ToString());
    }
}
