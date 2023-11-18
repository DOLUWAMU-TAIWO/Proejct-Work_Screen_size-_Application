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

    private void ToggleObjectsVisibility(bool visible)
    {
        foreach (GameObject go in gameObjectsToToggle)
        {
            if (go != null)
            {
                Renderer renderer = go.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Color color = renderer.material.color;
                    color.a = visible ? originalOpacities[go] : 0.0f; // Restore to original opacity or make transparent
                    renderer.material.color = color;
                }
                // For non-renderer objects, use SetActive (if needed, uncomment the line below)
                // go.SetActive(visible);
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
