using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Pack", menuName = "Create Sound Pack")]
public class SoundPackSO : ScriptableObject
{
    public AudioClip playerGetDamageSound;
    public AudioClip onClick;
    public AudioClip cursorOnButton;
}
