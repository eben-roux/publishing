using System;
using System.IO;
using System.Text.RegularExpressions;
using Shuttle.Core.Infrastructure;

namespace Markdown.Pdf.Formatter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ColoredConsole.WriteLine(ConsoleColor.Red,
                    "Specify the markdown file to format as the only parameter.");
                return;
            }

            var file = args[0];

            if (!File.Exists(file))
            {
                ColoredConsole.WriteLine(ConsoleColor.Red, $"Could not find file '{file}'.");
                return;
            }

            File.WriteAllText(file, new Regex("^#\\s", RegexOptions.Multiline).Replace(File.ReadAllText(file), "\\newpage\r\n# "));
        }
    }
}