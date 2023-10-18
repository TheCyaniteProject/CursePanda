using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace CursePanda
{
    class Program
    {
        // keys
        static string file = "-f";
        static string decrypt = "-d";
        static string text = "-t";
        static string useoutput = "-o";
        static string password = "-p";

        static string outputlocation = "none";

        static bool filemode = false;
        static bool decryptmode = false;

        static string content = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            Commander.Init(args);

            if (Commander.HasKey(file))
                filemode = true;

            if (Commander.HasKey(decrypt))
                decryptmode = true;

            if (Commander.HasKey(useoutput))
                outputlocation = Commander.GetValue(useoutput);

            // Start
            Read();

            if (!decryptmode)
                Encrypt();
            else 
                Decrypt();

            // End
            Write();
            // Close
            Console.WriteLine("Done.");
        }

        static void Encrypt()
        {
            Console.WriteLine("Starting Encryption...");
            Transformer.GenerateMap(Commander.GetValue(password));
            content = Transformer.Replace(content);
        }

        static void Decrypt()
        {
            Console.WriteLine("Starting Decryption...");
            Transformer.GenerateMap(Commander.GetValue(password));
            content = Transformer.Replace(content, true);
        }

        static void Read()
        {
            Console.WriteLine("Reading bytes...");
            if (filemode)
            {
                byte[] bytes = null;
                string filePath = Commander.GetValue(file);
                if (File.Exists(filePath))
                {
                    bytes = File.ReadAllBytes(filePath);
                }
                else
                {
                    Console.WriteLine("Error: File not found.");
                    Environment.Exit(0);
                }

                if (!decryptmode)
                {
                    content = Convert.ToBase64String(bytes);
                }
                else
                {
                    content = Encoding.UTF8.GetString(bytes);
                }
            }
            else if (Commander.HasKey(text))
            {
                if (!decryptmode)
                {
                    content = Convert.ToBase64String(Encoding.UTF8.GetBytes(Commander.GetValue(text)));
                }
                 else
                {
                    content = Commander.GetValue(text);
                }
            }
            else
            {
                Console.WriteLine("Error: Nothing to modify.");
                Environment.Exit(0);
            } 
        }

        static void Write()
        {
            if (filemode || outputlocation != "none")
            {
                Console.WriteLine("Writing to file...");
                string location = (outputlocation == "none") ? Commander.GetValue(file) : outputlocation;

                if (!decryptmode)
                {
                    File.WriteAllText(location, content);
                }
                else
                {
                    try
                    {
                        byte[] bytes = Convert.FromBase64String(content);

                        File.WriteAllBytes(location, bytes);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: Could not write to file. Decryption may have failed.");
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                if (!decryptmode)
                {
                    Console.WriteLine(content);
                }
                else
                {
                    try
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(content)));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: Could not write to file. Decryption may have failed.");
                        Environment.Exit(0);
                    }
                }
            }
        }

    }
}