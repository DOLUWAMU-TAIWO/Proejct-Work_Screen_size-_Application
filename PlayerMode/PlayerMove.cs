using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control movement speed
    public float mouseSensitivity = 2f; // Adjust this to control mouse sensitivity

    private CharacterController characterController;
    private Transform playerTransform; // Reference to the player's transform.
    private bool isCursorLocked = false; // Start with cursor unlocked
    private bool canMove = false; // Flag to control movement

    private float horizontalRotation = 0f; // Variable to store horizontal rotation

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerTransform = transform; // Get the player's transform.
    }

    void Update()
    {
        if (canMove && isCursorLocked)
        {
            // Player movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = playerTransform.forward * verticalInput + playerTransform.right * horizontalInput;
            moveDirection.Normalize(); // Normalize to ensure consistent speed in all directions.

            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

            // Player rotation based on mouse input
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            horizontalRotation += mouseX;
            horizontalRotation = Mathf.Clamp(horizontalRotation, -70f, 70f); // Limit horizontal rotation
            playerTransform.localRotation = Quaternion.Euler(0f, horizontalRotation, 0f);
        }

        // Toggle cursor lock state with a specific key
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCursorLocked = !isCursorLocked;
            LockCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isCursorLocked;
    }

    public void EnableCursorControl()
    {
        isCursorLocked = true;
        canMove = true; // Enable movement
        LockCursor();
    }

    public void DisableCursorControl()
    {
        isCursorLocked = false;
        canMove = false; // Disable movement
        LockCursor();
    }
}
