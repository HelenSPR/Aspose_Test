using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> result = new List<string>();

            Console.Write("Please enter the path to the input file: ");
            string pathfile = Console.ReadLine();

            if (File.Exists(pathfile))                                                                                                  // if input file exists?
            {
                try
                {
                    result = T9_Aspose.Mapper.Run(File.ReadAllLines(pathfile, Encoding.UTF8));                                          // start of transformation input lines 'a-z' to lines of numeric '0-9'

                    string pathout = Path.Combine(Path.GetDirectoryName(pathfile), String.Concat(Path.GetFileNameWithoutExtension(pathfile), ".out"));      // combine output file path
                    File.WriteAllLines(pathout, result, Encoding.ASCII);                                                                // write result text to output file

                    Console.WriteLine("The path to the output file {0}", pathout);
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("Congratulations! You found our bug! Ask for the prise in return: [ {0} ]", e.Message));            
                }
            }
            else
                Console.WriteLine(" File {0} not exists!", pathfile);
                


            Console.ReadKey();
        }
    }


}
