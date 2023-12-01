using UnityEngine;
using UnityEngine.UIElements;

public class EscapePlayerModeToggle : MonoBehaviour
{
    public UIDocument uiDocument; // Drag your UIDocument component for player mode in the Inspector
    public UIDocument escapeMessageUIDocument; // Assign the UIDocument for the "Press Escape to Exit" in the inspector
    public DropdownField dropdown; // Reference to the DropdownField in your UI

    private void Awake()
    {
        // Make sure the escape message UI document is not visible when the game starts
        escapeMessageUIDocument.rootVisualElement.style.display = DisplayStyle.None;
    }

    private void OnEnable()
    {
        // Assuming your dropdown is part of the uiDocument, otherwise assign it from the appropriate UIDocument
        dropdown = uiDocument.rootVisualElement.Q<DropdownField>("CameraDropdown");

        if (dropdown != null)
        {
            dropdown.RegisterValueChangedCallback(evt =>
            {
                if (evt.newValue == "Player Mode")
                {
                    // Show the escape message when "Player Mode" is selected
                    escapeMessageUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
                }
                else
                {
                    // Hide the escape message when any other mode is selected
                    escapeMessageUIDocument.rootVisualElement.style.display = DisplayStyle.None;
                }
            });
        }
        else
        {
            Debug.LogError("DropdownField not found in the UIDocument!");
        }
    }

    private void Update()
    {
        // Check if the Escape key is pressed and the escape message is visible
        if (Input.GetKeyDown(KeyCode.Escape) && escapeMessageUIDocument.rootVisualElement.style.display == DisplayStyle.Flex)
        {
            // Make the escape message UI document invisible
            escapeMessageUIDocument.rootVisualElement.style.display = DisplayStyle.None;
        }
    }
}
