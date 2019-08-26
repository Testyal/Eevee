using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Zios.Event;


public class FooBar : EditorWindow
{
    [MenuItem("Window/UIElements/FooBar")]
    public static void ShowExample()
    {
        FooBar wnd = GetWindow<FooBar>();
        wnd.titleContent = new GUIContent("FooBar");
    }

    public void OnEnable()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        VisualElement niceBox = new Box();
        niceBox.style.flexDirection = FlexDirection.Row;
        niceBox.style.marginLeft = 10;
        niceBox.style.marginRight = 10;
        niceBox.style.marginTop = 10;
        niceBox.style.paddingTop = 10;
        root.Add(niceBox);
        
        niceBox.Add(new Label("Check this out"));
        niceBox.Add(new TextField());
    }
}

public class MyButton : Button
{
}