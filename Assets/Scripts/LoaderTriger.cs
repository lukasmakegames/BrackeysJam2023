using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderTriger : MonoBehaviour
{
    public ENameOfLevel nextScene;

    public Button loadNextScene;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene.ToString());
    }

    void Start()
    {
        loadNextScene.onClick.AddListener(LoadNextScene);
        loadNextScene.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            loadNextScene.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            loadNextScene.gameObject.SetActive(false);
        }
    }
}
