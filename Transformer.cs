using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CursePanda
{
    internal class Transformer
    {

        public static string codex = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!#$%&*+,-./:;<=>?@\\^_`|~";

        public static Hashtable map;

        public static void GenerateMap(string seed)
        {
            Random random = new Random(BasicHash(seed));

            string codex2 = codex;
            
            map = new Hashtable();
            foreach (char chr in codex)
            {
                string i = codex2[random.Next(codex2.Length)].ToString();
                codex2 = codex2.Replace(i, "");
                map.Add(chr.ToString(), i);
            }
        }

        public static int BasicHash(string str)
        {
            int hash1 = 5381;
            int hash2 = hash1;

            for (int i = 0; i < str.Length && str[i] != '\0'; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1) ^ str[i];
                if (i == str.Length - 1 || str[i + 1] == '\0')
                    break;
                hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
            }

            return hash1 + (hash2 * 1566083941);
        }

        public static string Replace(string input, bool reverse=false)
        {
            float length = input.Length;
            int partitionSize = 50000;

            Console.WriteLine($"Preparing Input String...");
            List<string> strings = new List<string>();
            int i = 0;
            while (input.Length > 0)
            {
                int size = (input.Length > partitionSize)?partitionSize : input.Length;
                strings.Add(input.Substring(0, size));
                input = input.Remove(0, size);
                i += 1;
            }

            Console.WriteLine($"Replacing...");
            //if (input.Length > 400000) // Might not be needed anymore? It's pretty fast now
            //{
            //    Console.WriteLine("WARNING! Input is over 400,000 characters and may take a long time to finish!");
            //}

            //string output = "";

            int progress = 0;

            Hashtable map2 = new Hashtable();
            if (reverse)
            {
                foreach (DictionaryEntry entry in map)
                {
                    map2.Add(entry.Value, entry.Key);
                }
            }

            int t = 0;
            Console.Write($"{progress}/{length}");

            List<string> output = new List<string>();
            foreach (string part in strings)
            {
                string outp = "";
                foreach (char chr in part)
                {
                    if (reverse)
                    {
                        outp += (string)map2[chr.ToString()];
                    }
                    else
                    {
                        outp += (string)map[chr.ToString()];
                    }
                    t++;
                    progress++;
                    if (t >= 10000)
                    {
                        t = 0;
                        Console.Write($"\r{progress}/{length}   ");
                    }
                }
                output.Add(outp);
            }
            Console.Write($"\r{length}/{length}   ");
            Console.WriteLine();

            return String.Join("", output);
        }
    }
}
