using System;

namespace WpfApp1
{
    internal class Translate
    {
        /// <summary>
        /// Дерево словаря.
        /// </summary>
        private Vertex tree;
        
        /// <summary>
        /// Массив строк для перевода.
        /// </summary>
        private Lines lines;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dictionary">Дерево словаря.</param>
        /// <param name="lines">Массив строк.</param>
        public Translate(Vertex dictionary, Lines lines)
        {
            this.tree = dictionary;
            this.lines = lines;
        }

        /// <summary>
        /// Процесс "перевода", обход вершин дерева, и по обходу состовляется строка перевода.
        /// </summary>
        public void ProccessTranslate()
        {
            string decodeString = string.Empty;
            foreach (string str in lines)
            {
                decodeString = string.Empty;
                char[] charArr = str.ToCharArray();
                Vertex tmpVertex = tree;
                foreach (char charValue in charArr)
                {
                    if (Char.IsDigit(charValue) || Char.IsSeparator(charValue)) { decodeString += charValue; continue; }
                    Vertex vertex = tmpVertex.isContainsPrefix(charValue);
                    if (vertex != null) { tmpVertex = vertex; }
                    else
                    {
                        decodeString += tmpVertex.translateVertex + " ";
                        tmpVertex = tree;
                    }
                }
                Logger.Info(decodeString + "\b\r");
            }
        }
    }
}