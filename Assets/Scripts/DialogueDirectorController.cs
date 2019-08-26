using System.Collections.Generic;
using UnityEngine;

public class DialogueDirectorController : MonoBehaviour, IActionControllable
{
    private DialogueDirector dialogueDirector;
    private IActionControllable previouslyControlledObject;
    private IAxisControllable previouslyAxisControlledObject;
    
    [SerializeField] private Controller controller;

    private Dictionary<KeyCode, IActionCommand> actionCommands = new Dictionary<KeyCode, IActionCommand>();
    public Dictionary<KeyCode, IActionCommand> ActionCommands => actionCommands;
    
    private void Start()
    {
        dialogueDirector = GetComponent<DialogueDirector>();
        
        actionCommands.Add(KeyCode.E, new AdvanceDialogueCommand(dialogueDirector, this));
    }

    public void TakeControls()
    {
        previouslyControlledObject = controller.controlledObject;
        previouslyAxisControlledObject = controller.movableObject;
        
        controller.controlledObject = this;
        controller.movableObject = null;
    }

    public void RelinquishControls()
    {
        controller.controlledObject = previouslyControlledObject;
        controller.movableObject = previouslyAxisControlledObject;
    }
}

public class AdvanceDialogueCommand : IActionCommand
{
    private DialogueDirector dialogueDirector;
    private DialogueDirectorController dialogueDirectorController;

    public AdvanceDialogueCommand(DialogueDirector dialogueDirector, DialogueDirectorController dialogueDirectorController)
    {
        this.dialogueDirector = dialogueDirector;
        this.dialogueDirectorController = dialogueDirectorController;
    }
    
    public void Execute()
    {
        bool hasAdvanced = dialogueDirector.Advance();

        if (!hasAdvanced)
        {
            dialogueDirectorController.RelinquishControls();
        }
    }
}