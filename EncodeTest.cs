using System;
using System.IO;
using System.Text;

namespace Project_Ignite
{
    class EncodeTest
    {
        public static string GetString(byte[] input)
        {
            return Convert.ToBase64String(input);
        }
        public static byte[] GetBytes(string input)
        {
            return Convert.FromBase64String(input);
        }
        public static string Encode(string input)
        {
            string frst100 = "";
            string frst100modified = "";
            int count = 0;
            string output = "";
            bool shift = false;
            char chr = '0';
            foreach (char c in input) {
                if (shift) {
                    if (count < 50) {
                        frst100 += chr.ToString()+c.ToString();
                        frst100modified += c.ToString()+chr.ToString();
                    }
                    output += c.ToString()+chr.ToString();
                } else {
                    chr = c;
                }
                shift = !shift;
                count++;
            }
            Console.WriteLine(frst100);
            Console.WriteLine(frst100modified);
            return output;
        }

        public static string Decode(string input)
        {
            string frst100 = "";
            string frst100modified = "";
            int count = 0;
            string output = "";
            bool shift = false;
            char chr = '0';
            foreach (char c in input) {
                if (shift) {
                    if (count < 50) {
                        frst100 += chr.ToString()+c.ToString();
                        frst100modified += c.ToString()+chr.ToString();
                    }
                    output += c.ToString()+chr.ToString();
                } else {
                    chr = c;
                }
                shift = !shift;
                count++;
            }
            Console.WriteLine(frst100);
            Console.WriteLine(frst100modified);
            return output;
        }
    }
}