using UnityEngine;
using UnityEngine.UIElements;

public class SimpleViewModeToggle : MonoBehaviour
{
    public UIDocument mainUIDocument; // Assign the UIDocument for the main UI in the inspector
    public UIDocument escapeMessageUIDocument; // Assign the UIDocument for the "Press Escape to Exit" in the inspector

    private Button viewModeButton;

    private void Awake()
    {
        // Make sure the escape message UI document is not visible when the game starts
        escapeMessageUIDocument.rootVisualElement.style.display = DisplayStyle.None;
    }

    private void OnEnable()
    {
        // Get the view mode button from the main UI document
        viewModeButton = mainUIDocument.rootVisualElement.Q<Button>("ViewModeButton");

        if (viewModeButton != null)
        {
            viewModeButton.clicked += ToggleEscapeMessageVisibility;
        }
        else
        {
            Debug.LogError("ViewModeButton not found in the main UIDocument!");
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

    private void ToggleEscapeMessageVisibility()
    {
        var currentDisplay = escapeMessageUIDocument.rootVisualElement.style.display;
        // Toggle visibility only if the current display style is none (hidden)
        if (currentDisplay == DisplayStyle.None)
        {
            escapeMessageUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        }
    }

    private void OnDisable()
    {
        if (viewModeButton != null)
        {
            viewModeButton.clicked -= ToggleEscapeMessageVisibility;
        }
    }
}
