using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDialogueOnInteract : MonoBehaviour, IInteractable
{
    private DialogueDirector dialogueDirector;
    private DialogueDirectorController dialogueDirectorController;


    private void Start()
    {
        dialogueDirector = GetComponent<DialogueDirector>();
        dialogueDirectorController = GetComponent<DialogueDirectorController>();
    }

    public void Interact()
    {
        dialogueDirector.Initialize();
        dialogueDirectorController.TakeControls();
    }
}
