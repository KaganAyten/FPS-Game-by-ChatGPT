using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float amount = 0.01f;
    public float smooth = 5.0f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        float movementX = -Input.GetAxis("Mouse X") * amount;
        float movementY = -Input.GetAxis("Mouse Y") * amount;

        movementX = Mathf.Clamp(movementX, -amount, amount);
        movementY = Mathf.Clamp(movementY, -amount, amount);

        Vector3 finalPosition = new Vector3(movementX, movementY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smooth);
    }
}