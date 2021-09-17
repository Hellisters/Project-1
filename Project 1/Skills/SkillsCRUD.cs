using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class SkillsCRUD
    {
        private string csv_url = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Skills.csv";
        private List<string> skills = new List<string>();

        public void AddSkills()
        {
            ExtractSkills();

            //before your loop
            var csv = new StringBuilder();

            Console.WriteLine("Add a new skill:\n");

            string input = Console.ReadLine();
            skills.Add(input);

            for (int i = 0; i < skills.Count; i++)
            {
                //in your loop
                var newdata = skills[i];
                var newLine = string.Format("{0},{1}{2}", newdata, "", Environment.NewLine);
                csv.Append(newLine);
            }

            //after your loop
            File.WriteAllText(csv_url, csv.ToString());
        }

        public void DeleteSkills()
        {
            ExtractSkills();

            bool checkloop = true;
            int userInput;
            var csv = new StringBuilder();

            Console.WriteLine("Choose a skill to delete:\n");

            DisplaySkillsForCRUD();

            do
            {
                try
                {
                    userInput = int.Parse("\n"+Console.ReadLine());

                    if(userInput >= 0 && userInput <= (ReturnList().Count-1))
                    {
                        ReturnList().RemoveAt(userInput);

                        for (int i = 0; i < ReturnList().Count; i++)
                        {
                            //in your loop
                            var newdata = skills[i];
                            var newLine = string.Format("{0},{1}{2}", newdata, "", Environment.NewLine);
                            csv.Append(newLine);
                        }

                        //after your loop
                        File.WriteAllText(csv_url, csv.ToString());
                        checkloop = false;
                    }
                    else
                    {
                        errorMsg();
                        checkloop = true;
                    }
                }
                catch
                {
                    errorMsg();
                    checkloop = true;
                }

            } while (checkloop);
        }

        public void errorMsg()
        {
            Console.Clear();
            Console.WriteLine("Choose a skill to delete:\n");
            DisplaySkillsForCRUD();
            Console.WriteLine("\nWrong Input! Try again.\n");
        }

        public void DisplaySkills()
        {
            ExtractSkills();

            Console.WriteLine("Current list of skills:\n");

            foreach (var elem in skills)
            {
                Console.WriteLine($"{skills.IndexOf(elem) + 1} : {elem}");
            }
        }

        public void DisplaySkillsForCRUD()
        {
            ExtractSkills();

            Console.WriteLine("Current list of skills:\n");

            foreach (var elem in skills)
            {
                Console.WriteLine($"{skills.IndexOf(elem)} : {elem}");
            }
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
                        if (i == 0)
                        {
                            skills.Add(fields[i]);
                            skills.Remove("");
                        }
                    }
                }
            }
        }
        public List<string> ReturnList()
        {
            return skills;
        }
    }
}
