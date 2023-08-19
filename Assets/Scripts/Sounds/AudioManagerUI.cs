using UnityEngine;
using UnityEngine.UI;

public class AudioManagerUI : MonoBehaviour
{
    public readonly static string musikKey = "MusikKey";
    public readonly static string soundsKey = "SoundsKey";
    public Slider musicSlider;
    public Slider soundsSlider;


    public void SaveMusicChange()
    {
        PlayerPrefs.SetFloat(musikKey, musicSlider.value);
        PlayerPrefs.Save();
        EventAgregator.editVolumeMusic.Invoke(musicSlider.value);
    }

    public void SaveSoundsChange()
    {
        PlayerPrefs.SetFloat(soundsKey, soundsSlider.value);
        PlayerPrefs.Save();
        EventAgregator.editVolumeSound.Invoke(soundsSlider.value);
        Debug.Log("SaveSoundsChange " + soundsSlider.value);
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey(musikKey))
        {
            musicSlider.value = PlayerPrefs.GetFloat(musikKey);
        }

        if (PlayerPrefs.HasKey(soundsKey))
        {
            soundsSlider.value = PlayerPrefs.GetFloat(soundsKey);
        }
    }

    private void Awake()
    {
        LoadSettings();
    }
}
