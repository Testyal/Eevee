using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleableLight : MonoBehaviour
{
    private Light controlledLight;

    private void Start()
    {
        controlledLight = GetComponent<Light>();
    }

    public void Toggle()
    {
        controlledLight.enabled = !controlledLight.enabled;
    }
}
