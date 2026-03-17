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

    // inventory
    // TODO: this could be its own class
    Cup cup;
    [SerializeField] FizzyDrinks myFizzyDrink;

    Movement movement;
    Vector3 cameraPosition;
    Vector3 cameraForward;

    float interactCooldownTimer;

    void Start() {
        movement = GetComponent<Movement>();
        interactCooldownTimer = interactCooldown;

        SetBaseCup();
    }

    void Update() {
        SetCamera();
        ShowRaycastCheck();

        MovementCheck();

        InteractCheck();
    }


    // helper function
    void MovementCheck() {
        movement.JumpLogic();

        movement.Move();
        movement.Jump();
    }
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

    void SetCamera() {
        cameraPosition = GameManager.instance.mainCamera.transform.position;
        cameraForward = GameManager.instance.mainCamera.transform.forward;
    }

    void ShowRaycastCheck() {
        if (showRaycast) Debug.DrawRay(cameraPosition, cameraForward * interactDistance, Color.blue);
    }

    void SetBaseCup() {
        cup = new Cup(myFizzyDrink, 0);
    }

    // interface overrides
    public void Interact() {
        RaycastHit raycast;

        if (Physics.Raycast(cameraPosition, cameraForward, out raycast, interactDistance, ~ignoreLayer)) {
            cup.Interact(raycast.collider);
        }
    }

}
