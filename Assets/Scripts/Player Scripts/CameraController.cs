using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] int lockMin, lockMax;
    [SerializeField] int sensitivity;
    [SerializeField] bool invertY;

    // DEBUGGING
    [SerializeField] bool showRaycast;

    float CameraYPos;

    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // invert logic
        if (invertY) CameraYPos += mouseY;
        else CameraYPos -= mouseY;

        // range check
        CameraYPos = Mathf.Clamp(CameraYPos, lockMin, lockMax);
        transform.localRotation = Quaternion.Euler(CameraYPos, 0, 0);
        transform.parent.Rotate(Vector3.up * mouseX);

        if (showRaycast) Debug.DrawRay(transform.position, transform.forward * 15, Color.blue);
    }


}
