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
    
    public Dialogue dialogue = new Dialogue
    {
        {"Billy", "Hey buddy I think you got the wrong door, the leather club's two blocks down"},
        {"Van Darkholme", "Fuck you"}, 
        {"Billy", "No fuck you, leatherman. Maybe you and I should settle it right here on the ring if you think you're so tough"},
        {"Van Darkholme", "Oh yeah? I'll kick your ass!"},
        {"Billy", "Ha! Yeah right man. Let's go! Why don't you get out of that leather stuff? I'll strip down out of this and we'll settle it right here in the ring, whaddaya say?"},
        {"Van Darkholme", "Yeah, no problem buddy"},
        {"Billy", "You got it. Get out of that uhh, jabroni outfit"},
        {"Van Darkholme", "Yeah, smartass"},
        {"Billy", "I'll show you who's boss of this gym"}
    };

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
