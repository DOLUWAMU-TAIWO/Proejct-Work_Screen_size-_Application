using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var cameraDropdown = root.Q<DropdownField>("CameraDropdown"); // Assuming you named your dropdown "CameraDropdown"

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
