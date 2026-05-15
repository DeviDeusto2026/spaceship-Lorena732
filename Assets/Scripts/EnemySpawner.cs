using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnTime = 3f;

    private bool canSpawn = true;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnTime);
    }

    public void StopSpawning()
    {
        canSpawn = false;
        CancelInvoke("SpawnEnemy");
    }

    void SpawnEnemy()
    {
        if (!canSpawn)
        {
            return;
        }

        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);

        Enemy enemyScript = enemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.player = player;
        }
    }
}
