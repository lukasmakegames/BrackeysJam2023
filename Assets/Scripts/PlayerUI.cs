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
        playerHP.text = "HP:" + _player.HP.ToString();
        playerScore.text = "SCORE:" + Player.ScoreOfLevel.ToString();
        playerBullets.text = "BULLETS:" + _player.Bullets.ToString();
        playerGlobalScore.text = "GLOBAL SCORE:" + Player.GlobalScore.ToString();
        playerInvestigationPoints.text = "RUNE POINTS:" + Player.FragmentsOfRune.ToString();
    }

    void Start()
    {
        _player = FindObjectOfType<Player>();



        UpdateUI();
    }
}
