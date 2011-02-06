using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DVBViewer_iMonDisplayPlugin
{
    class Helper
    {
        public static string ReplaceGermanSpecialCharsForVFD(string input)
        {
            string result = String.Empty;
            result = input.Replace("ä", "ae");
            result = result.Replace("ö", "oe");
            result = result.Replace("ü", "ue");
            result = result.Replace("ß", "ss");
            return result;
        }
    }
}
