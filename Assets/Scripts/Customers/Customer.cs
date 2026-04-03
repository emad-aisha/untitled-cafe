using UnityEngine;

public class Customer : MonoBehaviour {


    void Start() {
        CustomerManager.instance.numberOfCustomers++;
        Debug.Log(CustomerManager.instance.numberOfCustomers);
    }

    void Update() {

    }
}
