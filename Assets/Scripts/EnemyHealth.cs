using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject deathFX;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(deathFX, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySound(AudioManager.Instance.explosionOnEnemyDeathSound);
            Destroy(gameObject);
            GameManager.Instance.EnemyDefeated();
        }
    }
}
