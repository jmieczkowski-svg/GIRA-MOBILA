using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health player = collision.gameObject.GetComponent<Health>();

        if (player != null)
        {
            player.currentHealth -= damage;

            if (player.currentHealth < 0)
                player.currentHealth = 0;
        }
    }
}