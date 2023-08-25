using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI playerGlobalScore;
    public TextMeshProUGUI playerBullets;
    public TextMeshProUGUI playerInvestigationPoints;

    private Player _player;

    private void Awake()
    {
        EventAgregator.updateUI.AddListener(UpdateUI);
    }

    private void UpdateUI()
    {
        playerHP.text = _player.HP.ToString();
        playerScore.text = Player.ScoreOfLevel.ToString();
        playerBullets.text = _player.Bullets.ToString();
        playerGlobalScore.text = Player.GlobalScore.ToString();
        playerInvestigationPoints.text = _player.FragmentsOfRune.ToString();
    }

    void Start()
    {
        _player = FindObjectOfType<Player>();

        playerHP.text = _player.HP.ToString();
        playerScore.text = Player.ScoreOfLevel.ToString();
        playerBullets.text = _player.Bullets.ToString();
        playerGlobalScore.text = Player.GlobalScore.ToString();
        playerInvestigationPoints.text = _player.FragmentsOfRune.ToString();
    }
}
