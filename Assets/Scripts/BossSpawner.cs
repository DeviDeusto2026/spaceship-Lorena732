using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform player;
    public float timeToSpawnBoss = 20f;

    void Start()
    {
        Invoke("SpawnBoss", timeToSpawnBoss);
    }

    void SpawnBoss()
    {
        EnemySpawner[] spawners = FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);

        foreach (EnemySpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }

        GameObject boss = Instantiate(bossPrefab, transform.position, transform.rotation);

        BossEnemy bossScript = boss.GetComponent<BossEnemy>();

        if (bossScript != null)
        {
            bossScript.player = player;
        }

        BossShooting bossShooting = boss.GetComponent<BossShooting>();

        if (bossShooting != null)
        {
            bossShooting.player = player;
        }
    }
}
