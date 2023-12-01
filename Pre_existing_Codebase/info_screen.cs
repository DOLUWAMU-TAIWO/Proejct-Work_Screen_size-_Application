using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info_screen : MonoBehaviour {

    public GameObject parent_info_help_screen;
    public Toggle toggle_show_info_help_screen;

    
    //public bool bottom_menu_active = false;

    public void show_info_help_screen (bool toggleStatus)
    {
        //if (toggleClicked == true)      // verhindert das zweifache Ausloesen der Funktion ohne Variable
        {
            parent_info_help_screen.SetActive(toggleStatus);
        }
    }
    
}