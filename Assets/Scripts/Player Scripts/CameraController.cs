using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] int lockMin, lockMax;
    [SerializeField] int sensitivity;
    [SerializeField] bool invertY;

    float CameraYPos;

    float mouseX;
    float mouseY;

    [HideInInspector] public Vector3 cameraPosition;
    [HideInInspector] public Vector3 cameraForward;

    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        SetCamera();
        SetMousePositions();

        InvertLogicCheck();
        RangeCheck();
    }


    public void ShowRaycastCheck(bool showRaycast, float interactDistance) {
        if (showRaycast) Debug.DrawRay(cameraPosition, cameraForward * interactDistance, Color.blue);
    }

    void InvertLogicCheck() {
        if (invertY) CameraYPos += mouseY;
        else CameraYPos -= mouseY;
    }

    void RangeCheck() {
        CameraYPos = Mathf.Clamp(CameraYPos, lockMin, lockMax);
        transform.localRotation = Quaternion.Euler(CameraYPos, 0, 0);
        transform.parent.Rotate(Vector3.up * mouseX);
    }

    // setters
    void SetMousePositions() {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
    }

    void SetCamera() {
        cameraPosition = GameManager.instance.mainCamera.transform.position;
        cameraForward = GameManager.instance.mainCamera.transform.forward;
    }

}
