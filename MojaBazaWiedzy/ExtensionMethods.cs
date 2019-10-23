using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    public static class ExtensionMethods
    //class ExtensionMethods
    {
        public static bool IsUrl( this String str)
        {
            var regex = new Regex("(https?://)?([A-Za-z9-0-]*\\.)?([A-Za-z9-0-]*)"+"\\.[A-Za-z0-9]*/?.*");
            return regex.IsMatch(str);
        }
    }
}
