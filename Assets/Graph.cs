using System.Collections.Generic;
using UnityEngine.UI;

namespace Math
{
    public class DiwalkNode<T>
    {
        public T Contents { get; private set; }
        public DiwalkNode<T> Next { get; set; }
        
        public DiwalkNode(T contents, DiwalkNode<T> next)
        {
            Contents = contents;
            Next = next;
        }

        public DiwalkNode(T contents)
        {
            Contents = contents;
        }
    }

    public class Diwalk<T>
    {
        private List<DiwalkNode<T>> vertices = new List<DiwalkNode<T>>();
        public DiwalkNode<T> CurrentNode { get; private set; }

        public T Next()
        {
            CurrentNode = CurrentNode.Next;
            
            return CurrentNode.Contents;
        }

        /* TODO: Make a more flexible constructor */
        public Diwalk(IEnumerable<T> inVertices)
        {
            foreach (var vertex in inVertices)
            {
                vertices.Add(new DiwalkNode<T>(vertex));
            }

            for (int i = 0; i < vertices.Count - 1; i++)
            {
                vertices[i].Next = vertices[i + 1];
            }
            vertices[vertices.Count - 1].Next = vertices[0];

            CurrentNode = vertices[0];
        }
    }
}