using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Zios;

public class Controller : MonoBehaviour
{
    public IActionControllable controlledObject;
    public IAxisControllable movableObject;

    private void Start()
    {
        controlledObject = GameObject.Find("Player").GetComponent<MovementController>();
        movableObject = GameObject.Find("Player").GetComponent<MovementController>();
    }

    private void Update()
    {
        if (controlledObject == null) return;
        
        foreach (KeyCode keycode in controlledObject.ActionCommands.Keys)
        {
            if (Input.GetKeyDown(keycode))
            { 
                controlledObject.ActionCommands[keycode]?.Execute();
            }
        }
    }

    private void FixedUpdate()
    {
        if (movableObject.IsNull()) return;
        
        movableObject.ResetMovementControls();
        if (movableObject.axisCommands.Keys.IsEmpty()) return;
        foreach (KeyCode keycode in movableObject.axisCommands.Keys)
        {
            if (Input.GetKey(keycode))
            {
                movableObject.axisCommands[keycode].Execute();
            }
        }
        movableObject.ApplyMovementControls();
    }
}
