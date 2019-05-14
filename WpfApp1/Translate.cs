using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Translate
    {
        private Dictionary dictionary;
        private Lines lines;

        public Translate(Dictionary dictionary,Lines lines)
        {
            this.dictionary = dictionary;
            this.lines = lines;
        }

        public void ProccessTranslate()
        {
            throw new TranslateExceptions("Ошибка перевода");
        }

    }
}
