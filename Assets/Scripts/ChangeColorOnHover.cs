using System;
using UnityEngine;

public class ChangeColorOnHover : MonoBehaviour, IHoverable
{
    [SerializeField] private Color color = Color.red;
    private Color originalColor;
    private Material material;
    private static readonly int ColorField = Shader.PropertyToID("_Color");
    private bool _isHovered;

    public bool isHovered
    {
        get => _isHovered;
        set
        {
            _isHovered = value;
            material.SetColor(ColorField, _isHovered ? color : originalColor);
        }
    }

    private void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
        originalColor = material.color;
    }
}
