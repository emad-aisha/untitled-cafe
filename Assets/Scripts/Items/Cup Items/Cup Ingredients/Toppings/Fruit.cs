using UnityEngine;

public class Fruit : CupType {
    public enum FruitType {
        Null,
        Lemon, Lime, Strawberry
    }

    [Header("Fruit Class Variables")]
    [SerializeField] private FruitType type;

    // getters
    public FruitType GetFruitType() { return type; }

    // overides
    override public void Interact() {
        Debug.Log("Fruit Class: " + type.ToString());
    }
}