using UnityEngine;

public class CoffeeExtra : CupType {
    [Header("Coffee Extra Class Variables")]
    [SerializeField] public CoffeeExtraType type;

    void Start() {
        cupObject = new();
        cupObject.coffeeExtra = type;
    }

    // overides
    
}
