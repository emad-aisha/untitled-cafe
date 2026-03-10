using UnityEngine;

public class Dessert : CupType {
    [Header("Dessert Class Variables")]
    [SerializeField] public DessertType type;

    void Start() {
        cupObject = new();
        cupObject.dessert = type;
    }

    // overides
    
}