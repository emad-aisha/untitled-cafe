using UnityEngine;

public class Syrup : CupType {
    public enum SyrupType {
        Null,
        Chocolate, Vanilla, BlueRaspberry
    }

    [Header("Syrup Class Variables")]
    [SerializeField] private SyrupType type;

    // getters
    public SyrupType GetSyrupType() { return type; }

    // overides
    override public void Interact() {
        Debug.Log("Syrup Class: " + type.ToString());
    }
}
