using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiveDeeper : MonoBehaviour
{
    public Slider diveDeeperSliderValue;
    public float maxDeeperOnLevel = 100f;
    private float _diveDeeperValue;

    public float DiveDeeperValue => _diveDeeperValue;

    private string _scene;

    private Player _player;
    void Start()
    {
        _scene = SceneManager.GetActiveScene().name;
        _player = FindObjectOfType<Player>();
        diveDeeperSliderValue.maxValue = maxDeeperOnLevel;
        EventAgregator.updateUI.AddListener(UpdateDiveDeep);
    }

    private void CheckDeep()
    {
        switch (_scene)
        {
            case "Scene1":
                _diveDeeperValue = 10;
                break;
            case "Scene2":
                _diveDeeperValue = 20;
                break;
            case "Scene3":
                _diveDeeperValue = 40;
                break;
            case "Scene4":
                _diveDeeperValue = 70;
                break;
            case "Scene5":
                _diveDeeperValue = 90;
                break;
            default:
                break;
        }

        diveDeeperSliderValue.value = _diveDeeperValue;
    }

    private void UpdateDiveDeep()
    {
        diveDeeperSliderValue.value = _player.FragmentsOfRune;
    }
}
