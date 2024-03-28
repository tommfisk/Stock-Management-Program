using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Command
{
    // Null object design pattern
    public class NullCommand : ICommand
    {
        public NullCommand() { }

        public void Execute() 
        {
            Console.WriteLine("\nThis choice is not recognised.");
        }
    }
}
