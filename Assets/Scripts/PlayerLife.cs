using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public bool isDead = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Enemy>() != null || other.GetComponent<EnemyBullet>() != null)
        {
            isDead = true;
            Debug.Log("Game Over");

            Destroy(other.gameObject);

            GetComponent<BasicMovement>().enabled = false;
            GetComponent<PlayerShooting>().enabled = false;
        }
    }
}
