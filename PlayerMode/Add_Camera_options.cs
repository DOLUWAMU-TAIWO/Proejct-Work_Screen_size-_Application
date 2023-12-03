using UnityEngine;
using UnityEngine.UIElements;

public class DropdownController : MonoBehaviour
{
    public DropdownField cameraDropdown; // Public reference to the DropdownField

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        cameraDropdown = root.Q<DropdownField>("CameraDropdown"); // Assuming you named your dropdown "CameraDropdown"

        // Clear existing choices
        cameraDropdown.choices.Clear();

        // Add camera options
        for (int i = 1; i <= 5; i++)
        {
            cameraDropdown.choices.Add("Camera " + i);
        }

        // Add player mode
        cameraDropdown.choices.Add("Player Mode");
    }

}
