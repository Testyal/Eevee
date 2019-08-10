using UnityEngine;
using System;

public interface IInteractable
{ 
    event Action Interact; 
    void OnInteract();
}
