using UnityEngine.UIElements;
using UnityEngine;

public class MyToggleButtonControllerforUI : MonoBehaviour
{
    private VisualElement root;
    private Toggle viewModeToggle;
    private Toggle calculatorModeToggle;
    private Toggle activeToggle;

    void Start()
    {
        // Get the root VisualElement
        root = GetComponent<UIDocument>().rootVisualElement;

        // Get references to toggle elements
        viewModeToggle = root.Q<Toggle>("View_mode");
        calculatorModeToggle = root.Q<Toggle>("Calculator_mode");

        // Subscribe to the change event for each toggle
        viewModeToggle.RegisterCallback<ChangeEvent<bool>>(OnToggleChange);
        calculatorModeToggle.RegisterCallback<ChangeEvent<bool>>(OnToggleChange);

        // Set the initial color based on the initial toggle states
        UpdateToggleColors();
    }

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

    private void UpdateToggleColors()
    {
        SetToggleColor(viewModeToggle, viewModeToggle.value ? Color.red : Color.white);
        SetToggleColor(calculatorModeToggle, calculatorModeToggle.value ? Color.red : Color.white);
    }

    private void SetToggleColor(Toggle toggle, Color color)
    {
        toggle.style.backgroundColor = new StyleColor(color);
    }

    private void SetActiveToggle(Toggle activeToggle)
    {
        this.activeToggle = activeToggle;

        // Deactivate other toggles
        if (activeToggle != viewModeToggle)
        {
            viewModeToggle.value = false;
        }

        if (activeToggle != calculatorModeToggle)
        {
            calculatorModeToggle.value = false;
        }
    }
}
