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
            var csv = new StringBuilder();
            bool checkloop = true;
            int userInput;

            Console.Clear();

            DisplaySkills();

            Console.WriteLine($"\nChoose an action:\n0 : Add new skill\n1 : Cancel addition\n");

            do
            {
                    bool checkiftrue = int.TryParse("\n" + Console.ReadLine(), out userInput);

                    if (checkiftrue && (userInput >= 0 && userInput <= (skills.Count)))
                    {
                        checkloop = false;

                        Console.Clear();

                        Console.WriteLine("Addition cancelled!");
                        Console.WriteLine($"\nPress any key to go back...");

                        Console.ReadKey();
                    }
                    else if(userInput == 0)
                    {
                        Console.Clear();

                        Console.WriteLine("Add a new skill:\n");

                        string newskill = Console.ReadLine();

                        skills.Add(newskill);

                        for (int i = 0; i < skills.Count; i++)
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
                        errorAdd();
                        checkloop = true;
                    }

            } while (checkloop);
        }

        public void DeleteSkills()
        {
            ExtractSkills();

            bool checkloop = true;
            int userInput;
            var csv = new StringBuilder();

            Console.Clear();

            DisplaySkillsForCRUD();

            Console.WriteLine($"\n{skills.Count} : Cancel delete");

            Console.WriteLine("\nChoose a skill to delete:\n");

            do
            {
                bool checkiftrue = int.TryParse("\n" + Console.ReadLine(), out userInput);

                if (checkiftrue && (userInput >= 0 && userInput <= (skills.Count)))
                {
                    if (userInput == skills.Count)
                        {
                            checkloop = false;

                            Console.Clear();

                            Console.WriteLine("Deletion cancelled!");
                            Console.WriteLine($"\nPress any key to go back...");

                            Console.ReadKey();
                        }
                    else
                    {
                        skills.RemoveAt(userInput);

                        for (int i = 0; i < skills.Count; i++)
                        {
                            //in your loop
                            var newdata = skills[i];
                            var newLine = string.Format("{0},{1}{2}", newdata, "", Environment.NewLine);
                            csv.Append(newLine);
                        }

                        //after your loop
                        File.WriteAllText(csv_url, csv.ToString());
                        checkloop = false;

                        Console.Clear();

                        Console.WriteLine("Skill deleted successfully!");
                        Console.WriteLine($"\nPress any key to go back...");

                        Console.ReadKey();
                        }
                        
                    }
                else
                {
                    errorDelete();
                    checkloop = true;
                }
            } while (checkloop);
        }


        public void UpdateSkills()
        {
            ExtractSkills();

            bool checkloop = true;
            int userInput;
            var csv = new StringBuilder();
            string newSkill;

            Console.Clear();

            DisplaySkillsForCRUD();

            Console.WriteLine($"\n{skills.Count} : Cancel update");

            Console.WriteLine("\nChoose a skill to update:\n");

            do
            {
                bool checkiftrue =  int.TryParse("\n" + Console.ReadLine(), out userInput);

                if (checkiftrue && (userInput >= 0 && userInput <= (skills.Count)))
                {
                    if (userInput == skills.Count)
                    {
                        checkloop = false;

                        Console.Clear();

                        Console.WriteLine("Update cancelled!");
                        Console.WriteLine($"\nPress any key to go back...");

                        Console.ReadKey();

                    }
                    else
                    {
                        Console.Clear();

                        Console.WriteLine("Enter the new skill:\n");

                        newSkill = Console.ReadLine();

                        skills[userInput] = newSkill;

                        for (int i = 0; i < skills.Count; i++)
                        {
                            //in your loop
                            var newdata = skills[i];
                            var newLine = string.Format("{0},{1}{2}", newdata, "", Environment.NewLine);
                            csv.Append(newLine);
                        }

                        //after your loop
                        File.WriteAllText(csv_url, csv.ToString());
                        checkloop = false;

                        Console.Clear();

                        Console.WriteLine("Skill updated successfully!");
                        Console.WriteLine($"\nPress any key to go back...");

                        Console.ReadKey();
                        }  
                }
                else
                {
                    errorUpdate();
                    checkloop = true;
                }
            } while (checkloop);
        }

        public void errorUpdate()
        {
            Console.Clear();

            Console.WriteLine("Wrong Input! Try again.\n");

            DisplaySkillsForCRUD();

            Console.WriteLine($"\n{skills.Count} : Cancel update");

            Console.WriteLine("\nChoose a skill to update:\n");

            
        }

        public void errorAdd()
        {
            Console.Clear();

            Console.WriteLine("Wrong Input! Try again.\n");

            DisplaySkills();

            Console.WriteLine($"\nChoose an action:\n0 : Add new skill\n1 : Cancel addition\n");

            
        }

        public void errorDelete()
        {
            Console.Clear();

            Console.WriteLine("Wrong Input! Try again.\n");

            DisplaySkillsForCRUD();

            Console.WriteLine($"\n{skills.Count} : Cancel delete");

            Console.WriteLine("\nChoose a skill to delete:\n");
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
