using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CCRS.Core.Tools
{
    public static class StringTool
    {
        public static string NumbersOnly(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
