using UnityEngine;
using UnityEngine.UIElements;

public class InputFieldController : MonoBehaviour
{
    public UIDocument uiDocument;
    public Input_Variables inputVariablesScript; // Assuming the functions are in this script.

    private FloatField eyeLevelField;
    private FloatField displayHeightField;

    private void OnEnable()
    {
        var rootVisualElement = uiDocument.rootVisualElement;

        // Setup for eyeLevelField
        eyeLevelField = rootVisualElement.Q<FloatField>("eyeLevel");
        if (eyeLevelField == null)
        {
            Debug.LogError("Eye Level field not found!");
        }
        else
        {
            eyeLevelField.RegisterValueChangedCallback(evt => OnEyeLevelChanged(evt.newValue));
        }

        // Setup for displayHeightField
        displayHeightField = rootVisualElement.Q<FloatField>("displayHeight");
        if (displayHeightField == null)
        {
            Debug.LogError("Display Height field not found!");
        }
        else
        {
            displayHeightField.RegisterValueChangedCallback(evt => OnDisplayHeightChanged(evt.newValue));
        }
    }

    private void Update()
    {
        // Check for eyeLevelField input
        if (eyeLevelField != null && eyeLevelField.focusController.focusedElement == eyeLevelField && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            inputVariablesScript.change_eye_level(eyeLevelField.value.ToString());
        }

        // Check for displayHeightField input
        if (displayHeightField != null && displayHeightField.focusController.focusedElement == displayHeightField && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            inputVariablesScript.change_screen_installation_height(displayHeightField.value.ToString());
        }
    }

    private void OnEyeLevelChanged(float newEyeLevelValue)
    {
        // Placeholder for any other logic you want when the eye level value changes.
    }

    private void OnDisplayHeightChanged(float newDisplayHeightValue)
    {
        // Placeholder for any other logic you want when the display height value changes.
    }

    private void OnDisable()
    {
        if (eyeLevelField != null)
        {
            eyeLevelField.UnregisterValueChangedCallback(evt => OnEyeLevelChanged(evt.newValue));
        }

        if (displayHeightField != null)
        {
            displayHeightField.UnregisterValueChangedCallback(evt => OnDisplayHeightChanged(evt.newValue));
        }
    }
}
