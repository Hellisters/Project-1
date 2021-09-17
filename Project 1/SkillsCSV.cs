using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class SkillsCSV
    {

        private string csv_url = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Skills.csv";
        private List<string> skills = new List<string>();


        public void GetSkills()
        {
            ExtractSkills();

            Console.Clear();

            Console.WriteLine("Skills: \n");

            foreach (var elem in skills)
            {
                Console.WriteLine($"{skills.IndexOf(elem) + 1} : {elem}");
            }

            Console.WriteLine($"\nPress any key to go back...");

            Console.ReadKey();
        }

        public void ExtractSkills()
        {
            skills.Clear();

            string[] fields;

            using (TextFieldParser parser = new TextFieldParser(csv_url))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    fields = parser.ReadFields();

                    int strCount = fields.Length;
                    for (int i = 0; i < strCount; i++)
                    {
                        if(i == 0)
                        {
                            skills.Add(fields[0]);
                            skills.Remove("");
                        }
                    }
                }
            }
        }
    }
}
