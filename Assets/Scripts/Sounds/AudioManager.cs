using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;

    [SerializeField] SoundPackSO soundPackSO;

    public static AudioManager Instance { get; private set; }

    private float musicVolume;
    private float soundVolume;
    private void Awake()
    {
        if (PlayerPrefs.HasKey(AudioManagerUI.musikKey))
        {
            musicVolume = PlayerPrefs.GetFloat(AudioManagerUI.musikKey);
            PlayMusic(musicVolume);
        }
        else
        {
            PlayMusic(1);
        }

        if (PlayerPrefs.HasKey(AudioManagerUI.soundsKey))
        {
            soundVolume = PlayerPrefs.GetFloat(AudioManagerUI.soundsKey);
        }

        else
        {
            soundVolume = 1;
        }
    }

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnDisable()
    {
        Instance = null;
    }

    private void Start()
    {
        EventAgregator.editVolumeMusic.AddListener(EditVolumeMusic);
        EventAgregator.editVolumeSound.AddListener(EditSoundVolume);
    }

    private void PlayMusic(float volume)
    {
        music.volume = volume;
        music.loop = true;
        music.Play();
    }

    private void EditVolumeMusic(float volume)
    {
        music.volume = volume;
    }

    private void EditSoundVolume(float volume)
    {
        soundVolume = volume;

        Debug.Log(soundVolume);
    }

    //plays needed sound
    private void PlaySound(AudioClip clip, Vector2 position, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }

    //plays random sound from array
    private void PlaySound(AudioClip[] clipArray, Vector2 position, float volume)
    {
        AudioSource.PlayClipAtPoint(clipArray[Random.Range(0, clipArray.Length)], position, volume);
    }

    public void PlayPlayerGetDamage(Vector2 transform)
    {
        PlaySound(soundPackSO.playerGetDamageSound, transform, soundVolume);
    }

    public void PlayerAddHP(Vector2 transform)
    {
        PlaySound(soundPackSO.playerAddHP, transform, soundVolume);
    }

    public void PlayerAddBullets(Vector2 transform)
    {
        PlaySound(soundPackSO.playerAddAmmo, transform, soundVolume);
    }

    public void PlayerShot(Vector2 transform)
    {
        PlaySound(soundPackSO.playerShot, transform, soundVolume);
    }

    public void EnemyShot(Vector2 transform)
    {
        PlaySound(soundPackSO.enemyShot, transform, soundVolume);
    }

    public void PlayOnClick()
    {
        PlaySound(soundPackSO.onClick, this.transform.position, soundVolume);
    }

    public void PlayCursorOnButton()
    {
        PlaySound(soundPackSO.cursorOnButton, this.transform.position, soundVolume);
    }

    public void PlayerDead(Vector2 transform)
    {
        PlaySound(soundPackSO.playerDead, transform, soundVolume);
    }

    public void EnemyDead(Vector2 transform)
    {
        PlaySound(soundPackSO.enemyDead, transform, soundVolume);
    }
}
