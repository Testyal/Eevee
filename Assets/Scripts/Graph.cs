using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Math
{
    public class CycleNode<T>
    {
        public T Contents { get; }
        public CycleNode<T> Next { get; set; }
        
        public CycleNode(T contents, CycleNode<T> next)
        {
            Contents = contents;
            Next = next;
        }

        public CycleNode(T contents)
        {
            Contents = contents;
        }
    }

    public class Cycle<T> : IEnumerable<T>
    {
        private List<CycleNode<T>> vertices = new List<CycleNode<T>>();
        private List<T> contents = new List<T>();
        public CycleNode<T> CurrentNode { get; private set; }

        public T Next()
        {
            CurrentNode = CurrentNode.Next;
            
            return CurrentNode.Contents;
        }

        public void Add(T inNode)
        {
            vertices.Add(new CycleNode<T>(inNode));
            contents.Add(inNode);

            CurrentNode = vertices[0];

            if (vertices.Count == 1)
            {
                vertices[0].Next = vertices[0];
            }
            else
            {
                vertices[vertices.Count - 2].Next = vertices[vertices.Count - 1];
                vertices[vertices.Count - 1].Next = vertices[0];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return contents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return contents.GetEnumerator();
        }
    }
}