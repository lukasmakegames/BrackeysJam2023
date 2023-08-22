using UnityEngine;

public class Player : MonoBehaviour
{
    private float _HP;
    private int _bullets;
    private static int _scoreOfLevel;
    private static int _globalScore;

    public float HP => _HP;
    public int Bullets => _bullets;
    public static int ScoreOfLevel => _scoreOfLevel;
    public static int GlobalScore => _globalScore;

    private string scoreGlobalKey = "scoreGlobalKey";

    private void Awake()
    {
        _scoreOfLevel = 0;
        EventAgregator.playerLostHP.AddListener(UpdateHP);
        EventAgregator.playerDoShot.AddListener(ShotBullet);
        EventAgregator.updateScore.AddListener(UpdateScore);
        EventAgregator.playerEndLevel.AddListener(SaveScore);
    }

    public static void ClearGlobalScore() // This method need add when startGame
    {
        _globalScore = 0;
        PlayerPrefs.SetInt("scoreGlobalKey", _globalScore);
    }

    private void SaveScore()
    {
        _globalScore += _scoreOfLevel;
        PlayerPrefs.SetInt(scoreGlobalKey, _globalScore);
    }

    public void SetStartHP(float hp)
    {
        _HP = hp;
    }
    private void UpdateHP(float amount)
    {
        _HP -= amount;
        EventAgregator.updateUI.Invoke();
    }

    private void ShotBullet()
    {
        _bullets--;
        AudioManager.Instance.PlayerShot(transform.position);
        EventAgregator.updateUI.Invoke();
    }

    private void UpdateScore(int score)
    {
        _scoreOfLevel += score;
        EventAgregator.updateUI.Invoke();
    }

    public void AddBullets(int bulets)
    {
        _bullets += bulets;
        EventAgregator.updateUI.Invoke();
    }

    public void AddHP(int hp)
    {
        _HP += hp;
        if (_HP > 100)
        {
            _HP = 100;
        }
        EventAgregator.updateUI.Invoke();
    }

    public void AddScore(int score)
    {
        _scoreOfLevel += score;
        EventAgregator.updateUI.Invoke();
    }
}
