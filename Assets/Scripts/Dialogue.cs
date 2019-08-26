using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public struct DialogueLine
{
    public string line;
    public string title;
    public UnityEvent unityEvent;

    public void Invoke(GameObject gameObject)
    {
        unityEvent?.Invoke();
    }
}

/* TODO: Add support for animations, timelines, that kinda shit */
/* TODO: Might be best to inherit from SinglyLinkedList than have one as a component */
public class Dialogue : SinglyLinkedList<DialogueLine>
{
    public SceneUI canvas;
    
    public void Add(string title, string line)
    {
        Add(new DialogueLine {line = line, title = title});
    }

    public void Add(string line)
    { 
        Add(new DialogueLine() {line = line, title = ""});
    }
}