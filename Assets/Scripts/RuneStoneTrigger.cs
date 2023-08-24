using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStoneTrigger : MonoBehaviour
{
  public DialogueTrigger dialogueTrigger;

     private void OnTriggerEnter(Collider other)
    {
     if (other.tag == "Player")
     {
        dialogueTrigger.TriggerDialogue();
     }
    }
}
