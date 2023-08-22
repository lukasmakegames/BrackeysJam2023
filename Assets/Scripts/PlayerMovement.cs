using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed = 2f;
    public float jumpHeight = 3f;

    private Rigidbody rigidbody;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

  
    void Update() {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidbody.AddForce(Vector3.up * jumpHeight);
        }

        rigidbody.velocity += new Vector3(xMove, 0, zMove) * playerSpeed;
 
     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

     Vector3 mouseDirection = mousePos - transform.position;

     transform.rotation = Quaternion.LookRotation(mouseDirection, Vector3.up);
 
 
    }
    
}