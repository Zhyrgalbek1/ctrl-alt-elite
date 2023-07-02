using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Meneger.Controllers.Additional_settings
{
    class AutoCompletionHandler : IAutoCompleteHandler
    {
        public char[] Separators { get; set; } = new char[] { ' ', '.', '/' };

        public string[] GetSuggestions(string text, int index)
        {
            if (text.StartsWith("Help "))
            {
                return new string[] { "Default", "Erzhan", "Adil", "Jirgal" };
            }
            else
            {
                return null;
            }
        }
    }
}
