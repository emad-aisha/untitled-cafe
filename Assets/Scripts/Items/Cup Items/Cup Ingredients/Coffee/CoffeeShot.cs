using UnityEngine;

public class CoffeeShot : CupType {
    [Header("Coffee Shot Class Variables")]
    [SerializeField] public CoffeeShotType type;

    void Start() {
        cupObject = new();
        cupObject.coffeeShot = type;
    }

    // overides
    
}
