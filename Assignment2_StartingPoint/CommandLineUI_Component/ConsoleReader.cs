using System;

namespace CommandLineUI
{
    class ConsoleReader
    {
        public static int ReadInt(string prompt)
        {
            try
            {
                Console.Write(prompt + ": > ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
