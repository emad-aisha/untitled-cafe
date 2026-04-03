using UnityEngine;

public class Seating : MonoBehaviour {
    [SerializeField] Transform[] seats;
    public int numberOfChairs;
    public bool IsFree;

    void Start() {
        numberOfChairs = seats.Length;
        IsFree = true;
    }

}
