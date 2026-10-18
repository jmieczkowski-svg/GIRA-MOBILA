using UnityEngine;

public class ShootingEnemyMovement : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 1.5f;
    public float stopDistance = 4f;

    void Update()
    {
        if (target == null)
            return;

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > stopDistance)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                target.position,
                moveSpeed * Time.deltaTime
            );
        }
        else
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                target.position,
                -moveSpeed * Time.deltaTime
            );
        }
    }
}