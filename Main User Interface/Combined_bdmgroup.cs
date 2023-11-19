using UnityEngine.UIElements;
using UnityEngine;

public class CombinedUICubeController : MonoBehaviour
{
    public Input_Variables inputVariables; // Reference to the Input_Variables script
    public UIDocument uiDocument; // Drag your UIDocument component in the Inspector

    private VisualElement root;
    private Toggle bdmToggle;
    private Toggle admToggle;
    private Toggle vdsToggle;

    private Toggle activeToggle;

    // Pastel blue shade as active color
    private Color activeColor = new Color(0.68f, 0.85f, 0.9f); // RGB for pastel blue

    void Start()
    {
        // Get the root VisualElement
        root = uiDocument.rootVisualElement;

        // Get references to toggle elements
        bdmToggle = root.Q<Toggle>("BDM");
        admToggle = root.Q<Toggle>("ADM");
        vdsToggle = root.Q<Toggle>("VDS");

        // Subscribe to the valueChanged event for each toggle
        bdmToggle.RegisterValueChangedCallback(evt => OnToggleValueChanged(evt, "BDM"));
        admToggle.RegisterValueChangedCallback(evt => OnToggleValueChanged(evt, "ADM"));
        vdsToggle.RegisterValueChangedCallback(evt => OnToggleValueChanged(evt, "VDS"));

        // Set the initial color based on the initial toggle states
        UpdateToggleColors();
    }

    // Callback method when any toggle value changes
    private void OnToggleValueChanged(ChangeEvent<bool> evt, string toggleName)
    {
        if (evt.newValue) // Check if the toggle was activated
        {
            SetActiveToggle((Toggle)evt.target);

            switch (toggleName)
            {
                case "BDM":
                    inputVariables.toggle_BDM.isOn = true;
                    inputVariables.toggle_ADM.isOn = false;
                    inputVariables.toggle_VDS.isOn = false;
                    break;
                case "ADM":
                    inputVariables.toggle_BDM.isOn = false;
                    inputVariables.toggle_ADM.isOn = true;
                    inputVariables.toggle_VDS.isOn = false;
                    break;
                case "VDS":
                    inputVariables.toggle_BDM.isOn = false;
                    inputVariables.toggle_ADM.isOn = false;
                    inputVariables.toggle_VDS.isOn = true;
                    break;
            }

            // Call the change_calculation_basis function in the Input_Variables script
            inputVariables.change_calculation_basis(true);
        }

        // Update the toggle colors
        UpdateToggleColors();
    }

    // Update colors based on the toggle states
    private void UpdateToggleColors()
    {
        SetToggleColor(bdmToggle, bdmToggle.value ? activeColor : Color.clear); // Color.clear for transparent
        SetToggleColor(admToggle, admToggle.value ? activeColor : Color.clear); // Color.clear for transparent
        SetToggleColor(vdsToggle, vdsToggle.value ? activeColor : Color.clear); // Color.clear for transparent
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
        if (activeToggle != bdmToggle)
        {
            bdmToggle.value = false;
        }

        if (activeToggle != admToggle)
        {
            admToggle.value = false;
        }

        if (activeToggle != vdsToggle)
        {
            vdsToggle.value = false;
        }
    }
}
