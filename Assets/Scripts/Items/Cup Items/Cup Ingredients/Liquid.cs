using UnityEngine;

public class Liquid : CupType {
    public enum LiquidType {
        Null,
        Water, Soda, Milk
    }

    [Header("Liquid Class Variables")]
    [SerializeField] private LiquidType type;

    // getters
    public LiquidType GetLiquidType() { return type; }

    // overides
    public new void Interact() {
        Debug.Log("Liquid Class Called");
    }
}
