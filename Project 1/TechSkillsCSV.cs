using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class TechSkillsCSV
    {
        private string csv_url = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\TechnologicalSkills.csv";
        private List<string> techskills = new List<string>();


        public void GetTechSkills()
        {
            ExtractTechSkills();

            Console.Clear();

            Console.WriteLine("Skills: \n");

            foreach (var elem in techskills)
            {
                Console.WriteLine($"{techskills.IndexOf(elem) + 1}) {elem}");
            }

            Console.WriteLine($"\nPress any key to go back...");

            Console.ReadKey();
        }

        public void ExtractTechSkills()
        {
            techskills.Clear();

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
                        if (i == 0)
                        {
                            techskills.Add(fields[0]);
                            techskills.Remove("");
                        }
                    }
                }
            }
        }
    }
}
