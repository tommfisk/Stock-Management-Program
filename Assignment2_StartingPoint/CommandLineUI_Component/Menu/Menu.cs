using System;
using System.Collections.Generic;

namespace CommandLineUI.Menu
{

    // This class implements the Composite design pattern
    class Menu : MenuElement
    {
        private List<MenuElement> children;

        public Menu(string text) : base(-1, text)
        {
            children = new List<MenuElement>();
        }

        public void Add(MenuElement menuElement)
        {
            children.Add(menuElement);
        }

        public override void Print(string indent)
        {
            Console.WriteLine("\n{0}{1}", indent, Text);
            Console.WriteLine("{0}{1}", indent, "".PadLeft(Text.Length, '='));

            foreach (MenuElement item in children)
            {
                item.Print(indent + "    ");
            }
        }
    }
}
