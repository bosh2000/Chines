using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfApp1
{
    internal class Dictionary
    {
        /// <summary>
        /// Префиксное дерево, указывает на начальный узел.
        /// </summary>
        public Vertex tree;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="tree">Начальный узел дерева.</param>
        public Dictionary(Vertex tree)
        {
            this.tree = tree;
        }
        /// <summary>
        /// Метод построковой загрузки файла словаря, создание дерева.
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadDictionary(string fileName)
        {
            //tree = new Vertex();
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

        /// <summary>
        /// Проверка на формат файла словаря. По первой строки файла.
        /// </summary>
        /// <param name="line">Первая строка файла.</param>
        /// <returns>false в случае не соответвия строки шаблону. True в случае успеха.</returns>
        private bool CheckFormatDictionaryFile(string line)
        {
            string[] checkedLine = line.Split('\t');
            return ((checkedLine[0] == "SourceText") && (checkedLine[1] == "TargetText")) ? true : false;
        }

        /// <summary>
        /// Разбор строки , разбор строки по вершинам, выстраивание дерева.
        /// </summary>
        /// <param name="line">Строка для разбора в формате Значание|TAB|перевод.</param>
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