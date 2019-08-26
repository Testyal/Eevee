using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneUI : MonoBehaviour
{
    public Text instructionField;
    public DialogueBox dialogueBox;

    public void DisplayTip(string tip)
    {
        instructionField.text = tip;
    }

    public void ClearTip()
    {
        instructionField.text = "";
    }

    public void Start()
    {
        DisplayTip("Hey");
    }
    
}
