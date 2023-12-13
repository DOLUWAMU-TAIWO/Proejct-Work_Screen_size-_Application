using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed.
    public float mouseSensitivity = 2f; // Sensitivity of mouse movement.

    private CharacterController characterController;
    private Transform playerTransform; // Transform component of the player.
    private bool isCursorLocked = false; // State of the cursor lock.
    private bool canMove = false; // Determines if the player can move.

    private float horizontalRotation = 0f; // Stores the horizontal rotation angle.

    void Start()
    {
        // Initialize characterController and playerTransform at the start.
        characterController = GetComponent<CharacterController>();
        playerTransform = transform; // Assign the Transform component of this GameObject.
    }

    void Update()
    {
        // Check if the player can move and if the cursor is locked.
        if (canMove && isCursorLocked)
        {
            // Handle player movement based on input.
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate movement direction and normalize it.
            Vector3 moveDirection = playerTransform.forward * verticalInput + playerTransform.right * horizontalInput;
            moveDirection.Normalize(); // Ensure consistent movement speed in all directions.

            // Apply movement to the character controller.
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

            // Handle player rotation based on mouse movement.
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            horizontalRotation += mouseX;
            horizontalRotation = Mathf.Clamp(horizontalRotation, -70f, 70f); // Constrain rotation to prevent over-rotation.
            playerTransform.localRotation = Quaternion.Euler(0f, horizontalRotation, 0f);
        }

        // Toggle cursor lock state when the 'C' key is pressed.
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCursorLocked = !isCursorLocked;
            LockCursor(); // Apply the new cursor lock state.
        }
    }

    private void LockCursor()
    {
        // Set cursor lock state and visibility based on isCursorLocked.
        Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isCursorLocked; // Hide cursor when locked, show when unlocked.
    }

    public void EnableCursorControl()
    {
        // Enable cursor control and player movement.
        isCursorLocked = true;
        canMove = true; 
        LockCursor(); // Apply cursor lock.
    }

    public void DisableCursorControl()
    {
        // Disable cursor control and player movement.
        isCursorLocked = false;
        canMove = false;
        LockCursor(); // Apply cursor lock.
    }
}
