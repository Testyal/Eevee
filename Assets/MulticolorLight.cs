using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Math;

public class MulticolorLight : MonoBehaviour
{
    public Switch[] controllers;
    private Light controlledLight;
    /* TODO: Make a custom graph editor which we can expose to the designer */
    public Diwalk<Color> colors = new Diwalk<Color>(new List<Color> {Color.red, Color.green, Color.blue});
    
    private void Start()
    {
        controlledLight = GetComponent<Light>();
        
        foreach (var controller in controllers)
        {
            controller.Interact += ChangeToNextColor;
        }
    }

    private void ChangeToNextColor()
    {
        controlledLight.color = colors.Next();
    }
}