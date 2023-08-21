using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI playerBullets;

    private Player _player;

    private void Awake()
    {
        EventAgregator.updateUI.AddListener(UpdateUI);
    }

    private void UpdateUI()
    {
        playerHP.text = _player.HP.ToString();
        playerScore.text = _player.Score.ToString();
        playerBullets.text = _player.Bullets.ToString();
    }

    void Start()
    {
        _player = FindObjectOfType<Player>();

        playerHP.text = _player.HP.ToString();
        playerScore.text = _player.Score.ToString();
        playerBullets.text = _player.Bullets.ToString();
    }
}
