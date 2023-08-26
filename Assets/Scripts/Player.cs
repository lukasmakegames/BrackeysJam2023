using UnityEngine;

public class Player : MonoBehaviour
{
    private float _HP;
    private int _bullets;
    private static int _scoreOfLevel;
    private static int _fragmentsOfRune;
    private static int _globalScore;

    public float HP => _HP;
    public int Bullets => _bullets;
    public static int ScoreOfLevel => _scoreOfLevel;
    public static int GlobalScore => _globalScore;
    public static int FragmentsOfRune => _fragmentsOfRune;

    private string scoreGlobalKey = "scoreGlobalKey";

    private void Awake()
    {
        LoadHP();
        _scoreOfLevel = 0;
        _fragmentsOfRune = 0;
        EventAgregator.playerLostHP.AddListener(UpdateHP);
        EventAgregator.playerDoShot.AddListener(ShotBullet);
        EventAgregator.updateScore.AddListener(UpdateScore);
        EventAgregator.playerEndLevel.AddListener(SaveScore);
        EventAgregator.playerAddRune.AddListener(AddFragmentsOfRune);
        EventAgregator.saveHP.AddListener(SaveHP);
        LoadGlobalScore();
    }

    private void LoadGlobalScore()
    {
        _globalScore = PlayerPrefs.GetInt(scoreGlobalKey);

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
        if (_HP <= 0)
        {
            EventAgregator.playerDead.Invoke();
            AudioManager.Instance.PlayerDead(transform.position);
        }
        AudioManager.Instance.PlayPlayerGetDamage(transform.position);
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
        AudioManager.Instance.PlayerAddBullets(transform.position);
        EventAgregator.updateUI.Invoke();
    }

    public void AddHP(int hp)
    {
        _HP += hp;
        if (_HP > 100)
        {
            _HP = 100;
        }
        AudioManager.Instance.PlayerAddHP(transform.position);
        EventAgregator.updateUI.Invoke();
    }

    public void AddScore(int score)
    {
        _scoreOfLevel += score;
        EventAgregator.updateUI.Invoke();
    }

    public void AddFragmentsOfRune(int score)
    {
        _fragmentsOfRune += score;
        EventAgregator.updateUI.Invoke();
    }

    public void SaveHP() {
        PlayerPrefs.SetFloat("PlayerHP", _HP);
    }
    public void LoadHP()
    {
            _HP = PlayerPrefs.GetFloat("PlayerHP");
            if(_HP  == 0){
                        _HP = 100;
            }
    }
}
