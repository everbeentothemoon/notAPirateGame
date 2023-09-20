using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelScript : MonoBehaviour
{
    public float flySpeed = 5.0f; // Forward flying speed
    public float ascentSpeed = 5000000.0f; // Speed for ascending
    public float descentSpeed = 5000000.0f; // Speed for descending
    public float rotationSpeed = 2.0f; // Rotation speed while flying
    public float maxFlySpeed = 10.0f; // Maximum flying speed
    public float speedMultiplier = 1000.0f; // Speed multiplier


    private bool isFlying = false; // Flag to track flying mode
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Toggle flying mode when pressing the "X" key
        if (Input.GetKeyDown(KeyCode.X))
        {
            isFlying = !isFlying;


            // Enable or disable Rigidbody gravity based on flying mode
            rb.useGravity = !isFlying;
        }


        // If in flying mode, allow movement in the direction the camera is facing
        if (isFlying)
        {
            // Calculate the movement direction based on camera forward
            Vector3 moveDirection = Camera.main.transform.forward.normalized;

            // Separate vertical input for ascent and descent
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate movement for ascent and descent separately
            Vector3 ascentMovement = Vector3.up * verticalInput * ascentSpeed * Time.deltaTime * speedMultiplier;
            Vector3 descentMovement = Vector3.down * verticalInput * descentSpeed * Time.deltaTime * speedMultiplier;

            // Combine both movements
            Vector3 totalMovement = (ascentMovement + descentMovement) + (moveDirection * verticalInput * flySpeed * Time.deltaTime * speedMultiplier);

            // Apply total movement
            rb.velocity = Vector3.ClampMagnitude(totalMovement, maxFlySpeed);

            // Rotate the player based on horizontal input
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 rotation = new Vector3(0, horizontalInput * rotationSpeed, 0);
            transform.Rotate(rotation);
        }

    }
}
