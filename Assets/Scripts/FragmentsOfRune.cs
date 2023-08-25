using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentsOfRune : MonoBehaviour
{
    public int fragmentsOfRuneCount = 5;
    public GameObject destroyEffect;
    public int score = 5;
    private Player _player;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player.AddFragmentsOfRune(fragmentsOfRuneCount);
            _player.AddScore(score);
            Instantiate(destroyEffect, this.transform.position, Quaternion.identity);
            EventAgregator.updateUI.Invoke();
            Destroy(this.gameObject);
        }
    }
}