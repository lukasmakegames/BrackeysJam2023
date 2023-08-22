using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLukasPlayer : WeaponLukas
{
    private Player _player;

    private int countBullets;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
        countBullets = _player.Bullets;
        EventAgregator.updateBullet.AddListener(UpdateCointBullets);
    }

    private void UpdateCointBullets()
    {
        countBullets = _player.Bullets;
    }

    public override void Fire()
    {
        if (countBullets > 0)
        {
            EventAgregator.playerDoShot.Invoke();
            countBullets = _player.Bullets;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
        }
    }
}
