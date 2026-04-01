using UnityEngine;

public class Drinks : MonoBehaviour {
    [HideInInspector] public enum Priorities { first, second, third };
    public int price;


    public bool ArePrioritiesMatching(Priorities priority, int checkedPriority) {
        return priority == (Priorities)checkedPriority;
    }
}
