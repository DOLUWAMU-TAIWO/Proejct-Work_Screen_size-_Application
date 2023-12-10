using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic; // Needed for Dictionary

public class ViewMode : MonoBehaviour
{
    public UIDocument uiDocument; // Reference to the UIDocument that contains your UI
    public GameObject[] gameObjectsToToggle; // Array for the GameObjects you want to toggle

    private Dictionary<GameObject, float> originalOpacities = new Dictionary<GameObject, float>();
    private Button viewModeButton;
    private VisualElement rootVisualElement;
    private bool isUIVisible = true; // Track the visibility state of the UI

    private void Start()
    {
        // Store the original opacity of each GameObject
        foreach (GameObject go in gameObjectsToToggle)
        {
            if (go != null)
            {
                Renderer renderer = go.GetComponent<Renderer>();
                if (renderer != null)
                {
                    originalOpacities[go] = renderer.material.color.a;
                }
                else
                {
                    originalOpacities[go] = 1f; // If no Renderer, default to fully opaque
                }
            }
        }
    }

    private void OnEnable()
    {
        rootVisualElement = uiDocument.rootVisualElement; // Get the root visual element directly
        viewModeButton = rootVisualElement.Q<Button>("ViewModeButton");

        if (viewModeButton == null)
        {
            Debug.LogError("ViewModeButton not found!");
            return;
        }

        viewModeButton.clicked += OnViewModeButtonClicked;
    }

    private void Update()
    {
        // Check if the Escape key is pressed and UI is invisible
        if (Input.GetKeyDown(KeyCode.Escape) && !isUIVisible)
        {
            ToggleUIVisibility(true); // Make the UI visible
            ToggleObjectsVisibility(true); // Make GameObjects visible again
        }
    }

// Toggles the visibility of each GameObject in the gameObjectsToToggle array.
private void ToggleObjectsVisibility(bool visible)
{
    // Iterate through each GameObject in the array.
    foreach (GameObject go in gameObjectsToToggle)
    {
        // Check if the GameObject is not null to avoid NullReferenceException.
        if (go != null)
        {
            // Try to get the Renderer component of the GameObject.
            Renderer renderer = go.GetComponent<Renderer>();

            // Check if the GameObject has a Renderer component.
            if (renderer != null)
            {
                // Access the color of the material attached to the Renderer.
                Color color = renderer.material.color;

                // Set the alpha (opacity) of the color.
                // If visible is true, restore to original opacity stored in originalOpacities.
                // If visible is false, set opacity to 0 (fully transparent).
                color.a = visible ? originalOpacities[go] : 0.0f;

                // Apply the modified color back to the material.
                renderer.material.color = color;
            }
           
        }
    }
}


    private void ToggleUIVisibility(bool visible)
    {
        rootVisualElement.style.opacity = visible ? 1 : 0; // Set UI opacity to 0 to hide, 1 to show
        isUIVisible = visible; // Update the visibility state
    }

    private void OnViewModeButtonClicked()
    {
        bool newVisibility = !isUIVisible;
        ToggleUIVisibility(newVisibility); // Toggle UI based on current state
        ToggleObjectsVisibility(newVisibility); // Toggle GameObjects based on the new UI state
    }

    private void OnDisable()
    {
        if (viewModeButton != null)
        {
            viewModeButton.clicked -= OnViewModeButtonClicked;
        }
    }
    public void ToggleUIAndObjects(bool activate)
    {
        ToggleUIVisibility(activate);
        ToggleObjectsVisibility(activate);
    }
}
