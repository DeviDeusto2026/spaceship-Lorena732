using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life = 3;
    public float speed = 10f;
    public Transform player;

    void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 direction = player.position - transform.position;

        if (direction.magnitude > 0.1f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life--;

            Destroy(collision.gameObject);

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
