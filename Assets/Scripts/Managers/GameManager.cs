using UnityEngine;

public class GameManager : MonoBehaviour {
    static public GameManager instance;

    [Header("Player")]
    public GameObject player;
    public CharacterController playerController;

    public Camera mainCamera;



    private void Awake() {
        if (!instance) instance = this;

        // PLAYER INIT
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<CharacterController>();

        mainCamera = Camera.main;
    }


}
