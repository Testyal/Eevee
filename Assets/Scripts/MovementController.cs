using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TODO: Call this a PlayerController and delegate stuff to a MovementController and ActionController class or something */
public class MovementController : MonoBehaviour, IActionControllable, IAxisControllable
{
    [HideInInspector] public float forwardInput;
    [HideInInspector] public float sideInput;

    private PlayerMovement playerMovement;
    private ObjectSweeper objectSweeper;
    private Animator animator;
    [SerializeField] private CameraController cameraController;

    private Dictionary<KeyCode, IActionCommand> _actionCommands = new Dictionary<KeyCode, IActionCommand>();
    public Dictionary<KeyCode, IActionCommand> ActionCommands => _actionCommands;
    private Dictionary<KeyCode, IAxisCommand> _axisCommands = new Dictionary<KeyCode, IAxisCommand>();
    public Dictionary<KeyCode, IAxisCommand> axisCommands => _axisCommands;
    [SerializeField] private Controller _controller;
    public Controller controller => _controller;

    public bool isControlled
    {
        get => controller.controlledObject == this;
        set
        {
            if (value)
            {
                controller.controlledObject = this;
            }
        }
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        objectSweeper = GetComponent<ObjectSweeper>();
        animator = GetComponent<Animator>();
        
        _axisCommands.Add(KeyCode.W, new ForwardAxisCommand(this, 1.0f));
        _axisCommands.Add(KeyCode.A, new SideAxisCommand(this, -1.0f));
        _axisCommands.Add(KeyCode.S, new ForwardAxisCommand(this, -1.0f));
        _axisCommands.Add(KeyCode.D, new SideAxisCommand(this, 1.0f));
        
        _actionCommands.Add(KeyCode.T, new TurnAroundCommand(playerMovement));
        _actionCommands.Add(KeyCode.E, new InteractCommand(objectSweeper));
    }

    public void ResetMovementControls()
    {
        forwardInput = 0.0f;
        sideInput = 0.0f;
    }

    public void ApplyMovementControls()
    {
        if (forwardInput > 0.1f || forwardInput < -0.1f || sideInput > 0.1f || sideInput < -0.1f)
        {
            playerMovement.SetRotation(cameraController.transform.eulerAngles.y);
        }
        animator.SetFloat("Speed", forwardInput);
        playerMovement.Move(forwardInput, sideInput);
    }
}


class TurnAroundCommand : IActionCommand
{
    private PlayerMovement playerMovement;

    public TurnAroundCommand(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }

    public void Execute()
    {
        playerMovement.Rotate(180.0f);
    }
}

class InteractCommand : IActionCommand
{
    private ObjectSweeper objectSweeper;

    public InteractCommand(ObjectSweeper objectSweeper)
    {
        this.objectSweeper = objectSweeper;
    }

    public void Execute()
    {
        objectSweeper.interactObject?.Interact();
    }
}

class ForwardAxisCommand : IAxisCommand
{
    private MovementController movementController;
    private float keyAxisValue;

    public ForwardAxisCommand(MovementController movementController, float keyAxisValue)
    {
        this.movementController = movementController;
        this.keyAxisValue = keyAxisValue;
    }
    public void Execute()
    {
        movementController.forwardInput += keyAxisValue;
    }
}

class SideAxisCommand : IAxisCommand
{
    private MovementController movementController;
    private float keyAxisValue;

    public SideAxisCommand(MovementController movementController, float keyAxisValue)
    {
        this.movementController = movementController;
        this.keyAxisValue = keyAxisValue;
    }
    public void Execute()
    {
        movementController.sideInput += keyAxisValue;
    }
}