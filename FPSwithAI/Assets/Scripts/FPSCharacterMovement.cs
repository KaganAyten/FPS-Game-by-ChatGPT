using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FPSCharacterMovement : MonoBehaviour
{
    // The speed at which the character moves
    public float movementSpeed = 10.0f;

    // The force added to the character when jumping
    public float jumpForce = 10.0f;

    // A reference to the character's rigidbody
    private Rigidbody rb;

    // The speed at which the player will move while wall running
    public float wallRunSpeed = 10.0f;

    // The force with which the player will jump off the wall
    public float wallJumpForce = 10.0f;

    // The layer on which the wall colliders are placed
    public LayerMask wallLayer;

    public bool isGrounded;

    void Start()
    {
        // Get a reference to the character's rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get the horizontal and vertical input axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector based on the input axes
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * movementSpeed;
        movement.y = rb.velocity.y;

        // Convert the movement vector from global space to local space
        movement = transform.TransformDirection(movement);

        // Add the movement vector to the character's velocity
        rb.velocity = movement;

        // If the jump button is pressed and the character is grounded, add the jump force to the character 
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce);
            bool isColliding = Physics.CheckSphere(transform.position, 0.5f, wallLayer);

            // If the sphere is colliding with a wall
            if (isColliding)
            {
                // Set the velocity of the player to move along the wall
                rb.velocity = transform.forward * movementSpeed;

                // Set the player to a state where it is wall running
                rb.useGravity = false;
            }
        }
        if (Input.GetButtonDown("Jump") && !rb.useGravity)
        {
            // Add force to the player in the upward direction to make it jump off the wall

            // Set the player to a state where it is affected by gravity
            rb.useGravity = true;
        } 
    }
}
 