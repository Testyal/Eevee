using System;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTooltipOnHover : MonoBehaviour, IHoverable
{
    [SerializeField] private string tooltip;
    [SerializeField] private SceneUI canvas;
    private Text tooltipField;
    private bool _isHovered;

    public bool isHovered
    {
        get { return _isHovered; }
        set 
        {
            _isHovered = value;
            tooltipField.text = isHovered ? tooltip : "";
        }
    }

    private void Start()
    {
        tooltipField = canvas.instructionField;
    }
}
