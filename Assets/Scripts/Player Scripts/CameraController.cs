using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] int lockMin, lockMax;
    [SerializeField] int sensitivity;
    [SerializeField] bool invertY;

    [Header("Debugging")]
    [SerializeField] bool showRaycast;

    float CameraYPos;

    float mouseX;
    float mouseY;

    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        SetMousePositions();

        InvertLogicCheck();
        RangeCheck();

    }

    void SetMousePositions() {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
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
}
