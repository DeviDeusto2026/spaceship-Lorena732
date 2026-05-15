using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform player;
    public float shootTime = 2f;
    public float spawnDistance = 10f;

    void Start()
    {
        InvokeRepeating("Shoot", 1f, shootTime);
    }

    void Shoot()
    {
        if (enemyBulletPrefab == null || player == null)
        {
            return;
        }

        Vector3 direction = player.position - transform.position;
        Vector3 spawnPosition = transform.position + direction.normalized * spawnDistance;

        GameObject bullet = Instantiate(enemyBulletPrefab, spawnPosition, Quaternion.identity);

        EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();

        if (enemyBullet != null)
        {
            enemyBullet.SetDirection(direction);
        }
    }
}
