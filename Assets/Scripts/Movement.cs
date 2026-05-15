using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 60f;

    public float limitX = 300f;
    public float limitY = 300f;
    public float limitZ = 300f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -limitX, limitX),
            Mathf.Clamp(transform.position.y, -limitY, limitY),
            Mathf.Clamp(transform.position.z, -limitZ, limitZ)
        );
    }
}