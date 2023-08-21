using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLukas : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
