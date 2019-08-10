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
        /* TODO: Must fix hovering - some frames the player interacts with an object which isn't interactable (or even hoverable) */
        interactObject = other.gameObject.GetComponent<IInteractable>();
        hoverObject = other.gameObject.GetComponent<IHoverable>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactObject?.OnInteract();
        }

        hoverObject?.OnHover();
    }

    private void OnTriggerExit(Collider other)
    {
        hoverObject = other.gameObject.GetComponent<IHoverable>();

        hoverObject?.OnFinishHover();
    }
}
