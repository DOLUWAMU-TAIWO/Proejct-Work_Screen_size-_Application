using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Uihelpcontroller : MonoBehaviour
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
        _openButton = root.Q<Button>("Button_open");
        _closeButton = root.Q<Button>("Button_close");
        _bottomsheet = root.Q<VisualElement>("bottom_sheet");
        _scrim = root.Q<VisualElement>("Scrim");

        _bottomContainer.style.display = DisplayStyle.None;
        _openButton.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked);

    }

    private void OnOpenButtonClicked(ClickEvent evt)
    {
        _bottomContainer.style.display = DisplayStyle.Flex;


        _bottomsheet.AddToClassList("bottomsheet_up");
        _scrim.AddToClassList("fadein_scrim");



    }
    private void OnCloseButtonClicked(ClickEvent evt)
    {
        _bottomContainer.style.display = DisplayStyle.None;

        _bottomsheet.RemoveFromClassList("bottomsheet_up");
        _scrim.RemoveFromClassList("fadein_scrim");
    }

  
}
