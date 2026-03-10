using UnityEngine;

public class Dessert : CupType {
    public enum DessertType {
        Null,
        WhippedCream, Chocolate
    }

    [Header("Dessert Class Variables")]
    [SerializeField] private DessertType type;

    // getters
    public DessertType GetDessertType() { return type; }

    // overides
    override public void Interact() {
        Debug.Log("Dessert Class: " + type.ToString());
    }
}