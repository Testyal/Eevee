using UnityEngine;
using UnityEngine.Events;
public class SingleUseButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent interactEvent;
    private bool interacted = false;

    public void Interact()
    {
        if (interacted) return;
        interactEvent.Invoke();
        interacted = true;
    }
}
