using UnityEngine;

public class CustomerManager : MonoBehaviour {
    static public CustomerManager instance;

    public int numberOfCustomers = 0;

    void Awake() { if (instance == null) instance = this; }


}
