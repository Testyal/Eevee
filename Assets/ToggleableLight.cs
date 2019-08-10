using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleableLight : MonoBehaviour
{
    public Switch[] controllers;
    private Light controlledLight;
    
    private void Start()
    {
        controlledLight = GetComponent<Light>();
        
        foreach (var controller in controllers)
        {
            controller.Interact += Toggle;
        }
    }

    private void Toggle()
    {
        controlledLight.enabled = !controlledLight.enabled;
    }
}
