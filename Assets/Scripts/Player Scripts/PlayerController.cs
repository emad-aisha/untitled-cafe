using UnityEngine;

public class PlayerController : MonoBehaviour {

    CharacterController controller;
    Movement movement;


    void Start() {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<Movement>();
    }


    void Update() {
        movement.JumpLogic();

        movement.Move();
        movement.Jump();

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            // interact
        }
    }


}
