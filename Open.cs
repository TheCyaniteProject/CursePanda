using System;
using System.IO;
using System.Text;

namespace Project_Ignite
{
    class Open
    {
        public static byte[] LoadFile(FileInfo input)
        {
            int counter = 0;
            //string text = "0123ABCDÄÖÜ";
            byte[] lines = File.ReadAllBytes(input.FullName);
            //byte[] lines = Encoding.UTF8.GetBytes(text);
            byte[] bytes2 = new byte[lines.Length];
            //string inbytes = "";
            //string outbytes = "";
            foreach (byte line in lines) {
                //inbytes = (counter == 0)?$"bytes(in):{line.ToString()}":$"{inbytes}-{line.ToString()}";

                bytes2[counter] = line;
                //outbytes = (counter == 0)?$"bytes(out):{bytes2[counter]}":$"{outbytes}-{bytes2[counter]}";

                counter++;
            }
            //var stringFromByteArray = Encoding.UTF8.GetString(bytes2, 0, bytes2.Length); // convert modified bytes to string again
            //Console.WriteLine(inbytes);
            //Console.WriteLine(text);
            //Console.WriteLine(outbytes);
            //Console.WriteLine(stringFromByteArray);
            return bytes2;//Encoding.UTF8.GetString(bytes2, 0, bytes2.Length);;
        }
    }
}