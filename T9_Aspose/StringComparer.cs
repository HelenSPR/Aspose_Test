using System;
using System.Collections;

namespace T9_Aspose
{
    /// <summary>
    /// search alphabet's element contained input char
    /// </summary>
    public class StringComparer : IComparer
    {
        int IComparer.Compare(object alfabet_item, object inchar)
        {
            string a = (string)alfabet_item;
            string b = inchar.ToString();

            return a.Contains(b) ? 0 : a[0].ToString().CompareTo(b);                                                  // compare current char of input string and alphabet's element
        }
    }
}
