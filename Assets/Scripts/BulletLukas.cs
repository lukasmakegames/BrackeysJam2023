using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLukas : MonoBehaviour
{
    public GameObject hitEffect;

    public bool isEnemyBullet = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isEnemyBullet)
        {
            Health healthComponent = collision.gameObject.GetComponentInParent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(Random.Range(15,30));
                Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            }
        }
        else if (collision.gameObject.CompareTag("Player") && isEnemyBullet)
        {
            Health healthComponent = collision.gameObject.GetComponentInParent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(Random.Range(2, 4));
                Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            }
        }

        Destroy(gameObject);
    }
}
