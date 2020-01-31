using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController2D))]
public class PlayerController : MonoBehaviour {
    public float runSpeed = 5.0f;
    private float horizontalMovement = 0.0f;
    
    private CharacterController2D controller;
    private Animator animator;
    private bool jumping = false;

    private void Start() {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        horizontalMovement = Input.GetAxis("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            //Debug.Log("Jumped");
            jumping = true;
        }

        animator.SetFloat("Speed", controller.speed);
        animator.SetBool("Jumping", !controller.isGrounded);
    }

    void FixedUpdate() {
        controller.Move(horizontalMovement, false, jumping);
        jumping = false;
    }
}
