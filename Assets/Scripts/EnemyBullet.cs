using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 10;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health player = collision.GetComponent<Health>();

        if (player != null)
        {
            player.currentHealth -= damage;

            if (player.currentHealth < 0)
                player.currentHealth = 0;

            Destroy(gameObject);
        }
    }
}