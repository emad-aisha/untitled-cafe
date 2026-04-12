using UnityEngine;

public class Seating : MonoBehaviour {
    [SerializeField] Transform[] seats;
    [Header("Debug (Dont Touch)")]
    public int numberOfChairs;
    public bool isFree;

    void Start() {
        numberOfChairs = seats.Length;
        isFree = true;
    }

}
