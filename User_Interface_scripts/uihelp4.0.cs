using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Uihelpcontroller4 : MonoBehaviour
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
        _openButton = root.Q<Button>("Button_open4");
        _closeButton = root.Q<Button>("Button_close4");
        _bottomsheet = root.Q<VisualElement>("bottom_sheet4");
        _scrim = root.Q<VisualElement>("Scrim");

        _bottomContainer.style.display = DisplayStyle.None;
        _openButton.RegisterCallback<ClickEvent>(OnOpenButton4Clicked);
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButton4Clicked);

    }

    private void OnOpenButton4Clicked(ClickEvent evt)
    {
        _bottomContainer.style.display = DisplayStyle.Flex;


        _bottomsheet.AddToClassList("bottomview_up");
        _scrim.AddToClassList("fadein_scrim");



    }
    private void OnCloseButton4Clicked(ClickEvent evt)
    {
        _bottomContainer.style.display = DisplayStyle.None;

        _bottomsheet.RemoveFromClassList("bottomview_up");
        _scrim.RemoveFromClassList("fadein_scrim");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
