using UnityEngine.UIElements;
using UnityEngine;

public class MyToggleColorController : MonoBehaviour
{
    private VisualElement root;
    private Toggle autoToggle;
    private Toggle displayToggle;
    private Toggle projectionToggle;

    private Toggle activeToggle;

    // Color for the active state - 
    private Color activeColor = new Color(0.68f, 0.85f, 0.9f, 1f); // Example red color
    private Color inactiveColor = new Color(1f, 1f, 1f, 0f); // Transparent color

    // Start is called before the first frame update
    void Start()
    {
        // Get the root VisualElement
        root = GetComponent<UIDocument>().rootVisualElement;

        // Get references to toggle elements
        autoToggle = root.Q<Toggle>("AUTO");
        displayToggle = root.Q<Toggle>("DISPLAY");
        projectionToggle = root.Q<Toggle>("PROJEKTION");

        // Subscribe to the change event for each toggle
        autoToggle.RegisterCallback<ChangeEvent<bool>>(OnToggleChange);
        displayToggle.RegisterCallback<ChangeEvent<bool>>(OnToggleChange);
        projectionToggle.RegisterCallback<ChangeEvent<bool>>(OnToggleChange);

        // Set the initial color based on the initial toggle states
        UpdateToggleColors();
    }

    // Callback method when any toggle value changes
    private void OnToggleChange(ChangeEvent<bool> evt)
    {
        // Update colors when any toggle is changed
        UpdateToggleColors();

        // Ensure only one toggle is active at a time
        if (evt.newValue)
        {
            SetActiveToggle((Toggle)evt.target);
        }
    }

    // Update colors based on the toggle states
    private void UpdateToggleColors()
    {
        SetToggleColor(autoToggle, autoToggle.value ? activeColor : inactiveColor);
        SetToggleColor(displayToggle, displayToggle.value ? activeColor : inactiveColor);
        SetToggleColor(projectionToggle, projectionToggle.value ? activeColor : inactiveColor);
    }

    // Helper method to set the background color of a toggle
    private void SetToggleColor(Toggle toggle, Color color)
    {
        toggle.style.backgroundColor = new StyleColor(color);
    }

    // Set the active toggle
    private void SetActiveToggle(Toggle activeToggle)
    {
        this.activeToggle = activeToggle;

        // Deactivate other toggles
        if (activeToggle != autoToggle)
        {
            autoToggle.value = false;
        }

        if (activeToggle != displayToggle)
        {
            displayToggle.value = false;
        }

        if (activeToggle != projectionToggle)
        {
            projectionToggle.value = false;
        }
    }
}
