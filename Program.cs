using System;
using System.IO;

namespace Project_Ignite
{
    class Program
    {
        /// <summary>Test Encryptor</summary>
        /// <param name="input">File input</param>
        /// <param name="output">File output</param>
        /// <param name="decode">Decode File</param>
        static void Main(string[] args, FileInfo input, FileInfo output, bool decode = false)
        {
            if (args != null) {
                Console.WriteLine($"Dropped File: {args[0]}");
                Console.Write($"Password> ");
                string test = Console.ReadLine();
                Console.WriteLine(test);
            } else if (input != null & File.Exists(input.FullName) & output != null) {
                //Open.LoadFile(input);
                string text = EncodeTest.GetString(Open.LoadFile(input));
                if (!decode) {
                    text = EncodeTest.Encode(text);
                } else {
                    text = EncodeTest.Decode(text);
                }
                

                Save.SaveFile(EncodeTest.GetBytes(text), output);
            } else {
                Console.WriteLine($"*will open GUI*");
                Console.ReadKey();
            }
        }
    }
}
