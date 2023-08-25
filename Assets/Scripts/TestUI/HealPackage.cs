using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPackage : MonoBehaviour
{
    public int healCount = 5;

    private Player _player;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player.AddHP(healCount);

            Destroy(this.gameObject);
        }
    }
}
