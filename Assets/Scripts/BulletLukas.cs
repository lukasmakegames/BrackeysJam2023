using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLukas : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health healthComponent = collision.gameObject.GetComponentInParent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(Random.Range(15,30));
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Health healthComponent = collision.gameObject.GetComponentInParent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(Random.Range(2, 4));
            }
        }

        Destroy(gameObject);
    }
}
