using System;
using UnityEngine;

public abstract class Switch : MonoBehaviour, IInteractable, IHoverable
{
    protected abstract string toolTip { get; }

    /* TODO: Come up with a method for switches to not have to have a reference to the canvas in order to communicate with it */
    public SceneUI canvas;
    protected Material material;

    public virtual void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;

        Debug.Log("Switch material is " + material.name);
    }
    
    public abstract void Interact();

    public virtual void OnFinishHover()
    {
        canvas.instruction = "";
        material.SetColor("_Color", Color.white);
    }

    public virtual void OnHover()
    {
        canvas.instruction = toolTip;
        /* TODO: Replace changing the color to red with adding a nice outline */
        material.SetColor("_Color", Color.red);
    }
}
