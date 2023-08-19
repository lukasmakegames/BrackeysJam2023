using UnityEngine;

public class Player : MonoBehaviour
{
    private int _HP;

    public int HP => _HP;

    private void Awake()
    {
        EventAgregator.playerLostHP.AddListener(UpdateHP);
    }

    private void UpdateHP()
    {
        _HP--;
        EventAgregator.updateUI.Invoke();
    }
}
