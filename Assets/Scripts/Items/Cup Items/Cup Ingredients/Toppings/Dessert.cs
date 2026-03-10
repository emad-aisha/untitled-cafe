using UnityEngine;

public class Dessert : CupType {
    public enum DessertType {
        Null,
        WhippedCream, Chocolate,
        ChocolateShavings, Sprinkles
    }

    [Header("Dessert Class Variables")]
    [SerializeField] private DessertType type;

    // getters
    public DessertType GetDessertType() { return type; }

    // overides
    public new void Interact() {
        Debug.Log("Dessert Class Called");
    }
}