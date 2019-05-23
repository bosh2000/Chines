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
        public Dictionary<char,Vertex> vertices;
        public bool final;


        public Vertex()
        {
            vertices = new Dictionary<char, Vertex>() ;
        }
        public Vertex isContainsPrefix(char value)
        {
            if (this.final) return null;
            //foreach (Vertex arrValue in vertices)
            //{
            //    if (arrValue.prefix == value) return arrValue;
            //}
            if (vertices.ContainsKey(value)) { return vertices[value]; }
            return null;
        }

        public Vertex addChild(char value)
        {
            Vertex vertexValue = new Vertex() { prefix = value };
            vertices.Add(value,vertexValue);
            return vertexValue;
        }
    }
}
