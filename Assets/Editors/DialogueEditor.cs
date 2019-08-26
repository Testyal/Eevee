using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class FooWindow : EditorWindow
{
    [MenuItem("Bar/Foo")]
    static void MakeWindow()
    {
        FooWindow window = GetWindow<FooWindow>();
    }

    private void OnEnable()
    {
        VisualElement root = rootVisualElement;
        
        Button button = new Button(() =>
        {
            Debug.Log("Nice one my dude");
        })
        {
            text = "Click me to show a funny message"
        };
        root.Add(button);
    }
}