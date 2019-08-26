using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* TODO: Add support for avatars, different dialogue boxes, voicelines, etc */
public class DialogueBox : MonoBehaviour
{
    [SerializeField] private SceneUI canvas;
    [SerializeField] private Text dialogueTextField;
    [SerializeField] private Text titleField;
    
    public void Initialize()
    {
        gameObject.SetActive(true);
        canvas.instructionField.text = "";
    }

    public void Deinitialize()
    {
        gameObject.SetActive(false);
    }

    public void ShowLine(DialogueLine dialogueLine)
    {
        dialogueTextField.text = dialogueLine.line;
        titleField.text = dialogueLine.title;
    }
}
