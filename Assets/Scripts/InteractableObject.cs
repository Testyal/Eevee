using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent interactEvent;

    public void Interact()
    {
        interactEvent.Invoke();
    }
}
