using UnityEngine;
using UnityEngine.UIElements;

public class FarthestViewerFloatFieldController : MonoBehaviour
{
    public UIDocument uiDocument; // Reference to the UIDocument that contains your UI
    public Input_Variables inputVariablesScript; // Reference to the Input_Variables script

    private FloatField fvField;

    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;

        fvField = root.Q<FloatField>("screensize");

        if (fvField != null)
        {
            // Register callback for when the Enter key is pressed
            fvField.RegisterCallback<KeyDownEvent>(evt =>
            {
                if (evt.keyCode == KeyCode.Return || evt.keyCode == KeyCode.KeypadEnter)
                {
                    SubmitFieldValue();
                }
            });
        }
        else
        {
            Debug.LogError("Farthest Viewer Float Field not found!");
        }
    }

    private void SubmitFieldValue()
    {
        if (float.TryParse(fvField.text, out float newValue) && newValue != 0)
        {
            inputVariablesScript.change_fv(newValue.ToString());
        }
        else
        {
            Debug.LogWarning("Invalid input value for Farthest Viewer Float Field");
            // Optionally handle invalid input here, such as resetting to a previous valid value
        }
    }

    private void OnDisable()
    {
        if (fvField != null)
        {
            // Unregister callback
            fvField.UnregisterCallback<KeyDownEvent>(evt =>
            {
                if (evt.keyCode == KeyCode.Return || evt.keyCode == KeyCode.KeypadEnter)
                {
                    SubmitFieldValue();
                }
            });
        }
    }
}
