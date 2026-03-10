using UnityEngine;

public class Fruit : CupType {
    [Header("Fruit Class Variables")]
    [SerializeField] public FruitType type;

    void Start() {
        cupObject = new();
        cupObject.fruit = type;
    }

    // overides
    
}