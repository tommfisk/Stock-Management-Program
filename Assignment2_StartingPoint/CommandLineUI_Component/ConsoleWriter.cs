using System;
using System.Collections.Generic;

namespace CommandLineUI
{
    class ConsoleWriter
    {
        public static void WriteStrings(List<string> lines)
        {
            lines.ForEach(Console.WriteLine);
        }
    }
}
