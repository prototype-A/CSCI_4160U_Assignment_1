using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    public float movementSpeed = 5.0f;
    public float jumpForce = 300.0f;

    private Rigidbody2D rigidBody;
    private bool isGrounded = true;

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        float movementX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        // Player Jump
        if (Input.GetButtonDown("Jump")) {
            if (isGrounded) {
                isGrounded = false;
                rigidBody.AddForce(transform.up * jumpForce);
            }
        }

        // Player hits ground
        if (rigidBody.velocity[1] == 0) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }

        transform.Translate(new Vector3(movementX, 0.0f, 0.0f));
    }
}
