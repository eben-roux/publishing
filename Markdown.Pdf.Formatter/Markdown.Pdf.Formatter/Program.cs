using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Markdown.Pdf.Formatter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            if (args.Length == 0)
            {
                Console.WriteLine("Specify the markdown file to format as the only parameter.");
                return;
            }

            var file = args[0];

            if (!File.Exists(file))
            {
                Console.WriteLine($"Could not find file '{file}'.");
                return;
            }

            File.WriteAllText(file, new Regex("^#\\s", RegexOptions.Multiline).Replace(File.ReadAllText(file), "\\newpage\r\n# "));
        }
    }
}