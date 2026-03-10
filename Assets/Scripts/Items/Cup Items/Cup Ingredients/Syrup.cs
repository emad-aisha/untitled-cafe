using UnityEngine;

public class Syrup : CupType { 
    [Header("Syrup Class Variables")]
    [SerializeField] public SyrupType type;

    void Start() {
        cupObject = new();
        cupObject.syrup = type;
    }

    // overides
    
}
