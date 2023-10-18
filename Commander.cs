using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursePanda
{
    internal class Commander
    {
        static List<Library> library;

        class Library
        {
            public Library(string f, string v = "")
            {
                key = f;
                value = v;
            }
            public string key;
            public string value;
        }


        public static void Init(string[] args)
        {
            library = new List<Library>();

            if (args.Length == 0)
                return;
            if (args.Length == 1)
            {
                Library l = new Library("-f", args[0]);
                library.Add(l);
                l = new Library("-p", "CursePanda");
                library.Add(l);
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].StartsWith("-") && args.Length > i + 1 && !args[i + 1].StartsWith("-"))
                    {
                        Library l = new Library(args[i], args[i + 1]);
                        library.Add(l);
                        i++;
                    }
                    else
                    {
                        Library l = new Library(args[i]);
                        library.Add(l);
                    }
                }
            }
        }

        public static bool HasKey(string key)
        {
            foreach (Library l in library)
            {
                if (l.key == key) return true;
            }
            return false;
        }

        public static string GetValue(string key)
        {
            foreach (Library l in library)
            {
                if (l.key == key) return l.value;
            }
            return null;
        }
    }
}
