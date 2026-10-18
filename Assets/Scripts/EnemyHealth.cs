using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public int points = 1;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            PlayerScore playerScore = FindFirstObjectByType<PlayerScore>();

            if (playerScore != null)
            {
                playerScore.AddPoints(points);
            }

            Destroy(gameObject);
        }
    }
}