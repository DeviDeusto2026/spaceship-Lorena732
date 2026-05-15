using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public int life = 10;
    public float speed = 8f;
    public float zigzagSpeed = 4f;
    public float zigzagAmount = 10f;
    public Transform player;
    public GameObject miniEnemyPrefab;

    void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 direction = player.position - transform.position;

        if (direction.magnitude > 0.1f)
        {
            Vector3 targetPosition = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );

            targetPosition.x += Mathf.Sin(Time.time * zigzagSpeed) * zigzagAmount * Time.deltaTime;

            transform.position = targetPosition;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life--;

            Destroy(collision.gameObject);

            SpawnMiniEnemy();

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void SpawnMiniEnemy()
    {
        if (miniEnemyPrefab == null)
        {
            return;
        }

        Vector3 spawnPosition = transform.position + transform.forward * 10f;

        GameObject miniEnemy = Instantiate(miniEnemyPrefab, spawnPosition, transform.rotation);

        Enemy enemyScript = miniEnemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.player = player;
        }
    }
}
