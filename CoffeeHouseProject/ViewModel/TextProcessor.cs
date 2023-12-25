using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouseProject.ViewModel
{
    internal class TextProcessor
    {
        public string DeleteSpaces(string text)
        {
            if (text == null) return default;
            string result = text;
            for (int i = 0; i < result.Length; i++)
                if (result[i] == ' ') result = result.Remove(i);
            return result;
        }
    }
}
