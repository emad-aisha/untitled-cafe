using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Interaction")]
    [SerializeField][Range(0, 1)] float interactCooldown;
    [SerializeField][Range(8, 12)] float interactDistance;

    [Header("Misc")]
    [SerializeField] LayerMask ignoreLayer;

    [Header("Debugging")]
    [SerializeField] bool showRaycast;

    // Other Classes
    Movement movement;
    Inventory inventory;
    CameraController cameraController;

    float interactCooldownTimer;

    void Start() {
        movement = GetComponent<Movement>();
        inventory = GetComponent<Inventory>();
        interactCooldownTimer = interactCooldown;
        cameraController = GameManager.instance.mainCameraController;
    }

    void Update() {
        cameraController.ShowRaycastCheck(showRaycast, interactDistance);

        movement.MovementCheck();
        InteractCheck();
    }

    // interaction
    void InteractCheck() {
        if (Input.GetButton("Interact1")) {
            if (interactCooldownTimer >= interactCooldown) {
                interactCooldownTimer = 0;
                Interact();
            }
        }
        else {
            interactCooldownTimer += Time.deltaTime;
        }
    }

    public void Interact() {
        RaycastHit raycast;
        bool hitInteractableObject = Physics.Raycast(cameraController.cameraPosition, cameraController.cameraForward, out raycast, interactDistance, ~ignoreLayer);

        if (hitInteractableObject) { inventory.Interact(raycast.collider); }
    }

}
