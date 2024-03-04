using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// The speed at which the player moves.
    /// </summary>
    public float speed = 5.0f;

    /// <summary>
    /// The minimum X and Y coordinates the player can move to.
    /// </summary>
    public float minX, minY;

    /// <summary>
    /// The maximum X and Y coordinates the player can move to.
    /// </summary>
    public float maxX, maxY;

    /// <summary>
    /// The prefab for the bullet that the player shoots.
    /// </summary>
    public GameObject bulletPrefab;

    /// <summary>
    /// The rate at which the player can shoot bullets.
    /// </summary>
    public float shootingRate = 0.3f;

    private float shootingTimer = 0f;

    void Update()
    {
        MovePlayer();
        shootingTimer += Time.deltaTime;
        if (shootingTimer >= 1f / shootingRate)
        {
            Shoot();
            shootingTimer = 0f;
        }
    }

    /// <summary>
    /// Moves the player based on the input from the Horizontal and Vertical axes.
    /// </summary>
    private void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x + x, minX, maxX),
            Mathf.Clamp(transform.position.y + y, minY, maxY)
        );
    }

    /// <summary>
    /// Shoots a bullet towards the nearest enemy.
    /// </summary>
    private void Shoot()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetTarget(nearestEnemy.transform);
            AudioManager.Instance.PlaySound(AudioManager.Instance.shootSound);
        }
    }

    /// <summary>
    /// Finds the nearest enemy within a certain area of effect.
    /// </summary>
    /// <returns>The nearest enemy GameObject, or null if no enemy is found.</returns>
    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;
        float areaOfEffect = 10.5f;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            float absX = Mathf.Abs(transform.position.x - enemy.transform.position.x);
            bool isOnLine = absX < 0.5f;
            if (distance < minDistance && distance < areaOfEffect && isOnLine)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}
