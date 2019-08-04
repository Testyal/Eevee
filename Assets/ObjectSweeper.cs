using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]

public class ObjectSweeper : MonoBehaviour
{
    private IInteractable interactObject;
    private IHoverable hoverObject;

    private void OnTriggerStay(Collider other)
    {
        interactObject = other.gameObject.GetComponent<IInteractable>();
        /* TODO: Make hovering not rely on the big poopy capsule trigger */
        hoverObject = other.gameObject.GetComponent<IHoverable>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactObject?.Interact();
        }

        hoverObject?.OnHover();
    }

    private void OnTriggerExit(Collider other)
    {
        hoverObject = other.gameObject.GetComponent<IHoverable>();

        hoverObject?.OnFinishHover();
    }
}
