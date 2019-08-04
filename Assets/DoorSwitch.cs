using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class DoorSwitch : Switch
{
    public Door door;

    protected override string toolTip
    {
        get 
        {
            return door.isOpen ? "" : "Press E to open door";
        }
    }

    public override void OnHover()
    {
        canvas.instruction = toolTip;
        
        if (!door.isOpen)
        {
            material.color = Color.red;
        }
    }

    public override void Interact()
    {
        if (!door.isOpen)
        {
            material.SetColor("_Color", Color.white);
            door.Open();
            door.isOpen = true;
            enabled = false;
        }
    }
}
