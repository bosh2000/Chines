using System;
using System.Collections;
using System.IO;
using System.Text;

namespace WpfApp1
{
    internal class Lines : IEnumerable
    {
        private ArrayList lines = new ArrayList();

        public void LoadLines(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName, System.Text.Encoding.UTF8))
                {
                    string line = string.Empty;

                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.Error(exp.Message);
                throw new LinesLoadExceptions(exp.Message);
            }
            Logger.Info("Строки загружены.");
        }

        public IEnumerator GetEnumerator()
        {
            return lines.GetEnumerator();
        }

    }
}