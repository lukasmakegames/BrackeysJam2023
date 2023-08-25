using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoaderTriger : MonoBehaviour
{
    public ENameOfLevel nextScene;

    public Button loadNextScene;
    public GameObject textForPlayer;

    public int scoreForLoadNewScene = 50;

    public void LoadNextScene()
    {
        EventAgregator.playerEndLevel.Invoke();
        SceneManager.LoadScene(nextScene.ToString());
    }

    void Start()
    {
        textForPlayer.SetActive(false);
        loadNextScene.onClick.AddListener(LoadNextScene);
        loadNextScene.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Player.ScoreOfLevel < scoreForLoadNewScene)
            {
                textForPlayer.SetActive(true);
            }
            else
            {
                loadNextScene.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textForPlayer.SetActive(false);
            loadNextScene.gameObject.SetActive(false);
        }
    }
}
