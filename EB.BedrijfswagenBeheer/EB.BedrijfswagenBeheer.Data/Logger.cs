using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.BedrijfswagenBeheer.Data
{
    public static class Logger
    {
        static Logger()
        {
            LogText = new StringBuilder();
        }
        public static StringBuilder LogText { get; set; }

        public static void Log(String text)
        {
            LogText.Append(text);
        }
        public static String ToString()
        {
            return LogText.ToString();
        }

        public static void ToClipboard()
        {
            //Clipboard.SetText(ToString());
        }

        public static void Clear()
        {
            LogText.Clear();
        }
    }
}
