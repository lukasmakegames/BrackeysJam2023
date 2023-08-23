using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressingPlate : MonoBehaviour
{
    public UnityEvent<float> OnPressed;
    public UnityEvent<float> OnFree;

    private void OnTriggerEnter(Collider other)
    {
        OnPressed.Invoke(other.attachedRigidbody.mass);
    }

    private void OnTriggerExit(Collider other)
    {
        OnFree.Invoke(other.attachedRigidbody.mass);
    }
}
