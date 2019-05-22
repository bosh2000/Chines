using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Vertex
    {
        public char prefix;
        public string translateVertex;
        public List<Vertex> vertices;
        public bool final;


        public Vertex()
        {
            vertices = new List<Vertex>();
        }
        public Vertex isContainsPrefix(char value)
        {
            if (this.final) return null;
            foreach (Vertex arrValue in vertices)
            {
                if (arrValue.prefix == value) return arrValue;
            }
            return null;
        }

        public Vertex addChild(char value)
        {
            Vertex vertexValue = new Vertex() { prefix = value };
            vertices.Add(vertexValue);
            return vertexValue;
        }
    }
}
