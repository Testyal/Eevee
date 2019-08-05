using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class DoorSwitch : Switch
{
    public Door door;

    protected override string tooltip
    {
        get => "Press E to open door";
    }

    public override void Start()
    {
        base.Start();

        if (door.isOpen)
        {
            Deactivate();
        }
    }

    protected override void Interact()
    {
        door.Open();
        Deactivate();
    }
}
