using System;
using UnityEditor;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable, IHoverable
{
    private Material material;
    private static readonly int ColorID = Shader.PropertyToID("_Color");

    public void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material; 
    }

    public event Action Interact;

    public void OnInteract()
    {
        Interact?.Invoke();
    }

    public void OnFinishHover()
    {
        material.SetColor(ColorID, Color.white);
    }

    public void OnHover()
    {
        material.SetColor(ColorID, Interact != null ? Color.red : Color.white);
    }
}
