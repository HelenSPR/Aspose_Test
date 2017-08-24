using System;
using System.Collections;
using System.Collections.Generic;

namespace T9_Aspose
{
   /// <summary>
   /// Class implements build out text T9
   /// </summary>
    public class Mapper
    {
        /// <summary>
        /// const alfabet
        /// </summary>
        public readonly static ArrayList alphabet = new ArrayList() { "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

        /// <summary>
        /// Method start of transformation input text to lines of numeric
        /// </summary>
        /// <param name="inlines">input text</param>
        /// <returns></returns>
        public static List<string> Run(string[] inlines)
        {
            List<string> result = new List<string>();                                                       // result array out text

            int count_case = 0;
            Int32.TryParse(inlines[0], out count_case);                                                     // try parse count of case

            for (int i = 1; i <= count_case; i++)
                result.Add(string.Format("Case #{0}: {1}", i.ToString(), GetMapLine(inlines[i])));          // add to resulting array the sequence's numeric for the current line

            return result;
        }

        /// <summary>
        /// create mapper numeric sequence for each char of input line
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMapLine(string input)
        {
            string result = string.Empty;

            char[] InChar = input.ToCharArray();                                            // split input string to char array

            char previous = 'z';                                                            // initial value never meet in a sequence of numbers
            foreach (char c in InChar)
            {
                string map = GetMapChar(c);                                                 // get sequence of numbers for the current input char string
                if (map.Length > 0)
                {
                    result += map[0] == previous ? string.Concat(" ", map) : map;           // add current sequence to result string, given the previous char
                    previous = map[0];                                                      // save first char of current sequence as previous char
                }
            }

            return result;
        }

        /// <summary>
        /// create mapper numeric sequence for input char
        /// </summary>
        /// <param name="inchar">current char of input string</param>
        /// <returns></returns>
        private static string GetMapChar(char inchar)
        {
            if (Char.IsWhiteSpace(inchar)) return "0";

            string result = string.Empty;

            int index = alphabet.BinarySearch(inchar.ToString(), new StringComparer());                             // binary search of alphabet's element , which includes the current character
            int position = alphabet[index].ToString().IndexOf(inchar);                                              // search character position in string alphabet's element 

            for (int i = 0; i <= position; i++)
                result += (index + 1).ToString();                                                                   // to summarize result sequence

            return result;
        }

    }
}
