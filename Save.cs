using System;
using System.IO;
using System.Text;

namespace Project_Ignite
{
    class Save
    {
        public static bool SaveFile(byte[] outputBytes, FileInfo file)
        {
            //string outputString = Encoding.UTF8.GetString(outputBytes, 0, outputBytes.Length);
            //Console.WriteLine(outputString.Remove(0, 3));
            // Modifacation testing
            string outputString = Convert.ToBase64String(outputBytes);
            //outputString = outputString.Remove(0, 3);
            //outputString = "ggg"+ outputString;
            //outputString = outputString.Remove(0, 3);
            //outputString = "TVq"+ outputString;
            byte[] lines = Convert.FromBase64String(outputString);
            //
            //byte[] lines = Encoding.UTF8.GetBytes(outputString);
            System.IO.File.WriteAllBytes(file.FullName, lines);
            //System.IO.File.WriteAllBytes(file.FullName, Encoding.UTF8.GetBytes(outputString));
            //Console.WriteLine(stringFromByteArray);
            return true;
        }
    }
}