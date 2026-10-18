using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform player;
    public float spawnInterval = 3f;
    public float minimumSpawnInterval = 0.8f;
    public float difficultyIncrease = 0.05f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
        InvokeRepeating(nameof(IncreaseDifficulty), 10f, 10f);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(-8f, 8f),
            Random.Range(-4f, 4f)
        );

        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        GameObject enemy = Instantiate(
            enemyPrefabs[randomIndex],
            spawnPosition,
            Quaternion.identity
        );

        EnemyMovement movement = enemy.GetComponent<EnemyMovement>();

        if (movement != null)
            movement.target = player;

        ShootingEnemyMovement shootingMovement =
            enemy.GetComponent<ShootingEnemyMovement>();

        if (shootingMovement != null)
            shootingMovement.target = player;

        ShootingEnemyAttack shootingAttack =
            enemy.GetComponent<ShootingEnemyAttack>();

        if (shootingAttack != null)
            shootingAttack.target = player;
    }

    void IncreaseDifficulty()
    {
        spawnInterval = Mathf.Max(
            minimumSpawnInterval,
            spawnInterval - difficultyIncrease
        );

        CancelInvoke(nameof(SpawnEnemy));
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }
}