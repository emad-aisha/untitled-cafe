using UnityEngine;

public class Inventory : MonoBehaviour {
    private int currPriority;


    public void Interact(Collider interactable) {
        Customer customer = interactable.GetComponent<Customer>();

    }
}
