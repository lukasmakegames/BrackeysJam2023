using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPackageTest : MonoBehaviour
{
    public int bulletCount = 5;
    public int score = 100;
    private Player _player;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player.AddBullets(bulletCount);
            _player.AddScore(score);
            EventAgregator.updateBullet.Invoke();
            Destroy(this.gameObject);
        }
    }
}
