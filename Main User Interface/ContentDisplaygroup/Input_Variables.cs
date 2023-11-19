using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_Variables : MonoBehaviour {

    //public GameObject wall_rear;
    public GameObject ceiling;
    public GameObject parent_wall_right;
    public GameObject parent_wall_left;
    public GameObject parent_wall_rear;
    public GameObject parent_wall_rear_translate;

    public GameObject dimensioning_room;
    

    public GameObject parent_room_height_translate;
    public GameObject parent_room_width_translate;
    public GameObject parent_room_depth_translate;

    

    public GameObject dimensioning_room_height;
    public GameObject dimensioning_room_width;
    public GameObject dimensioning_room_depth;
    public GameObject text_value_room_height;
    public GameObject text_value_room_width;
    public GameObject text_value_room_depth;

    // Screen Parent zum Skalieren
    public GameObject parent_display;
    public GameObject parent_screen_installation_height;
    public GameObject dimensioning_screen_installation_height;
    public GameObject text_value_screen_installation_height;
    float screen_installation_height = 1.15f;

    public GameObject parent_projection_screen;
    public GameObject projection_screen_16_9;

    public GameObject parent_screen_dimensioning_translate;
    
    //public GameObject parent_display;
    
    // Screen Diagonale Bemassung
    public GameObject parent_screen_diagonal_translate;
    public GameObject dimensioning_screen_diagonal;
    public GameObject text_value_screen_diagonal;
    // Screen Breite Bemassung
    public GameObject parent_screen_width_translate;
    public GameObject dimensioning_screen_width;
    public GameObject text_value_screen_width;
    // Screen Hoehe Bemassung
    public GameObject parent_screen_height_translate;
    public GameObject dimensioning_screen_height;
    public GameObject text_value_screen_height;

    // Projektor mit Halterung
    public GameObject parent_projector;

    // Pop-Up Fenster fuer Input-Fields
    public GameObject popup_room_width_range;

    // parent fv-Punkt Moebel
    public GameObject parent_furniture;


    // Variablen zur Beschreibung der Bildflaeche (default: 65")
    float screen_height = 0.809f;
    float screen_width = 1.439f;
    float screen_diagonal = 1.651f;
    int screen_diagonal_inch = 65;

    float eye_level = 1.220f;
    float image_offset; // installation height - eye level

    float farthest_viewer_distance = 4.85f;
    float element_height = 0.03f;   // 2,5 % = 18 pt

    public float room_width = 5.0f;
    float room_depth = 8.0f;
    float room_height = 2.5f;

    float functionInput;

    // Offset fuer Ursprung Raumbemassung von Boden (Lesbarkeit)
    float origin_dimensioning_room_offset = 0.05f;
    // Skalierungsfaktor fuer Bemassungslinien
    float scale_dimensioning_lines = 0.01f;

    public ToggleGroup toggle_group_content;
    public Toggle toggle_detail;
    public Toggle toggle_presentation;
    public Toggle toggle_multimedia;

    public Toggle toggle_auto;
    public Toggle toggle_display;
    public Toggle toggle_projection;

    // Toggle BDM und ADM
    public Toggle toggle_BDM;
    public Toggle toggle_ADM;
    public Toggle toggle_VDS;
    public bool BDM_active = true;
    public bool ADM_active = false;
    public bool VDS_active = false;
    public InputField display_vertical_resolution_input_field;
    

    // Array mit erhaeltlichen Display-Groessen (wird zur gerundeten Berechnung der Displaygroesse verwendet): 32,40,42,43,46,48,49,50,55,58,60,65,70,65,68,80,84,85,90,95,98 (21 Groessen)
    float[] display_sizes = {0.40f,0.50f,0.52f,0.54f,0.57f,0.60f,0.61f,0.62f,0.69f,0.72f,0.75f,0.81f,0.87f,0.93f,0.97f,1.00f,1.05f,1.06f,1.12f,1.18f,1.22f};    // Angabe der Bildhoehe
    // Array mit erhaeltlichen Leinwand-Groessen in 16:9 (wird zur gerundeten Berechnung der Leinwandgroessen verwendet): 1.60, 1.80, 2.00, 2.20, 2.40, 2.50, 2.80, 3.00, 3.50, 4.00, 4.50, 5.00, 5.50, 6.00 (14 Groessen)
    float[] projection_screen_sizes_16_9 = { 0.90f, 1.01f, 1.125f, 1.24f, 1.35f, 1.41f, 1.574f, 1.69f, 1.97f, 2.25f, 2.53f, 2.81f, 3.094f, 3.374f };
    // Array mit erhaeltlichen Leinwand-Groessen in 16:10 (wird zur gerundeten Berechnung der Leinwandgroessen verwendet): 1.60, 1.80, 2.00, 2.20, 2.40, 2.50, 2.80, 3.00, 3.50, 4.00, 4.50, 5.00, 5.50, 6.00 (14 Groessen)
    float[] projection_screen_sizes_16_10 = { 1.00f, 1.13f, 1.25f, 1.38f, 1.50f, 1.56f, 1.75f, 1.88f, 2.19f, 2.50f, 2.81f, 3.13f, 3.44f, 3.75f };

    // Boolesche Variablen zur Auswahl von Auto/Display/Leinwand
    public bool calculate_auto = true;
    public bool calculate_display = false;
    public bool calculate_projection_16_9 = false;
    
    public bool display_visibility = true;
    public bool projection_16_9_visibility = false;

    float fp = 1.0f;

    float screen_height_matched = 0.809f;   // zur Anpassung der Bildgroessen auf erhaeltliche Groessen
    float screen_height_diff;       // Betrag zur naechstgelegenen realen Displaygroesse
    float screen_height_ref = 20.0f;

    float screen_width_matched = 1.439f;
    float screen_diagonal_matched = 1.651f;
    int screen_diagonal_matched_inch = 65;

    // minimaler Betrachtungsabstand vertikal cv_vertical
    float cv_vertical = 1.28f;  // zur Berechnung
    public GameObject parent_indicator_cv_vertical; // zur Darstellung
    public GameObject indicator_cv_vertical;

    // maximaler Betrachtungsabstand fv
    public GameObject indicator_fv;

    // vertikale Bildaufloesung zur ADM basierten Berechnung
    int ir_vertical = 1080;


    // Eckpunkte cv_zone
    public GameObject cv_zone_point0;
    public GameObject cv_zone_point1;
    public GameObject cv_zone_point2;
    public GameObject cv_zone_point3;
    public GameObject cv_zone_point4;
    public GameObject cv_zone_point5;
    public GameObject cv_zone_point6;

    // Eckpunkte fv_zone
    public GameObject fv_zone_point0;
    public GameObject fv_zone_point1;
    public GameObject fv_zone_point2;
    public GameObject fv_zone_point3;
    public GameObject fv_zone_point4;
    public GameObject fv_zone_point5;
    public GameObject fv_zone_point6;
    public GameObject fv_zone_point7;
    public GameObject fv_zone_point8;
    public GameObject fv_zone_point9;
    public GameObject fv_zone_point10;
    public GameObject fv_zone_point11;
    public GameObject fv_zone_point12;
    public GameObject fv_zone_point13;

    //public GameObject indicator_cv_zone_mesh;
    public Distance_Indicator_Calculation distance_indicator_calculation_script;

    // VDS Disclaimer
    public GameObject vds_disclaimer_message;


    // Use this for initialization
    void Start ()
    {
        //distance_indicator_calculation_script = indicator_cv_zone_mesh.GetComponent<Distance_Indicator_Calculation>();
        distance_indicator_calculation_script = GetComponent<Distance_Indicator_Calculation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void change_room_width(string newInput)
    {
        functionInput = float.Parse(newInput);
        

        // Eingabe auf 2 bis 15 m begrenzen
        if (functionInput < 2f || functionInput > 15f)
        {
            // Pop-Up
            popup_room_width_range.SetActive(true);
        }
        else
        {
            // Pop-Up schliessen
            popup_room_width_range.SetActive(false);

            room_width = functionInput;

            parent_wall_right.transform.position = new Vector3(room_width / 2, room_height, 4);
            parent_wall_left.transform.position = new Vector3(-room_width / 2, room_height, 4);

            // Verschiebe Raumbemassung
            dimensioning_room.transform.position = new Vector3(room_width / 2 - 0.05f, 0.05f, room_depth - 0.05f);

            parent_room_width_translate.transform.localPosition = new Vector3(-(room_width - 0.05f) / 2, 0, 0);
            dimensioning_room_width.transform.localScale = new Vector3(0.01f, (room_width - 0.05f) / 2, 0.01f);

            // Text Raumbreite aendern
            text_value_room_width.GetComponent<TextMesh>().text = string.Format("{0:#.00} m", room_width);

            // cv Zone berechnen und zeichnen
            calculate_cv_zone();
            calculate_fv_zone();
            // Mesh zeichnen (Methode aus Script "Distance_Indicator_Calculation)
            distance_indicator_calculation_script.draw_distance_indication_zones();
        }
    }

    public void change_room_depth(string newInput)
    {
        room_depth = float.Parse(newInput);
        parent_wall_rear_translate.transform.position = new Vector3(0, 0,room_depth);

        // Verschiebe Raumbemassung
        dimensioning_room.transform.position = new Vector3(room_width / 2 - 0.05f , 0.05f, room_depth - 0.05f);

        parent_room_depth_translate.transform.localPosition = new Vector3(0, 0, -(room_depth - 0.05f) / 2);
        dimensioning_room_depth.transform.localScale = new Vector3(0.01f, (room_depth - 0.05f) / 2, 0.01f);

        // Text Raumtiefe aendern
        text_value_room_depth.GetComponent<TextMesh>().text = string.Format("{0:#.00} m", room_depth);

        // Projektionsabstand anpassen
        parent_projector.transform.localPosition = new Vector3(0, 0, 1f / 3f * (-15 + room_depth - screen_width_matched * 1.8f)); // 1.8 ist das durchschnittliche Throw-Ratio einer Standardlinse, Faktor 1/3 wegen Skalierung der Parent-Decke (*3)
    }

    public void change_room_height(string newInput)
    {
        room_height = float.Parse(newInput);
        ceiling.transform.position = new Vector3(0, room_height, 15);

        // Verschiebe Raumbemassung
        dimensioning_room.transform.position = new Vector3(room_width / 2 - 0.05f, 0.05f, room_depth - 0.05f);

        parent_room_height_translate.transform.localPosition = new Vector3(0, (room_height - 0.05f) / 2, 0);
        dimensioning_room_height.transform.localScale = new Vector3(0.01f , (room_height - 0.05f) / 2 , 0.01f);

        // Verschiebe Waende
        parent_wall_rear.transform.localPosition = new Vector3(0, room_height, 0);
        parent_wall_right.transform.localPosition = new Vector3(room_width/2, room_height, 4);
        parent_wall_left.transform.localPosition = new Vector3(-room_width/2, room_height, 4);

        // Text Raumhoehe aendern
        text_value_room_height.GetComponent<TextMesh>().text = string.Format("{0:#.00} m", room_height);
        //text_value_room_height.transform.position = new Vector3(0, 0, 0);

    }

    public void change_screen_installation_height(string newInput)
    {
        screen_installation_height = float.Parse(newInput);

        // Display/Leinwand Montagehoehe veraendern (UK Display - OKFF)
        parent_display.transform.localPosition = new Vector3(0, screen_installation_height, 0);
        parent_projection_screen.transform.localPosition = new Vector3(0, screen_installation_height, 0);

        // Bemassung fuer Montagehoehe anpassen
        parent_screen_installation_height.transform.localPosition = new Vector3(-screen_width_matched / 2, screen_installation_height / 2, -0.05f);
        dimensioning_screen_installation_height.transform.localScale = new Vector3(0.01f, screen_installation_height / 2, 0.01f);
        text_value_screen_installation_height.GetComponent<TextMesh>().text = string.Format("{0:0.00} m", screen_installation_height);

        // Bemassung fuer Bilddiagonale anpassen
        parent_screen_dimensioning_translate.transform.localPosition = new Vector3(-screen_width_matched/2, screen_installation_height, -0.05f);

        // Minimalabstand anpassen
        change_cv_vertical();
    }


    public void change_fv(string newInput)
    {
        farthest_viewer_distance = float.Parse(newInput);

        // Bildgroesse anpassen
        calculate_screen_size();

        // FV-Punkt verschieben (Moebel)
        parent_furniture.transform.localPosition = new Vector3(0, 0, - farthest_viewer_distance);

    }


    public void change_eh(bool toggleClicked)
    {
        if (toggleClicked == true)      // verhindert das zweifache Ausloesen der Funktion ohne Variable
        {
            if (toggle_detail.isOn == true)
            {
                element_height = 0.015f;    // 1,5 % = 12 pt     1 % = Excel = 11 pt aber in kleiner Darstellung
                //  fp = 2f;
            }
            else if (toggle_presentation.isOn == true)
            {
                element_height = 0.03f;     // 3 % = 24 pt     2,5 % = Praesentation mit 18 pz
                //  fp = 1.2f;
            }
            else if (toggle_multimedia.isOn == true)
                element_height = 0.04f;     // 4 % = 33 pt  

            Debug.Log("%EH set to " + element_height);

            // Faktor fp wird zuvor angepasst je nach inhalt
            

            // Bildgroesse anpassen
            calculate_screen_size();
        }
    }

    public void change_preference(bool toggleClicked, string toggleName)
    {
        if (toggleClicked)
        {
            switch (toggleName)
            {
                case "AUTO":
                    calculate_auto = true;
                    calculate_display = false;
                    calculate_projection_16_9 = false;
                    break;
                case "DISPLAY":
                    calculate_auto = false;
                    calculate_display = true;
                    calculate_projection_16_9 = false;
                    break;
                case "PROJEKTION":
                    calculate_auto = false;
                    calculate_display = false;
                    calculate_projection_16_9 = true;
                    break;
                default:
                    // Handle other cases if needed
                    break;
            }

            // Bildgroesse anpassen
            calculate_screen_size();
        }
    }


    public void change_calculation_basis(bool toggleClicked)
    {
        if (toggleClicked == true)      // verhindert das zweifache Ausloesen der Funktion ohne Variable
        {
            if (toggle_BDM.isOn == true)
            {
                
                BDM_active = true;
                ADM_active = false;
                VDS_active = false;

                toggle_presentation.isOn = true;

                toggle_group_content.allowSwitchOff = false;
                                               
                toggle_detail.interactable = true;
                toggle_presentation.interactable = true;
                //toggle_multimedia.interactable = true;

                display_vertical_resolution_input_field.interactable = ADM_active;
            }
            else if (toggle_ADM.isOn == true)
            {
                
                BDM_active = false;
                ADM_active = true;
                VDS_active = false;

                toggle_group_content.allowSwitchOff = true;

                toggle_detail.isOn = false;
                toggle_presentation.isOn = false;                
                toggle_multimedia.isOn = false;

                toggle_detail.interactable = false;           
                toggle_presentation.interactable = false;
                toggle_multimedia.interactable = false;

                display_vertical_resolution_input_field.interactable = ADM_active;
            }
            else if (toggle_VDS.isOn == true)
            {

                BDM_active = false;
                ADM_active = false;
                VDS_active = true;

                toggle_group_content.allowSwitchOff = true;

                toggle_detail.isOn = false;
                toggle_presentation.isOn = false;
                toggle_multimedia.isOn = false;

                toggle_detail.interactable = false;
                toggle_presentation.interactable = false;
                toggle_multimedia.interactable = false;

                display_vertical_resolution_input_field.interactable = ADM_active;
            }

            // Bildgroesse anpassen
            calculate_screen_size();


            // VDS Disclaimer anzeigen bei VDS
            vds_disclaimer_message.SetActive(VDS_active);


        }
    }


    public void change_eye_level(string newInput)
    {
        eye_level = float.Parse(newInput);
        
        // Minimalabstand anpassen
        change_cv_vertical();
    }

    public void change_ir_vertical(string newInput)
    {
        ir_vertical = int.Parse(newInput);

        // Bildgroesse anpassen
        calculate_screen_size();
    }

    public void change_cv_vertical()
    {
        // Unterscheidung BDM und ADM, bei ADM entfaellt vertikaler Mindestabstand
        if (BDM_active)
            cv_vertical = (screen_height_matched + screen_installation_height - eye_level) * 1.732f;
        else
            cv_vertical = 0.0f;


        // cv & fv Zonen berechnen und zeichnen
        calculate_cv_zone();
        calculate_fv_zone();

        // Mesh zeichnen (Methode aus Script "Distance_Indicator_Calculation)
        distance_indicator_calculation_script.draw_distance_indication_zones();
    }

    public void change_indicator_fv()
    {
        indicator_fv.transform.localScale = new Vector3(2 * farthest_viewer_distance, 1, 2 * farthest_viewer_distance);
    }


    //public void pointsOnCircle_fv()
    //{

    //    // für 4/5 x
    //    -Mathf.Sqrt(Mathf.Pow(farthest_viewer_distance, 2) - Mathf.Pow((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.8f + screen_width_matched / 2, 2));
    //}




    public void calculate_screen_size()
    {
        if (BDM_active)
        {
            screen_height = farthest_viewer_distance / (200 * element_height * fp);         
        }
        else if(ADM_active)
        {
            screen_height = (ir_vertical * farthest_viewer_distance) / 3438f;    
        }

        // Berechnung im Auto-Modus:
        if (calculate_auto == true)
        {
            if (screen_height < 1.125f)  // falls Bildhoehe < 1.13 m (= bis 2 m Bildbreite, bevorzuge Displays)
            {
                // passe Bildhoehe auf erhaeltliche Groessen an
                for (int i = 0; i <= 20; i++)
                {
                    screen_height_diff = Mathf.Abs(display_sizes[i] - screen_height);

                    if (screen_height_diff <= screen_height_ref)     // screen_height_ref ist der gespeicherte Minimalwert aus dem letzten Schleifendurchlauf, <= bevorzugt das naechstgroeßere Display bei zwei gleichen Differenzen
                    {
                        screen_height_ref = screen_height_diff;
                        screen_height_matched = display_sizes[i];
                    }
                }

                // mache Display sichtbar
                display_visibility = true;
                projection_16_9_visibility = false;
                parent_display.SetActive(display_visibility);
                projection_screen_16_9.SetActive(projection_16_9_visibility);
                parent_projector.SetActive(projection_16_9_visibility);
            }

            else
            // falls Bildhoehe >= 1.13 (= ab 2 m Bildbreite) nehme 16:9 Projektion      
            {
                for (int i = 0; i <= 13; i++)
                {
                    screen_height_diff = Mathf.Abs(projection_screen_sizes_16_9[i] - screen_height);

                    if (screen_height_diff <= screen_height_ref)     // screen_height_ref ist der gespeicherte Minimalwert aus dem letzten Schleifendurchlauf, <= bevorzugt das naechstgroeßere Display bei zwei gleichen Differenzen
                    {
                        screen_height_ref = screen_height_diff;
                        screen_height_matched = projection_screen_sizes_16_9[i];
                    }
                }
                // mache Projektion sichtbar
                display_visibility = false;
                projection_16_9_visibility = true;
                parent_display.SetActive(display_visibility);
                projection_screen_16_9.SetActive(projection_16_9_visibility);
                parent_projector.SetActive(projection_16_9_visibility);
            }
        }

        // Berechnung fuer Display:
        else if (calculate_display == true)
        {
            // passe Bildhoehe auf erhaeltliche Groessen an
            for (int i = 0; i <= 20; i++)
            {
                screen_height_diff = Mathf.Abs(display_sizes[i] - screen_height);
                
                if (screen_height_diff <= screen_height_ref)     // screen_height_ref ist der gespeicherte Minimalwert aus dem letzten Schleifendurchlauf, <= bevorzugt das naechstgroeßere Display bei zwei gleichen Differenzen
                {
                    screen_height_ref = screen_height_diff;
                    screen_height_matched = display_sizes[i];
                }
            }
            // mache Display sichtbar
            display_visibility = true;
            projection_16_9_visibility = false;
            parent_display.SetActive(display_visibility);
            projection_screen_16_9.SetActive(projection_16_9_visibility);
            parent_projector.SetActive(projection_16_9_visibility);
        }

        // Berechnung fuer Projektion:
        else if (calculate_projection_16_9 == true)
        {
            // passe Bildhoehe auf erhaeltliche Groessen an
            for (int i = 0; i <= 13; i++)
            {
                screen_height_diff = Mathf.Abs(projection_screen_sizes_16_9[i] - screen_height);
                
                if (screen_height_diff <= screen_height_ref)     // screen_height_ref ist der gespeicherte Minimalwert aus dem letzten Schleifendurchlauf, <= bevorzugt das naechstgroeßere Display bei zwei gleichen Differenzen
                {
                    screen_height_ref = screen_height_diff;
                    screen_height_matched = projection_screen_sizes_16_9[i];
                }
            }
            // mache Projektion sichtbar
            display_visibility = false;
            projection_16_9_visibility = true;
            parent_display.SetActive(display_visibility);
            projection_screen_16_9.SetActive(projection_16_9_visibility);
            parent_projector.SetActive(projection_16_9_visibility);
        }

        screen_height_ref = 20.0f;   // fuer naechsten schleifendurchlauf initialisieren
        

        screen_width_matched = 16f / 9f * screen_height_matched;
        Debug.Log(screen_width_matched);
        screen_diagonal_matched = Mathf.Sqrt(Mathf.Pow(screen_height_matched,2) + Mathf.Pow(screen_width_matched, 2));
        screen_diagonal_matched_inch = (int)Mathf.Round(screen_diagonal_matched * 39.3701f);
        Debug.Log(screen_diagonal_matched);
        Debug.Log(screen_diagonal_matched_inch);

        // SKalierung Display anpassen
        parent_display.transform.localScale = new Vector3(screen_width_matched, screen_width_matched, 1);
        // Skalierung Leinwand (16:9) anpassen
        parent_projection_screen.transform.localScale = new Vector3(screen_width_matched, screen_width_matched, 1);


        // Bemassung anpassen
        
        parent_screen_dimensioning_translate.transform.localPosition = new Vector3(-screen_width_matched / 2, screen_installation_height, -0.05f);

        parent_screen_width_translate.transform.localPosition = new Vector3(screen_width_matched / 2, 0, 0);
        dimensioning_screen_width.transform.localScale = new Vector3(0.01f, screen_width_matched / 2, 0.01f);
        text_value_screen_width.GetComponent<TextMesh>().text = string.Format("{0:0.00} m", screen_width_matched);

        parent_screen_height_translate.transform.localPosition = new Vector3(0,screen_height_matched / 2, 0);
        dimensioning_screen_height.transform.localScale = new Vector3(0.01f, screen_height_matched / 2, 0.01f);
        text_value_screen_height.GetComponent<TextMesh>().text = string.Format("{0:0.00} m", screen_height_matched);

        parent_screen_diagonal_translate.transform.localPosition = new Vector3(screen_width_matched / 2, screen_height_matched / 2, 0);
        dimensioning_screen_diagonal.transform.localScale = new Vector3(0.01f, screen_diagonal_matched / 2, 0.01f);
        text_value_screen_diagonal.GetComponent<TextMesh>().text = string.Format("{0:0} \"", screen_diagonal_matched_inch);

        // Projektionsabstand anpassen
        parent_projector.transform.localPosition = new Vector3(0, 0, 1f / 3f * (-15 + room_depth - screen_width_matched * 1.8f)); // 1.8 ist das durchschnittliche Throw-Ratio einer Standardlinse, Faktor 1/3 wegen Skalierung der Parent-Decke (*3)


        // Bemassung Montagehoehe Verschiebung anpassen
        parent_screen_installation_height.transform.localPosition = new Vector3(-screen_width_matched / 2, screen_installation_height / 2, -0.05f);


        // Minimalabstand anpassen
        change_cv_vertical();

        // Maximalabstand anpassen
        change_indicator_fv();

        // cv & fv Zonen berechnen und zeichnen
        calculate_cv_zone();
        calculate_fv_zone();

        // Mesh zeichnen (Methode aus Script "Distance_Indicator_Calculation)
        distance_indicator_calculation_script.draw_distance_indication_zones();

    }

    void calculate_cv_zone()
    {
        cv_zone_point0.transform.localPosition = new Vector3(0, 0, 0.05f);  // Position Punkt 0
        cv_zone_point1.transform.localPosition = new Vector3(room_width/2, 0, 0.05f);  // Position Punkt 1
        cv_zone_point2.transform.localPosition = new Vector3(room_width/2, 0, -0.28868f*(room_width+screen_width_matched));  // Position Punkt 2
        cv_zone_point3.transform.localPosition = new Vector3(cv_vertical / 0.57735f - screen_width_matched / 2, 0, -cv_vertical);  // Position Punkt 3
        cv_zone_point4.transform.localPosition = new Vector3(-(cv_vertical/0.57735f-screen_width_matched/2), 0, -cv_vertical);  // Position Punkt 4
        cv_zone_point5.transform.localPosition = new Vector3(-(room_width / 2), 0, -0.28868f * (room_width + screen_width_matched));  // Position Punkt 5
        cv_zone_point6.transform.localPosition = new Vector3(-(room_width / 2), 0, 0.05f);  // Position Punkt 6
    }

    void calculate_fv_zone()
    {
        fv_zone_point0.transform.localPosition = new Vector3(0, 0, -cv_vertical);  // Position Punkt 0
        fv_zone_point1.transform.localPosition = new Vector3(cv_vertical / 0.57735f - screen_width_matched / 2, 0, -cv_vertical);  // Position Punkt 1 = cv Punkt 3
        // Wenn cv_vertical (Gerade) > cv_horizontal (Winkel) und Kreise einschliesst (SP Kreis mit Gerade (noch zu definieren!), 0, yGerade)
        //if(-0.5f * farthest_viewer_distance < -cv_vertical)
        //    fv_zone_point2.transform.localPosition = new Vector3((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 1.0f, 0, -cv_vertical);  // Position Punkt 2
        //else
            fv_zone_point2.transform.localPosition = new Vector3((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 1.0f, 0, - 0.5f * farthest_viewer_distance);  // Position Punkt 2

        fv_zone_point3.transform.localPosition = new Vector3((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.8f, 0, - Mathf.Sqrt(Mathf.Pow(farthest_viewer_distance, 2) - Mathf.Pow((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.8f + screen_width_matched/2,2)));  // Position Punkt 3
        fv_zone_point4.transform.localPosition = new Vector3((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.6f, 0, - Mathf.Sqrt(Mathf.Pow(farthest_viewer_distance, 2) - Mathf.Pow((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.6f + screen_width_matched / 2, 2)));  // Position Punkt 4
        fv_zone_point5.transform.localPosition = new Vector3((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.4f, 0, - Mathf.Sqrt(Mathf.Pow(farthest_viewer_distance, 2) - Mathf.Pow((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.4f + screen_width_matched / 2, 2)));  // Position Punkt 5
        fv_zone_point6.transform.localPosition = new Vector3((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.2f, 0, - Mathf.Sqrt(Mathf.Pow(farthest_viewer_distance, 2) - Mathf.Pow((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.2f+ screen_width_matched / 2, 2)));  // Position Punkt 6
        fv_zone_point7.transform.localPosition = new Vector3(0, 0, -Mathf.Sqrt(Mathf.Pow(farthest_viewer_distance, 2) - Mathf.Pow(0.0f + screen_width_matched / 2, 2)));  // Position Punkt 6

        fv_zone_point8.transform.localPosition = new Vector3(-(0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.2f, 0, - Mathf.Sqrt(Mathf.Pow(farthest_viewer_distance, 2) - Mathf.Pow((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.2f + screen_width_matched / 2, 2)));  // Position Punkt 8
        fv_zone_point9.transform.localPosition = new Vector3(-(0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.4f, 0, - Mathf.Sqrt(Mathf.Pow(farthest_viewer_distance, 2) - Mathf.Pow((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.4f + screen_width_matched / 2, 2)));  // Position Punkt 9
        fv_zone_point10.transform.localPosition = new Vector3(-(0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.6f, 0, - Mathf.Sqrt(Mathf.Pow(farthest_viewer_distance, 2) - Mathf.Pow((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.6f + screen_width_matched / 2, 2)));  // Position Punkt 10
        fv_zone_point11.transform.localPosition = new Vector3(-(0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.8f, 0, -Mathf.Sqrt(Mathf.Pow(farthest_viewer_distance, 2) - Mathf.Pow((0.866f * farthest_viewer_distance - screen_width_matched / 2) * 0.8f + screen_width_matched / 2, 2)));  // Position Punkt 11
        fv_zone_point12.transform.localPosition = new Vector3(-(0.866f * farthest_viewer_distance - screen_width_matched / 2) * 1.0f, 0, -0.5f * farthest_viewer_distance);  // Position Punkt 12
        fv_zone_point13.transform.localPosition = new Vector3(-(cv_vertical / 0.57735f - screen_width_matched / 2), 0, -cv_vertical);  // Position Punkt 13 = cv Punkt 4
    }


    
}
