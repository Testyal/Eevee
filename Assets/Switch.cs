using System;
using UnityEngine;

public abstract class Switch : MonoBehaviour, IInteractable, IHoverable
{
    /// <summary>
    /// write something nice for your friends :)
    /// </summary>
    /// <value> hm what should i have for dinner </value>
    protected abstract string tooltip { get; }

    /* TODO: Come up with a method for switches to not have to have a reference to the canvas in order to communicate with it */
    public SceneUI canvas;
    protected Material material;
    private bool activated = true;

    public virtual void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
    }
    
    protected abstract void Interact();

    public void OnInteract()
    {
        if (activated)
        {
            Interact();
        }
    }

    public virtual void OnFinishHover()
    {
        canvas.instruction = ""; 
        material.SetColor("_Color", Color.white);
    }

    public virtual void OnHover()
    {
        if (activated)
        {
            canvas.instruction = tooltip;
            /* TODO: Replace changing the color to red with adding a nice outline */
            material.SetColor("_Color", Color.red);
        }
        else
        {
            canvas.instruction = "";
            material.SetColor("_Color", Color.white);
        }
    }

    public void Deactivate()
    {
        activated = false;
    }

    public void Activate()
    {
        activated = true;
    }
}
