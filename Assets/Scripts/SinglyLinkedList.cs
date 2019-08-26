using System.Collections;
using System.Collections.Generic;

public class SinglyLinkedListNode<T>
{
    public T contents;
    public SinglyLinkedListNode<T> next;

    public SinglyLinkedListNode(T contents)
    {
        this.contents = contents;
    }
}

public class SinglyLinkedList<T> : IEnumerable<SinglyLinkedListNode<T>>
{
    private List<SinglyLinkedListNode<T>> list = new List<SinglyLinkedListNode<T>>();
    
    private SinglyLinkedListNode<T> current;
    public T Current => current.contents;
    
    /// <summary>
    /// Advances the list, so that current now points to the previous current's next.
    /// </summary>
    /// <returns>Returns false if the list has reached the end, true otherwise.</returns>
    public bool Advance()
    {
        if (current.next == null)
        {
            return false;
        }
        else
        {
            current = current.next;
            return true;
        }
    }
    public int Count => list.Count;
    
    public void Add(T newObject)
    {
        SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(newObject);
        list.Add(newNode);

        current = list[0];
        if (list.Count >= 2) list[list.Count - 2].next = newNode;
    }
    public IEnumerator<SinglyLinkedListNode<T>> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}