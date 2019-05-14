using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApp1
{
    internal static class Logger
    {
        /// <summary>
        /// TextBox на главном окне для вывода отчетов.
        /// </summary>
        private static TextBox LoggerArea;

        private static Dispatcher dispatcher;

        public static void Init(TextBox textBox, Dispatcher disp)
        {
            LoggerArea = textBox;
            dispatcher = disp;
        }

        /// <summary>
        /// Вывод сообщений с пометкой INFO
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            if ((LoggerArea != null) && (dispatcher != null)){
                dispatcher.BeginInvoke(new Action(() => LoggerArea.Text = LoggerArea.Text + GetDateTime() + " INFO:" + message + "\n"));
            }
        }

        /// <summary>
        /// Вывод сообщений с пометкой ERROR
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message) { 
            if ((LoggerArea != null) && (dispatcher != null))
            {
                dispatcher.BeginInvoke(new Action(() => LoggerArea.Text = LoggerArea.Text + GetDateTime() + " ERROR:" + message + "\n"));
            }
        }
        private static string GetDateTime()
        {
            string retValue = string.Empty;
            DateTime dt = DateTime.Now;
            return retValue = dt.ToShortDateString() + " " + dt.ToLongTimeString();
        }
    }
}