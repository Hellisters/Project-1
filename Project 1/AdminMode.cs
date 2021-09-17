using Microsoft.VisualBasic;
using System;

namespace Project_1
{
    class AdminMode
    {
        public static void Admin()
        {
            string output = "", blabla = "wassup";
            output = Interaction.InputBox("Enter here", "Your name");
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
 