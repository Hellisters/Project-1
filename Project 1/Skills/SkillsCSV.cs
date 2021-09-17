using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class SkillsCSV : SkillsCRUD
    {
        public void GetSkills()
        {
            ExtractSkills();

            Console.Clear();

            Console.WriteLine("Skills: \n");

            foreach (var elem in ReturnList())
            {
                Console.WriteLine($"{ReturnList().IndexOf(elem) + 1}) {elem}");
            }

            Console.WriteLine($"\nPress any key to go back...");

            Console.ReadKey();
        }
    }
}
