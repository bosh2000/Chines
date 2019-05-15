using System;
using System.Collections;
using System.IO;
using System.Text;

namespace WpfApp1
{
    internal class Lines
    {
        private ArrayList lines = new ArrayList();

        public void LoadLines(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    string line = string.Empty;
                   
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(Encoding.UTF8.GetBytes(line));
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.Error(exp.Message);
                throw new DictionaryLoadExceptions(exp.Message);
            }
            Logger.Info("Строки загружены.");
        }
    }
}