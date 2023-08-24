using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemies;
    private DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        enemies.SetActive(false);
        dialogueManager=FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.ended)
        {
            enemies.SetActive(true);

        }
    }
}
