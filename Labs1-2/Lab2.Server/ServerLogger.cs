namespace Lab2.Server
{
    using System;
    using System.Windows.Forms;

    public static class ServerLogger
    {
        private static volatile TextBox loggerBox;

        public static TextBox LoggerBox {
            set
            {
                loggerBox = value;
            }
        }

        static object locker = new object();

        public static void LogMessage(string text)
        {
            lock (locker)
            {
                loggerBox.AppendText(text);
                loggerBox.AppendText(Environment.NewLine);
            }
        }

        public static void LogException(Exception ex)
        {
            lock (locker)
            {
                loggerBox.AppendText($"Stack Trace: {ex.StackTrace}; Message: {ex.Message}");
                loggerBox.AppendText(Environment.NewLine);
            }
        }
    }
}
