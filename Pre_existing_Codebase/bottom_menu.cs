using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bottom_menu : MonoBehaviour
{

    public GameObject parent_bottom_menu;
    public Toggle toggle_show_bottom_menu;

    public GameObject parent_furniture_group_10;
    public Toggle toggle_show_furniture_group_10;

    public GameObject parent_furniture_group_6;
    public Toggle toggle_show_furniture_group_6;

    public GameObject parent_furniture_group_8;
    public Toggle toggle_show_furniture_group_8;

    public GameObject parent_furniture_group_14;
    public Toggle toggle_show_furniture_group_14;

    public GameObject parent_furniture_group_rows;
    public Toggle toggle_show_furniture_group_rows;

    public GameObject parent_furniture_group_ushape;
    public Toggle toggle_show_furniture_group_ushape;

    //public bool bottom_menu_active = false;

    public void show_bottom_menu(bool toggleStatus)
    {
        //if (toggleClicked == true)      // verhindert das zweifache Ausloesen der Funktion ohne Variable
        {
            parent_bottom_menu.SetActive(toggleStatus);
        }
    }
    

    public void show_furniture_group_10(bool toggleStatus)
    {
        {
            parent_furniture_group_10.SetActive(toggleStatus);
        }
    }

    public void show_furniture_group_6(bool toggleStatus)
    {
        {
            parent_furniture_group_6.SetActive(toggleStatus);
        }
    }

    public void show_furniture_group_14(bool toggleStatus)
    {
        {
            parent_furniture_group_14.SetActive(toggleStatus);
        }
    }

    public void show_furniture_group_8(bool toggleStatus)
    {
        {
            parent_furniture_group_8.SetActive(toggleStatus);
        }
    }

    public void show_furniture_group_rows(bool toggleStatus)
    {
        {
            parent_furniture_group_rows.SetActive(toggleStatus);
        }
    }

    public void show_furniture_group_ushape(bool toggleStatus)
    {
        {
            parent_furniture_group_ushape.SetActive(toggleStatus);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
