using UnityEngine;

public class Movement : MonoBehaviour {

    GameObject player;
    CharacterController controller;


    Vector3 moveDirection;
    [SerializeField] int speed;
    [SerializeField] int gravity;


    [SerializeField] int jumpSpeed;
    Vector3 jumpVelocity;
    int totalJumps;


    void Start() {
        player = GameManager.instance.player;
        controller = GameManager.instance.playerController;
        totalJumps = 0;
    }

    public void Move() {
        moveDirection = Input.GetAxis("Horizontal") * player.transform.right + Input.GetAxis("Vertical") * player.transform.forward;
        controller.Move(speed * Time.deltaTime * moveDirection);
    }

    public void JumpLogic() {
        if (controller.isGrounded) {
            jumpVelocity = Vector3.zero;
            totalJumps = 0;
        }
        else {
            jumpVelocity.y -= (gravity * Time.deltaTime);
        }
    }

    public void Jump() {
        if (Input.GetButton("Jump") && totalJumps != 1) {
            jumpVelocity.y = jumpSpeed;
            totalJumps++;
        }

        controller.Move(jumpVelocity * Time.deltaTime);
    }
}
