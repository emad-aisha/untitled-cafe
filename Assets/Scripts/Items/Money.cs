using UnityEngine;

public class Money : MonoBehaviour, IInteractable {
    public float Interact(Drink drink) {
        return drink.price;
    }
}
