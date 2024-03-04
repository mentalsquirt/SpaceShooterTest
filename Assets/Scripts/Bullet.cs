using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Transform target;
    private Vector2 lastDirection;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        if (target != null)
        {
            lastDirection = (target.position - transform.position).normalized;
        }
    }

    void Update()
    {
        if (target != null)
        {
            lastDirection = (target.position - transform.position).normalized;
            RotateTowardsTarget(lastDirection);
        }

        transform.position += (Vector3)lastDirection * speed * Time.deltaTime;

        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    private void RotateTowardsTarget(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 270);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // any additional logic for what happens when a bullet hits an enemy
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }
    }
}
