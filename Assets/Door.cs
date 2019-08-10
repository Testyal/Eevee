using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public Switch[] controllers;
    private PlayableDirector director;

    public void Open()
    {
        if (isOpen) return;
        director?.Play();
        isOpen = true;

        foreach (Switch controller in controllers)
        {
            controller.Interact -= Open;
        }
    }

    public void Start()
    {
        director = gameObject.GetComponent<PlayableDirector>();

        foreach (Switch controller in controllers)
        {
            controller.Interact += Open;
        }
    }
}