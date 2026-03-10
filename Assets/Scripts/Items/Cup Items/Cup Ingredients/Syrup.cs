using UnityEngine;

public class Syrup : CupType {
    public enum SyrupType {
        Null,
        Chocolate, Vanilla, BlueRasberry
    }

    [Header("Syrup Class Variables")]
    [SerializeField] private SyrupType shot;

    // getters
    public SyrupType GetSyrupType() { return shot; }

    // overides
    public new void Interact() {
        Debug.Log("Syrup Class Called");
    }
}
