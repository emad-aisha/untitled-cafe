using UnityEngine;

public class GameManager : MonoBehaviour {
    static public GameManager instance;

    // TODO: sort these (either into seperate managers or classes)
    [Header("Player")]
    public GameObject player;
    public CharacterController playerController;
    public float playerMoney = 0;

    [Header("Camera")]
    public Camera mainCamera;
    public CameraController mainCameraController;




    private void Awake() {
        if (!instance) instance = this;

        // PLAYER INIT
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<CharacterController>();

        mainCamera = Camera.main;
        mainCameraController = mainCamera.GetComponent<CameraController>();
    }


}
