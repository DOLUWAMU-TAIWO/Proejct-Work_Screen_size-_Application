using UnityEngine.UIElements;
using UnityEngine;

public class ViewSelection : MonoBehaviour
{
    public Camera_Controller cube;
    public UIDocument uiDocument; // Drag your UIDocument component in the Inspector
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script
    public ViewMode viewMode; // Reference to the ViewMode class
    public DropdownController dropdownController; // Reference to the DropdownController script

    private DropdownField dropdown;
    private string lastSelectedValue = ""; // To keep track of the last selected value

    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;
        dropdown = root.Q<DropdownField>("CameraDropdown");

        // Subscribe to the change event of the dropdown
        dropdown.RegisterValueChangedCallback(evt =>
        {
            string selectedValue = evt.newValue;

            switch (selectedValue)
            {
                case "Camera 1":
                    cube.choose_camera_main();
                    playerMovement.DisableCursorControl();
                    viewMode.ToggleUIAndObjects(true);
                    break;
                case "Camera 2":
                    cube.choose_camera_2();
                    playerMovement.DisableCursorControl();
                    viewMode.ToggleUIAndObjects(true);
                    break;
                case "Camera 3":
                    cube.choose_camera_3();
                    playerMovement.DisableCursorControl();
                    viewMode.ToggleUIAndObjects(true);
                    break;
                case "Camera 4":
                    cube.choose_camera_4();
                    playerMovement.DisableCursorControl();
                    viewMode.ToggleUIAndObjects(true);
                    break;
                case "Camera 5":
                    cube.choose_camera_5();
                    playerMovement.DisableCursorControl();
                    viewMode.ToggleUIAndObjects(true);
                    break;
                case "Player Mode":
                    cube.choose_camera_4(); // Assuming Camera 4 is for player mode
                    playerMovement.EnableCursorControl();
                    viewMode.ToggleUIAndObjects(false); // Hide UI and GameObjects
                    break;
                default:
                    playerMovement.DisableCursorControl();
                    viewMode.ToggleUIAndObjects(true);
                    // Reset dropdown if previously in Player Mode and now exiting it
                    if (lastSelectedValue == "Player Mode")
                    {
                        ResetDropdownToEmpty();
                    }
                    break;
            }

            lastSelectedValue = selectedValue; // Update the last selected value
        });
    }

    public void ResetDropdownToEmpty()
    {
        if (dropdownController != null && dropdownController.cameraDropdown != null)
        {
            // Clear the value of the dropdown
            dropdownController.cameraDropdown.value = null;
        }
    }
}
