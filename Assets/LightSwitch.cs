using UnityEngine;
using System.Collections;

enum LightState
{
    On,
    Off
}

public class LightSwitch : Switch
{
    public Light controlledLight;
    private LightState lightState;

    protected override string toolTip
    {
        get
        {
            if (lightState == LightState.Off)
            {
                return "Press E to toggle light on";
            }
            return "Press E to toggle light off";
        }
    }

    public override void Interact()
    {
        if (lightState == LightState.Off)
        {
            lightState = LightState.On;
            controlledLight.enabled = true;
        }
        else
        {
            lightState = LightState.Off;
            controlledLight.enabled = false;
        }
    }

    public override void Start()
    {
        base.Start();

        lightState = controlledLight.enabled ? LightState.On : LightState.Off;
        Debug.Log("bruhhhh");
    }
}
