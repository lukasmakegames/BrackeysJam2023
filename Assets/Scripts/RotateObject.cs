using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // Adjust the rotation axis
    public float rotationSpeed = 30.0f; // Adjust the rotation speed

    void Update()
    {
        // Rotate the object around the specified axis
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}


