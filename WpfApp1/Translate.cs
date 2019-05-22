namespace WpfApp1
{
    internal class Translate
    {
        private Vertex tree;
        private Lines lines;

        public Translate(Vertex dictionary, Lines lines)
        {
            this.tree = dictionary;
            this.lines = lines;
        }

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