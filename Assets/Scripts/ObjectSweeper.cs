using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Zios;
using Zios.Interface;

[RequireComponent(typeof(CapsuleCollider))]
public class ObjectSweeper : MonoBehaviour
{ 
    public IInteractable interactObject;
    private IHoverable[] hoverObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactObject = other.gameObject.GetComponent<IInteractable>();
            hoverObjects = other.gameObject.GetComponents<IHoverable>();
            
            hoverObjects?.ForEach(hoverObject => hoverObject.isHovered = true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactObject = other.gameObject.GetComponent<IInteractable>();
            hoverObjects = other.gameObject.GetComponents<IHoverable>();
            hoverObjects?.ForEach(hoverObject => hoverObject.isHovered = false);
            hoverObjects = null;
            interactObject = null;
        }
    }
}
