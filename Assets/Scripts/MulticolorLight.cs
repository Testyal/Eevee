using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Math;

public class MulticolorLight : MonoBehaviour
{
    private Light controlledLight;
    /* TODO: Make a custom graph editor which we can expose to the designer */
    public Cycle<Color> colors = new Cycle<Color> {Color.red, Color.green, Color.blue};
    
    private void Start()
    {
        controlledLight = gameObject.GetComponent<Light>();
    }

    public void ChangeToNextColor()
    {
        controlledLight.color = colors.Next();
        Debug.Log("Light color is " + controlledLight.color + ", current colors node is " + colors.CurrentNode);
    }
}