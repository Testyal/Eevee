using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zios;

public class DialogueDirector : MonoBehaviour
{
    [SerializeField] private SceneUI canvas;
    private IActionControllable previouslyControlledObject;

    public Dialogue dialogue;

    public void Initialize()
    {
        canvas.dialogueBox.Initialize();
        canvas.dialogueBox.ShowLine(dialogue.Current);
    }

    public void Deinitialize()
    {
        canvas.dialogueBox.Deinitialize();
    }

    public bool Advance()
    {
        bool hasAdvanced = dialogue.Advance();
        if (hasAdvanced)
        {
            canvas.dialogueBox.ShowLine(dialogue.Current);
        }
        else
        {
            Deinitialize();
        }
        return hasAdvanced;
    }
}
