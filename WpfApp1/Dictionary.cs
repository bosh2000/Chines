using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Dictionary
    {
        private Dictionary<byte[], string> dict =new Dictionary<byte[], string>();
        public void LoadDictionary(string fileName)
        {
            try
            {
                using(StreamReader reader=new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    string line = string.Empty;
                    if (!CheckFormatDictionaryFile(reader.ReadLine())) throw new DictionaryFileFormatException("Неправильный формат словаря");
                    while ((line = reader.ReadLine()) != null)
                    {
                        DecodeLine(line);
                    }
                }
            }catch (Exception exp)
            {
                Logger.Error(exp.Message);
                throw new DictionaryLoadExceptions(exp.Message);
            }
            Logger.Info("Словарь загружен.");
        }

        private bool CheckFormatDictionaryFile(string line)
        {
            string[] checkedLine = line.Split('\t');
            return ((checkedLine[0]=="SourceText")&&(checkedLine[1]=="TargetText"))?true:false;
        }

        private void DecodeLine(string line)
        {
            string[] decodeLine = line.Split('\t');
            dict.Add(Encoding.UTF8.GetBytes(decodeLine[0]), decodeLine[1]);
        }


    }
}
