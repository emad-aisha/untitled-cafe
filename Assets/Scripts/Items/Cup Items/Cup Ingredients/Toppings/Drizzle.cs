using UnityEngine;

public class Drizzle : CupType {
    [Header("Drizzle Class Variables")]
    [SerializeField] public DrizzleType type;

    void Start() {
        cupObject = new();
        cupObject.drizzle = type;
    }

    // overides
    
}
