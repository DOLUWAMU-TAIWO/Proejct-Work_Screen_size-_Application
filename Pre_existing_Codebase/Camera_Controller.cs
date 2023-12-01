using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] private Camera camera_main, camera_2, camera_3, camera_4, camera_5, camera_6;
    public Transform target_main;
    public Canvas canvas;
    public PlayerMovement playerMovement;
    public ViewSelection viewSelection; // Reference to ViewSelection script

    void Start()
    {
        ResetCameraState();
    }

    public void choose_camera_main()
    {
        SetCameraState(camera_main);
        canvas.enabled = true;
        playerMovement.DisableCursorControl();
    }

    public void choose_camera_2()
    {
        SetCameraState(camera_2);
        canvas.enabled = true;
        playerMovement.DisableCursorControl();
    }

    public void choose_camera_3()
    {
        SetCameraState(camera_3);
        canvas.enabled = true;
        playerMovement.DisableCursorControl();
    }

    public void choose_camera_4()
    {
        SetCameraState(camera_4);
        ToggleCanvas();
        playerMovement.EnableCursorControl();
    }

    public void choose_camera_5()
    {
        SetCameraState(camera_5);
        canvas.enabled = true;
        playerMovement.DisableCursorControl();
    }

    public void choose_camera_6()
    {
        SetCameraState(camera_6);
        canvas.enabled = true;
        playerMovement.DisableCursorControl();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetCameraState();
            if (canvas != null)
            {
                canvas.enabled = true;
                playerMovement.DisableCursorControl();
                // Call to reset the dropdown
                if (viewSelection != null)
                {
                    viewSelection.ResetDropdownToEmpty();
                }
            }
        }
    }

    private void ResetCameraState()
    {
        SetCameraState(camera_main);
    }

    private void SetCameraState(Camera activeCamera)
    {
        DisableAllCameras();
        activeCamera.enabled = true;
    }

    private void DisableAllCameras()
    {
        camera_main.enabled = false;
        camera_2.enabled = false;
        camera_3.enabled = false;
        camera_4.enabled = false;
        camera_5.enabled = false;
        camera_6.enabled = false;
    }

    private void ToggleCanvas()
    {
        if (canvas != null)
        {
            canvas.enabled = !canvas.enabled;
        }
    }
}
