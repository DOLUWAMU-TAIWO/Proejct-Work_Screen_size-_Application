using UnityEngine.UIElements;
using UnityEngine;

public class ViewModeToggleController : MonoBehaviour
{
    private VisualElement root;
    private Toggle viewModeToggle;

    void Start()
    {
        // Get the root VisualElement
        root = GetComponent<UIDocument>().rootVisualElement;

        // Get reference to the view_mode toggle
        viewModeToggle = root.Q<Toggle>("View_mode");

        // Subscribe to the change event for the toggle
        viewModeToggle.RegisterCallback<ChangeEvent<bool>>(OnToggleChange);

        // Set the initial color based on the toggle state
        UpdateToggleColor();
    }

    private void OnToggleChange(ChangeEvent<bool> evt)
    {
        // Update the toggle color when its state changes
        UpdateToggleColor();
    }

    private void UpdateToggleColor()
    {
        SetToggleColor(viewModeToggle, viewModeToggle.value ? Color.red : Color.white);
    }

    private void SetToggleColor(Toggle toggle, Color color)
    {
        toggle.style.backgroundColor = new StyleColor(color);
    }
}
