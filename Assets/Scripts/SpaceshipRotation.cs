using UnityEngine;

public class SpaceshipRotation : MonoBehaviour
{
    public float pitchAmount = 20f; // morro arriba/abajo
    public float yawAmount = 60f;   // morro izquierda/derecha
    public float rollAmount = 25f;  // inclinación lateral
    public float rotationSpeed = 5f;

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        float pitch = -moveY * pitchAmount;
        float yaw = moveX * yawAmount;
        float roll = -moveX * rollAmount;

        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);

        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}

