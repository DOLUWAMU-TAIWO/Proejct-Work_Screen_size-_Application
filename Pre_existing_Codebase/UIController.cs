using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private UIDocument uiDocument;
    private TextField textField;

    private void Start()
    {
        // Get the UIDocument component
        uiDocument = GetComponent<UIDocument>();

        // Access UI elements from the UIDocument
        textField = uiDocument.rootVisualElement.Q<TextField>("h");

        // Subscribe to text field submit event
        textField.RegisterCallback<KeyDownEvent>(OnTextFieldSubmit);
    }

    private void OnTextFieldSubmit(KeyDownEvent evt)
    {
        // Check if the Enter key is pressed
        if (evt.keyCode == KeyCode.Return || evt.keyCode == KeyCode.KeypadEnter)
        {
            // Access the value from the text field and pass it to the Input_Variables script
            string inputValue = textField.value;
            Input_Variables inputVariablesScript = FindObjectOfType<Input_Variables>();

            if (inputVariablesScript != null)
            {
                inputVariablesScript.change_room_width(inputValue);
            }
            else
            {
                Debug.LogError("Input_Variables script not found!");
            }
        }
    }
}
