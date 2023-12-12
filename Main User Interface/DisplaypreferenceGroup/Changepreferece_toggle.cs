using UnityEngine.UIElements;
using UnityEngine;

public class ImageDisplayPreference : MonoBehaviour
{
    public Input_Variables cube;
    public UIDocument uiDocument; // Drag your UIDocument component in the Inspector

    private Toggle autoToggle;
    private Toggle displayToggle;
    private Toggle projectionToggle;

    // Start is called before the first frame update
    void Start()
    {
        // Get the root VisualElement
        VisualElement root = uiDocument.rootVisualElement;

        // Get references to toggle elements
        autoToggle = root.Q<Toggle>("AUTO");
        displayToggle = root.Q<Toggle>("DISPLAY");
        projectionToggle = root.Q<Toggle>("PROJEKTION");

        // Subscribe to the valueChanged event for each toggle
        autoToggle.RegisterValueChangedCallback(evt => OnToggleValueChanged(evt, "AUTO"));
        displayToggle.RegisterValueChangedCallback(evt => OnToggleValueChanged(evt, "DISPLAY"));
        projectionToggle.RegisterValueChangedCallback(evt => OnToggleValueChanged(evt, "PROJEKTION"));
    }

    // Callback method when any toggle value changes
    private void OnToggleValueChanged(ChangeEvent<bool> evt, string toggleName)
    {
     // to avoid nullvalue reference 
        Input_Variables inputVariables = FindObjectOfType<Input_Variables>();

        if (inputVariables != null)
        {
            // Call the change_preference function in the Input_Variables script
            inputVariables.change_preference(evt.newValue, toggleName);
        }
    }
}
