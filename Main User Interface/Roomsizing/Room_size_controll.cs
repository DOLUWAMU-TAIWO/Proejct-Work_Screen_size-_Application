using UnityEngine;
using UnityEngine.UIElements;

public class RoomDimensionInputController : MonoBehaviour
{
    public UIDocument uiDocument;
    public Input_Variables inputVariablesScript;

    private FloatField depthField;
    private FloatField heightField;
    private FloatField widthField;

    private void OnEnable()
    {
        var rootVisualElement = uiDocument.rootVisualElement;

        depthField = rootVisualElement.Q<FloatField>("depth");
        heightField = rootVisualElement.Q<FloatField>("height");
        widthField = rootVisualElement.Q<FloatField>("breadth");

        if (depthField == null) Debug.LogError("Depth field not found!");
        if (heightField == null) Debug.LogError("Height field not found!");
        if (widthField == null) Debug.LogError("Breadth (width) field not found!");

        depthField.RegisterValueChangedCallback(evt => OnDepthChanged(evt.newValue));
        heightField.RegisterValueChangedCallback(evt => OnHeightChanged(evt.newValue));
        widthField.RegisterValueChangedCallback(evt => OnWidthChanged(evt.newValue));
    }

    private void Update()
    {
        CheckForReturnOrEnterPress(depthField, () => inputVariablesScript.change_room_depth(depthField.value.ToString()));
        CheckForReturnOrEnterPress(heightField, () => inputVariablesScript.change_room_height(heightField.value.ToString()));
        CheckForReturnOrEnterPress(widthField, () => inputVariablesScript.change_room_width(widthField.value.ToString()));
    }

    private void CheckForReturnOrEnterPress(FloatField field, System.Action action)
    {
        if (field != null && field.focusController.focusedElement == field && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            action.Invoke();
        }
    }

    private void OnDepthChanged(float newDepthValue)
    {
       
    }

    private void OnHeightChanged(float newHeightValue)
    {
    }

    private void OnWidthChanged(float newWidthValue)
    {
    }

    private void OnDisable()
    {
        if (depthField != null)
            depthField.UnregisterValueChangedCallback(evt => OnDepthChanged(evt.newValue));
        if (heightField != null)
            heightField.UnregisterValueChangedCallback(evt => OnHeightChanged(evt.newValue));
        if (widthField != null)
            widthField.UnregisterValueChangedCallback(evt => OnWidthChanged(evt.newValue));
    }
}
