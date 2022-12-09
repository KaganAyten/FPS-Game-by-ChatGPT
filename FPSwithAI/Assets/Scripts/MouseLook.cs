using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // The speed at which the camera will rotate
    public float sensitivity = 100f;

    // The camera game object
    public Transform body;

    private float xRot;
    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        // Get the input from the mouse
        float x = Input.GetAxis("Mouse X") * sensitivity;
        float y = Input.GetAxis("Mouse Y") * sensitivity;

        xRot -= y;
        xRot = Mathf.Clamp(xRot, -90, 90);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        // Rotate the player game object on the y-axis
        body.transform.Rotate(Vector3.up*x);
    }
}
