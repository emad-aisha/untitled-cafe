using UnityEngine;

public class Liquid : CupType {
    [Header("Liquid Class Variables")]
    [SerializeField] public LiquidType type;

    void Start() {
        cupObject = new();
        cupObject.liquid = type;
    }

    // overides

}
