using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    Vector3 playerVelocity;
    Vector3 move;

    private bool hasBlueOrb = false;

    public float walkSpeed = 5;
    public float runSpeed = 8;
    public float jumpHeight = 2;
    public float gravity = -9.18f;

    private int jumpCount = 0;
    public int maxJumpCount = 2; // Adjust this value to allow more or fewer double jumps if needed.


    private CharacterController controller;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        ProcessMovement();
        ProcessGravity();
    }

    public void CollectBlueOrb()
    {
        hasBlueOrb = true; // Called when the player collects a blue orb.
    }

    public bool HasBlueOrb()
    {
        return hasBlueOrb; // Check if the player has a blue orb.
    }


    public void LateUpdate()
    {
        UpdateAnimator();
    }

    void DisableRootMotion()
    {
        animator.applyRootMotion = false;
    }

    void UpdateAnimator()
    {
        bool isGrounded = controller.isGrounded;

        animator.SetBool("Jump", !isGrounded && jumpCount > 0);
        animator.SetBool("DoubleJump", false); // Reset DoubleJump animation.

        if (!isGrounded)
        {
            if (jumpCount == 1 && !hasBlueOrb)
            {
                animator.SetBool("DoubleJump", true); // Play DoubleJump animation for a legitimate double jump.
            }
        }

        if (move != Vector3.zero)
        {
            if (GetMovementSpeed() == runSpeed)
            {
                animator.SetFloat("Speed", 1.0f);
            }
            else
            {
                animator.SetFloat("Speed", 0.5f);
            }
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }

        animator.SetBool("isGrounded", isGrounded);
    }



    void ProcessMovement()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    public void ProcessGravity()
    {
        bool isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            jumpCount = 0; // Reset jump count when grounded.

            if (playerVelocity.y < 0.0f)
            {
                playerVelocity.y = -1.0f;
            }

            if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
                jumpCount++;
            }
        }
        else
        {
            // Check for double jump if the player has a blue orb.
            if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount && hasBlueOrb)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
                jumpCount++;
                hasBlueOrb = false; // Consume the blue orb.
            }

            playerVelocity.y += gravity * Time.deltaTime;
        }

        controller.Move(move * Time.deltaTime * GetMovementSpeed() + playerVelocity * Time.deltaTime);
    }



    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }
}
