using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MulticolorLightSwitch : Switch
{
    /* TODO: Create a cyclical list class so the kinda obtuse (i+1) % colors.Length goes away */
    public Color[] colors = {Color.red, Color.green, Color.blue};
    public Light controlledLight;
    private int i = 0;

    protected override string tooltip
    {
        get => "Press E to change color to " + colors[(i + 1) % colors.Length].ToString();
    }
    public override void Start()
    {
        base.Start();

        controlledLight.color = Color.red;
    }

    /* Interacting with the switch cycles light through colors.Length different colors */
    protected override void Interact()
    {
        i = (i + 1) % colors.Length;
        controlledLight.color = colors[i];
    }
}
