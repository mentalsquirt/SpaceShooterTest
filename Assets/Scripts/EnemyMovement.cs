using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject hitFX;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bound"))
        {
            Instantiate(hitFX, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySound(AudioManager.Instance.explosionOnPlayerHitSound);
            Destroy(gameObject);
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }
}
