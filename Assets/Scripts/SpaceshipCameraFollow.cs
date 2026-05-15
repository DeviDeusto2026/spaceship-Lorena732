using UnityEngine;

public class SpaceshipCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 4, -12);

    void LateUpdate()
    {
        transform.position = target.position
                             + target.right * offset.x
                             + target.up * offset.y
                             + target.forward * offset.z;

        transform.LookAt(target.position + target.forward * 5f);
    }
}