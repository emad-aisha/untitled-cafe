using UnityEngine;

public class Movement : MonoBehaviour {
    // requirements for moving
    GameObject player;
    CharacterController controller;

    [Header("Movement Variables")]
    // walking
    [SerializeField] int speed;
    [SerializeField] int gravity;
    Vector3 moveDirection;

    // jumping
    [SerializeField] int jumpSpeed;
    Vector3 jumpVelocity;
    int totalJumps;


    void Start() { SetAllMembers(); }

    public void MovementCheck() {
        JumpLogic();

        Move();
        Jump();
    }

    // walking
    void Move() {
        moveDirection = Input.GetAxis("Horizontal") * player.transform.right + Input.GetAxis("Vertical") * player.transform.forward;
        controller.Move(speed * Time.deltaTime * moveDirection);
    }

    // jumping
    void JumpLogic() {
        if (controller.isGrounded) {
            jumpVelocity = Vector3.zero;
            totalJumps = 0;
        }
        else {
            jumpVelocity.y -= (gravity * Time.deltaTime);
        }
    }
    void Jump() {
        bool canJump = Input.GetButton("Jump") && totalJumps != 1;
        if (canJump) {
            jumpVelocity.y = jumpSpeed;
            totalJumps++;
        }

        controller.Move(jumpVelocity * Time.deltaTime);
    }

    // setters
    void SetAllMembers() {
        player = GameManager.instance.player;
        controller = GameManager.instance.playerController;
        totalJumps = 0;
    }
}
