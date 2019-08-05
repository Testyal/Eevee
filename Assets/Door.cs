using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class Door : MonoBehaviour
{
    public bool isOpen = false;
    private PlayableDirector director;

    public void Open()
    {
        if (!isOpen)
        {
            director?.Play();
            isOpen = true;
        }
    }

    public void Start()
    {
        director = gameObject.GetComponent<PlayableDirector>();
    }
}