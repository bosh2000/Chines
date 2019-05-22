using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfApp1
{
    internal class Dictionary
    {
        public Vertex tree;

        public Dictionary(Vertex tree)
        {
            this.tree = tree;
        }

        public void LoadDictionary(string fileName)
        {
            tree = new Vertex();
            try
            {
                using (StreamReader reader = new StreamReader(fileName, System.Text.Encoding.UTF8))
                {
                    string line = string.Empty;
                    if (!CheckFormatDictionaryFile(reader.ReadLine())) throw new DictionaryFileFormatException("Неправильный формат словаря");
                    while ((line = reader.ReadLine()) != null)
                    {
                        DecodeLine(line);
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.Error(exp.Message);
                throw new DictionaryLoadExceptions(exp.Message);
            }
            Logger.Info("Словарь загружен.");
        }

        private bool CheckFormatDictionaryFile(string line)
        {
            string[] checkedLine = line.Split('\t');
            return ((checkedLine[0] == "SourceText") && (checkedLine[1] == "TargetText")) ? true : false;
        }

        private void DecodeLine(string line)
        {
            string[] decodeLine = line.Split('\t');
            char[] word = decodeLine[0].ToArray();
            Vertex vertex = tree;
            foreach (char arrValue in word)
            {
                Vertex tmpVertex = vertex.isContainsPrefix(arrValue);
                if (tmpVertex != null)
                {
                    vertex = tmpVertex;
                }
                else
                {
                    vertex = vertex.addChild(arrValue);
                }
            }
            vertex.translateVertex = decodeLine[1];
        }

    }
}