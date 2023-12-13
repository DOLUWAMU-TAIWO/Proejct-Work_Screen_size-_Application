using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic; // Needed for Dictionary

public class ViewMode : MonoBehaviour
{
    public UIDocument uiDocument; // Reference to the UIDocument containing the UI.
    public GameObject[] gameObjectsToToggle; // Array of GameObjects to be toggled.

    private Dictionary<GameObject, float> originalOpacities = new Dictionary<GameObject, float>(); // Stores original opacity values of GameObjects.
    private Button viewModeButton; // Button to toggle view mode.
    private VisualElement rootVisualElement; // Root visual element of the UI.
    private bool isUIVisible = true; // Flag to track UI visibility.

    private void Start()
    {
        // Initialize original opacity values for each GameObject.
        foreach (GameObject go in gameObjectsToToggle)
        {
            if (go != null)
            {
                Renderer renderer = go.GetComponent<Renderer>();
                if (renderer != null)
                {
                    // Store the original opacity if a Renderer is present.
                    originalOpacities[go] = renderer.material.color.a;
                }
                else
                {
                    // Default to fully opaque if no Renderer is found.
                    originalOpacities[go] = 1f;
                }
            }
        }
    }

    private void OnEnable()
    {
        // Get the root visual element from the UI document.
        rootVisualElement = uiDocument.rootVisualElement;
        // Find the view mode button in the UI.
        viewModeButton = rootVisualElement.Q<Button>("ViewModeButton");

        // Check if the view mode button is found.
        if (viewModeButton == null)
        {
            // Log an error if the button is not found and exit the method.
            Debug.LogError("ViewModeButton not found!");
            return;
        }

        // Subscribe to the click event of the view mode button.
        viewModeButton.clicked += OnViewModeButtonClicked;
    }

    private void Update()
    {
        // Toggle UI and GameObject visibility if Escape is pressed and the UI is not visible.
        if (Input.GetKeyDown(KeyCode.Escape) && !isUIVisible)
        {
            // Make UI and GameObjects visible.
            ToggleUIVisibility(true);
            ToggleObjectsVisibility(true);
        }
    }

    private void ToggleObjectsVisibility(bool visible)
    {
        // Iterate through each GameObject to toggle its visibility.
        foreach (GameObject go in gameObjectsToToggle)
        {
            if (go != null)
            {
                Renderer renderer = go.GetComponent<Renderer>();
                if (renderer != null)
                {
                    // Set the opacity of the GameObject based on the 'visible' parameter.
                    Color color = renderer.material.color;
                    color.a = visible ? originalOpacities[go] : 0.0f; // Use original opacity or make transparent.
                    renderer.material.color = color;
                }
                // Uncomment the below line to toggle active state for non-renderer objects.
                // go.SetActive(visible);
            }
        }
    }

    private void ToggleUIVisibility(bool visible)
    {
        // Set the opacity of the root visual element to show or hide the UI.
        rootVisualElement.style.opacity = visible ? 1 : 0;
        // Update the flag to track the current visibility state of the UI.
        isUIVisible = visible;
    }

    private void OnViewModeButtonClicked()
    {
        // Toggle the visibility state based on the current UI visibility.
        bool newVisibility = !isUIVisible;
        // Apply the new visibility state to UI and GameObjects.
        ToggleUIVisibility(newVisibility);
        ToggleObjectsVisibility(newVisibility);
    }

    private void OnDisable()
    {
        // Unsubscribe from the click event of the view mode button when the script is disabled.
        if (viewModeButton != null)
        {
            viewModeButton.clicked -= OnViewModeButtonClicked;
        }
    }

    public void ToggleUIAndObjects(bool activate)
    {
        // Public method to toggle both UI and GameObject visibility.
        ToggleUIVisibility(activate);
        ToggleObjectsVisibility(activate);
    }
}
