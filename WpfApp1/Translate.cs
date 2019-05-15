using System.Collections.Generic;
using System.Linq;

namespace WpfApp1
{
    internal class Translate
    {
        private Dictionary dictionary;
        private Lines lines;
        private List<byte> previosList = new List<byte>();
        private List<byte> currentList = new List<byte>();

        public Translate(Dictionary dictionary, Lines lines)
        {
            this.dictionary = dictionary;
            this.lines = lines;
        }

        public void ProccessTranslate()
        {
            int count;
            foreach (byte[] byteArrayLine in lines)
            {
                previosList.Add(byteArrayLine[0]);
                string decodeString = string.Empty;
                count = 0;
                for (int index = 0; index < byteArrayLine.Count(); index++)
                {
                    currentList.Add(byteArrayLine[index]);
                    if (dictionary.Contains(currentList))
                    {
                        previosList = currentList;
                        continue;
                    }
                    else
                    {
                        if (count < 8) {
                            count++;
                            continue;
                        } else {
                            count = 0;
                            index -= 8;
                            currentList.Clear();
                        }
                        decodeString += dictionary.GetValue(previosList.ToArray()) + " ";
                        currentList.Clear();
                        previosList.Clear();
                    }
                }
                Logger.Info(decodeString);
                decodeString = string.Empty;
            }
        }
    }
}