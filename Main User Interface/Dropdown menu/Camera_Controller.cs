using UnityEngine;

// Controller script for managing multiple camera views in the game.
public class Camera_Controller : MonoBehaviour
{
    // Serialized fields for camera references. Set these in the Unity Editor.
    [SerializeField] private Camera camera_main, camera_2, camera_3, camera_4, camera_5, camera_6;

    // Reference to the main target for the camera.
    public Transform target_main;

    // Canvas for UI elements.
    public Canvas canvas;

    // Script controlling player movement.
    public PlayerMovement playerMovement;

    // Script for handling view selection logic.
    public ViewSelection viewSelection; 

    // Called when the script instance is being loaded.
    void Start()
    {
        // Initialize the camera setup.
        ResetCameraState();
    }

    // Activates the main camera view.
    public void choose_camera_main()
    {
        SetCameraState(camera_main);
        // Enable UI canvas and disable cursor control when this camera is active.
        canvas.enabled = true;
        playerMovement.DisableCursorControl();
    }

    // Activates the second camera view.
    public void choose_camera_2()
    {
        SetCameraState(camera_2);
        canvas.enabled = true;
        playerMovement.DisableCursorControl();
    }

    // Activates the third camera view.
    public void choose_camera_3()
    {
        SetCameraState(camera_3);
        canvas.enabled = true;
        playerMovement.DisableCursorControl();
    }

    // Activates the fourth camera view.
    public void choose_camera_4()
    {
        SetCameraState(camera_4);
        // Toggles the canvas state and enables cursor control for this view.
        ToggleCanvas();
        playerMovement.EnableCursorControl();
    }

    // Activates the fifth camera view.
    public void choose_camera_5()
    {
        SetCameraState(camera_5);
        canvas.enabled = true;
        playerMovement.DisableCursorControl();
    }

    // Activates the sixth camera view.
    public void choose_camera_6()
    {
        SetCameraState(camera_6);
        canvas.enabled = true;
        playerMovement.DisableCursorControl();
    }

    // Update is called once per frame.
    void Update()
    {
        // Check for the Escape key press to reset the camera to the default state.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetCameraState();
            if (canvas != null)
            {
                canvas.enabled = true;
                playerMovement.DisableCursorControl();
                // Resets the dropdown selection in the UI if needed.
                if (viewSelection != null)
                {
                    viewSelection.ResetDropdownToEmpty();
                }
            }
        }
    }

    // Resets the camera state to the default view.
    private void ResetCameraState()
    {
        SetCameraState(camera_main);
    }

    // Enables the given camera and disables all others.
    private void SetCameraState(Camera activeCamera)
    {
        // First, disable all cameras.
        DisableAllCameras();
        // Then, enable the selected camera.
        activeCamera.enabled = true;
    }

    // Disables all cameras in the scene.
    private void DisableAllCameras()
    {
        camera_main.enabled = false;
        camera_2.enabled = false;
        camera_3.enabled = false;
        camera_4.enabled = false;
        camera_5.enabled = false;
        camera_6.enabled = false;
    }

    // Toggles the visibility of the canvas.
    private void ToggleCanvas()
    {
        if (canvas != null)
        {
            // Flip the enabled state of the canvas.
            canvas.enabled = !canvas.enabled;
        }
    }
}
