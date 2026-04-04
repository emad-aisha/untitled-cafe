using UnityEngine;

public class Seating : MonoBehaviour {
    [SerializeField] Transform[] seats;
    [Header("Debug (Dont Touch)")]
    public int numberOfChairs;
    public bool IsFree;

    void Start() {
        numberOfChairs = seats.Length;
        IsFree = true;
    }

}
