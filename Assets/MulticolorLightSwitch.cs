using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MulticolorLightSwitch : Switch
{
    public Light multicolorLight;

    enum State
    {
        red,
        green,
        blue
    } 
    private State state = State.red;

    public override void Start()
    {
        base.Start();

        multicolorLight.color = Color.red;
    }

    public override void Interact()
    {
        switch (state)
        {
            case State.red:
            multicolorLight.color = Color.blue;
            state = State.blue;
            break;

            case State.blue:
            multicolorLight.color = Color.green;
            state = State.green;
            break;

            case State.green:
            multicolorLight.color = Color.red;
            state = State.red;
            break;

            default:
            break;

        }
    }

    protected override string toolTip
    {
        get
        {
            switch (state)
            {
                case State.red:
                return "Press E to change light color to blue";

                case State.blue:
                return "Press E to change light color to green";

                case State.green:
                return "Press E to change light color to red";

                default:
                Debug.Log("State took a value it wasn't meant to");
                return "";
            }
        }
    }
}
