using UnityEngine;
using UnityEngine.UIElements;

// Controller for handling room dimension input in the UI.
public class RoomDimensionInputController : MonoBehaviour
{
    // Reference to the UI Document component.
    public UIDocument uiDocument;

    // Script containing variables and methods for input handling.
    public Input_Variables inputVariablesScript;

    // UI fields for entering depth, height, and width.
    private FloatField depthField;
    private FloatField heightField;
    private FloatField widthField;

    // Initialize references and event handlers when the script is enabled.
    private void OnEnable()
    {
        // Get the root visual element of the UI Document.
        var rootVisualElement = uiDocument.rootVisualElement;

        // Find the UI fields in the document by their names.
        depthField = rootVisualElement.Q<FloatField>("depth");
        heightField = rootVisualElement.Q<FloatField>("height");
        widthField = rootVisualElement.Q<FloatField>("breadth");

        // Log errors if any of the fields are not found.
        if (depthField == null) Debug.LogError("Depth field not found!");
        if (heightField == null) Debug.LogError("Height field not found!");
        if (widthField == null) Debug.LogError("Breadth (width) field not found!");

        // Register callback methods for when the field values change.
        depthField.RegisterValueChangedCallback(evt => OnDepthChanged(evt.newValue));
        heightField.RegisterValueChangedCallback(evt => OnHeightChanged(evt.newValue));
        widthField.RegisterValueChangedCallback(evt => OnWidthChanged(evt.newValue));
    }

    // Check for input in the fields every frame.
    private void Update()
    {
        // Check if Return or Enter is pressed while focusing on each field and invoke the corresponding action.
        CheckForReturnOrEnterPress(depthField, () => inputVariablesScript.change_room_depth(depthField.value.ToString()));
        CheckForReturnOrEnterPress(heightField, () => inputVariablesScript.change_room_height(heightField.value.ToString()));
        CheckForReturnOrEnterPress(widthField, () => inputVariablesScript.change_room_width(widthField.value.ToString()));
    }

    // Helper method to detect Return or Enter key presses on a given field.
    private void CheckForReturnOrEnterPress(FloatField field, System.Action action)
    {
        // Check if the field is focused and either Return or Enter is pressed.
        if (field != null && field.focusController.focusedElement == field && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            // Invoke the action associated with the field.
            action.Invoke();
        }
    }

    // Placeholder for depth change handling.
    private void OnDepthChanged(float newDepthValue)
    {
       
    }

    // Placeholder for height change handling.
    private void OnHeightChanged(float newHeightValue)
    {
    }

    // Placeholder for width change handling.
    private void OnWidthChanged(float newWidthValue)
    {
    }

    // Unregister event handlers when the script is disabled.
    private void OnDisable()
    {
        // Unregister callback methods to avoid memory leaks or unwanted behavior.
        if (depthField != null)
            depthField.UnregisterValueChangedCallback(evt => OnDepthChanged(evt.newValue));
        if (heightField != null)
            heightField.UnregisterValueChangedCallback(evt => OnHeightChanged(evt.newValue));
        if (widthField != null)
            widthField.UnregisterValueChangedCallback(evt => OnWidthChanged(evt.newValue));
    }
}
