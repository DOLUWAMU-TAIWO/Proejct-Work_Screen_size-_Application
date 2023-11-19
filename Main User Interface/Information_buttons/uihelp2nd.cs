using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Uihelpcontroller2 : MonoBehaviour
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
        _openButton = root.Q<Button>("Button_open2");
        _closeButton = root.Q<Button>("Button_close2");
        _bottomsheet = root.Q<VisualElement>("bottom_sheet2");
        _scrim = root.Q<VisualElement>("Scrim");

        _bottomContainer.style.display = DisplayStyle.None;
        _openButton.RegisterCallback<ClickEvent>(OnOpenButton2Clicked);
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButton2Clicked);

    }

    private void OnOpenButton2Clicked(ClickEvent evt)
    {
        _bottomContainer.style.display = DisplayStyle.Flex;


        _bottomsheet.AddToClassList("bottomsheet_up");
        _scrim.AddToClassList("fadein_scrim");



    }
    private void OnCloseButton2Clicked(ClickEvent evt)
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
