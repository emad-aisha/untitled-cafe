using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour, IInteractable {
    [Header("Interaction")]
    [SerializeField] [Range(0, 1)]  float interactCooldown;
    [SerializeField] [Range(8, 12)] float interactDistance;

    [Header("Misc")]
    [SerializeField] LayerMask ignoreLayer;

    [Header("Debugging")]
    [SerializeField] bool showRaycast;

    Movement movement;
    Vector3 cameraPosition;
    Vector3 cameraForward;

    float interactCooldownTimer;

    void Start() {
        movement = GetComponent<Movement>();
        interactCooldownTimer = interactCooldown;
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

    // interface overrides
    public void Interact() { 
        RaycastHit raycast;

        if (Physics.Raycast(cameraPosition, cameraForward, out raycast, interactDistance, ~ignoreLayer)) {
            IInteractable interactableObject = raycast.collider.GetComponent<IInteractable>();

            if (interactableObject != null) {
                interactableObject.Interact();
                return;
            }
        }
        Debug.Log("Player Class Called");
    }
}
