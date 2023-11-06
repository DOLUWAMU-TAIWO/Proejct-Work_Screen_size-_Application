using UnityEngine;
using UnityEngine.UIElements;

public class Controller_furniture : MonoBehaviour
{
    // Reference to the bottom_menu script component
    public bottom_menu BottomMenuScript;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var furnitureDropdown = root.Q<DropdownField>("Furniture"); // Make sure the name matches the dropdown in UI Builder

        // Set up the dropdown options
        SetupDropdown(furnitureDropdown);

        // Register a callback for when the dropdown value changes
        furnitureDropdown.RegisterValueChangedCallback(evt => OnDropdownChange(evt.newValue));
    }

    void SetupDropdown(DropdownField dropdown)
    {
        // Clear existing choices
        dropdown.choices.Clear();

        // Add options to the dropdown
        dropdown.choices.Add("Group 10");
        dropdown.choices.Add("Group 6");
        dropdown.choices.Add("Group 14");
        dropdown.choices.Add("Group 8");
        dropdown.choices.Add("Rows");
        dropdown.choices.Add("U-Shape");

        // Leave the dropdown with no selection to start
        dropdown.value = null;
    }

    // Method called whenever the dropdown selection changes
    private void OnDropdownChange(string newValue)
    {
        // Reset all furniture groups before showing the selected one
        BottomMenuScript.show_bottom_menu(false); // Hide the bottom menu
        BottomMenuScript.show_furniture_group_10(false);
        BottomMenuScript.show_furniture_group_6(false);
        BottomMenuScript.show_furniture_group_14(false);
        BottomMenuScript.show_furniture_group_8(false);
        BottomMenuScript.show_furniture_group_rows(false);
        BottomMenuScript.show_furniture_group_ushape(false);

        // Now show the selected group based on the dropdown selection
        switch (newValue)
        {
            case "Group 10":
                BottomMenuScript.show_furniture_group_10(true);
                break;
            case "Group 6":
                BottomMenuScript.show_furniture_group_6(true);
                break;
            case "Group 14":
                BottomMenuScript.show_furniture_group_14(true);
                break;
            case "Group 8":
                BottomMenuScript.show_furniture_group_8(true);
                break;
            case "Rows":
                BottomMenuScript.show_furniture_group_rows(true);
                break;
            case "U-Shape":
                BottomMenuScript.show_furniture_group_ushape(true);
                break;
            default:
                // No valid selection or the dropdown is reset to no selection
                break;
        }
    }
}
