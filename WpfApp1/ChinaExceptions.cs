using System;

namespace WpfApp1
{
    internal class ChinaExceptions : Exception
    {
        public ChinaExceptions(string message) : base(message)
        {
        }
    }

    internal class DictionaryLoadExceptions : ChinaExceptions
    {
        public DictionaryLoadExceptions(string message) : base(message)
        {
        }
    }

    internal class LinesLoadExceptions : ChinaExceptions
    {
        public LinesLoadExceptions(string message) : base(message)
        {
        }
    }

    internal class TranslateExceptions : ChinaExceptions
    {
        public TranslateExceptions(string message) : base(message)
        {
        }
    }

    internal class DictionaryFileFormatException : ChinaExceptions
    {
        public DictionaryFileFormatException(string message) : base(message)
        {
        }
    }
}