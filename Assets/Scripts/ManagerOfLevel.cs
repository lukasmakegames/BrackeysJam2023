using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerOfLevel : MonoBehaviour
{
    public ENameOfLevel currentScene;
    private string currentSceneString => currentScene.ToString();
    private string _currentSceneKey;

    private void Awake()
    {
        EventAgregator.playerDead.AddListener(SaveCurrentScene);
        EventAgregator.playerDead.AddListener(LoadLoseScene);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("LoseScene");
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void LoadSaveScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(_currentSceneKey));
    }

    public void SaveCurrentScene()
    {
        PlayerPrefs.SetString(_currentSceneKey, currentSceneString);
    }

    public void ClearGlobalScore() // This method need add when startGame
    {
        PlayerPrefs.SetInt("scoreGlobalKey", 0);
    }

    public void ResetHP() // This method need add when startGame
    {
        PlayerPrefs.SetFloat("PlayerHP", 100);
    }
}
