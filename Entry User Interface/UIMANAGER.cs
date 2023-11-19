using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UIDocument entranceMenuUIDocument;
    public UIDocument gameControlUIDocument;

    private Button startButton;

    void Start()
    {
        // Make sure the game control UI is not visible at the start.
        gameControlUIDocument.rootVisualElement.style.display = DisplayStyle.None;

        // Get the start button from the entrance menu UI.
        startButton = entranceMenuUIDocument.rootVisualElement.Q<Button>("startButton");
        startButton.clicked += EnableGameControlUI;
    }

    private void EnableGameControlUI()
    {
        // Disable the entrance menu UI
        entranceMenuUIDocument.rootVisualElement.style.display = DisplayStyle.None;

        // Enable the game control UI
        gameControlUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
    }
}
