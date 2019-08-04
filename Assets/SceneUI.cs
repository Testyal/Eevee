using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneUI : MonoBehaviour
{
    public Text instructionField;
    private string _instruction;
    public string instruction
    {
        get 
        {
            return _instruction;
        }
        set
        {
            _instruction = value;
            instructionField.text = value;
        }
    }

    public void Start()
    {
        instruction = "Hey";
    }
    
}
