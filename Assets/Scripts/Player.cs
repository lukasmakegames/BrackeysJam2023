using UnityEngine;

public class Player : MonoBehaviour
{
    private float _HP;
    private int _bullets;
    private int _score;

    public float HP => _HP;
    public int Bullets => _bullets;
    public int Score => _score;

    private void Awake()
    {
        EventAgregator.playerLostHP.AddListener(UpdateHP);
        EventAgregator.playerDoShot.AddListener(ShotBullet);
        EventAgregator.updateScore.AddListener(UpdateScore);
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
        EventAgregator.updateUI.Invoke();
    }

    private void UpdateScore(int score)
    {
        _score += score;
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
        _score += score;
        EventAgregator.updateUI.Invoke();
    }
}
