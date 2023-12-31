using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Pack", menuName = "Create Sound Pack")]
public class SoundPackSO : ScriptableObject
{
    public AudioClip playerGetDamageSound;
    public AudioClip onClick;
    public AudioClip cursorOnButton;
    public AudioClip playerShot;
    public AudioClip enemyShot;
    public AudioClip playerAddHP;
    public AudioClip playerAddAmmo;
    public AudioClip playerDead;
    public AudioClip enemyDead;
}
