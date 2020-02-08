using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController2D))]
public class PlayerController : MonoBehaviour {
    public float runSpeed = 5.0f;
    private float horizontalMovement = 0.0f;
    private float verticalMovement = 0.0f;
    
    private CharacterController2D controller;
    private Animator animator;
    private bool jumping = false;
    private bool attacking = false;
    private bool crouching = false;

    [SerializeField] private float respawnThreshold = -8;
    private Vector3 respawnPosition = new Vector3((float)-3.835, (float)-1.282, (float)-6.45269);

    private void Start() {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        horizontalMovement = Input.GetAxis("Horizontal") * runSpeed;
        verticalMovement = Input.GetAxis("Vertical") * runSpeed;

        // Jump
        if (Input.GetButtonDown("Jump")) {
            jumping = true;
        }

        // Attack
        if (Input.GetButtonDown("Fire1")) {
            attacking = true;
        }

        /*
        // Crouch
        if (Input.GetButtonDown("Crouch")) {
            crouching = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouching = false;
        }
        */

        animator.SetFloat("Speed", controller.speed);
        animator.SetBool("Jumping", !controller.isGrounded);
        animator.SetBool("Attacking", attacking);
        //animator.SetBool("Crouching", crouching);
    }

    void FixedUpdate() {
        controller.Move(horizontalMovement, verticalMovement, false, jumping);
        jumping = false;
        attacking = false;

        // Basic "respawn" if player falls in water
        if (transform.position.y < respawnThreshold) {
            transform.position = respawnPosition;
        }
    }
}
