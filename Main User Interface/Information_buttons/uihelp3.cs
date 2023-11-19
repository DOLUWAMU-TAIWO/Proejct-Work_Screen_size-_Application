using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Uihelp3 : MonoBehaviour
{
    private VisualElement _bottomContainer;
    private Button _openButton;
    private Button _closeButton;
    private VisualElement _bottomsheet;
    private VisualElement _scrim;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _bottomContainer = root.Q<VisualElement>("VisualElementbottom");
        _openButton = root.Q<Button>("Button_open3");
        _closeButton = root.Q<Button>("Button_close3");
        _bottomsheet = root.Q<VisualElement>("bottom_sheet3");
        _scrim = root.Q<VisualElement>("Scrim");

        _bottomContainer.style.display = DisplayStyle.None;
        _openButton.RegisterCallback<ClickEvent>(OnOpenButton3Clicked);
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButton3Clicked);

    }

    private void OnOpenButton3Clicked(ClickEvent evt)
    {
        _bottomContainer.style.display = DisplayStyle.Flex;


        _bottomsheet.AddToClassList("bottomsheet_up");
        _scrim.AddToClassList("fadein_scrim");



    }
    private void OnCloseButton3Clicked(ClickEvent evt)
    {
        _bottomContainer.style.display = DisplayStyle.None;

        _bottomsheet.RemoveFromClassList("bottomsheet_up");
        _scrim.RemoveFromClassList("fadein_scrim");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
