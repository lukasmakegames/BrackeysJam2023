using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI playerHP;

    private Player _player;

    private void Awake()
    {
        EventAgregator.updateUI.AddListener(UpdateHP);
    }

    private void UpdateHP()
    {
        playerHP.text = _player.HP.ToString();
    }

    void Start()
    {
        _player = FindObjectOfType<Player>();
    }
}
