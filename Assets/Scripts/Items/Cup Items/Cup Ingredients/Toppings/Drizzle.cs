using UnityEngine;

public class Drizzle : CupType {
    public enum DrizzleType {
        Null,
        Caramel, Chocolate
    }

    [Header("Drizzle Class Variables")]
    [SerializeField] private DrizzleType type;

    // getters
    public DrizzleType GetDrizzleType() { return type; }

    // overides
    public new void Interact() {
        Debug.Log("Drizzle Class Called");
    }
}
