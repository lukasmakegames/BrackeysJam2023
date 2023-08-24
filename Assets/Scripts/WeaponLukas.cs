using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLukas : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    public virtual void Fire(Vector2 cursorPosition)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce((new Vector3(cursorPosition.x,firePoint.position.y,cursorPosition.y) - firePoint.position).normalized * fireForce, ForceMode.Impulse);
    }
}
