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

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/FooBar.uxml");
        VisualElement labelFromUXML = visualTree.CloneTree();
        root.Add(labelFromUXML);
        
        List<string> list = new List<string> {"one", "two", "three"};
        ListView listView = new ListView(list, 16, () => new Label(), (e, i) => (e as Label).text = list[i]);
        listView.style.flexGrow = 1.0f;
        list.Add("nice");
        Box box = root.Q<Box>();
        box.Add(listView);
        
        Button button = root.Q<Button>("ClickMe");
        button.clickable.clicked += () => { list.Add("huhhhhh?"); };
        
        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/FooBar.uss");
        root.styleSheets.Add(styleSheet);
        
        VisualElement labelWithStyle = new Label("Hello World! With Style");
        root.Add(labelWithStyle);
    }
}

public class MyButton : Button
{
}