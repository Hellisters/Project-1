using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class EditSkills
    {
        private string csv_url = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Skills.csv";
        private List<string> skills = new List<string>();
        private static bool check1 = true, check2 = true;
        private static int userInput;
        public void CRUDSkills()
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

            

            do
            {
                Console.Clear();

                Console.WriteLine("Skills: \n");

                foreach (var elem in skills)
                {
                    Console.WriteLine($"{skills.IndexOf(elem)} : {elem}");
                }

                do
                {
                    try
                    {
                        userInput = int.Parse(Console.ReadLine());

                        if (userInput >= 0 && userInput <= 3)
                        {
                            check2 = false;
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();

                            foreach (var elem in skills)
                            {
                                Console.WriteLine($"{skills.IndexOf(elem)} : {elem}");
                            }

                            Console.WriteLine("\nWrong Input! Try again.");

                            userInput = int.Parse(Console.ReadLine());

                            check2 = true;
                        }
                    }
                    catch
                    {
                        Console.Clear();

                        foreach (var elem in skills)
                        {
                            Console.WriteLine($"{skills.IndexOf(elem)} : {elem}");
                        }

                        Console.WriteLine("\nWrong Input! Try again.");

                        check2 = true;
                    }
                } while (check2);

                switch ((EditSelection)userInput)
                {
                    case EditSelection.Add:

                        string filePath = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Skills.csv";
                        //before your loop
                        var csv = new StringBuilder();

                        string valuetoedit = "{" + userInput.ToString() +"}";

                        Console.WriteLine("Enter new data:\n");
                        string input = Console.ReadLine();
                        string oldval;

                        for (int i = 0; i < skills.Count; i++)
                        {
                            string othervalues = "{" + i.ToString() + "}";
                            if (i == userInput)
                            {
                                //in your loop
                                var newLine = string.Format(valuetoedit, input, Environment.NewLine);
                                csv.Append(newLine);
                            }
                            else
                            {
                                oldval = skills[i];
                                //in your loop
                                var newLine = string.Format(othervalues, oldval, Environment.NewLine);
                                csv.Append(newLine);
                            }

                            //after your loop
                            File.WriteAllText(filePath, csv.ToString());
                        }
                        

                        check2 = true;
                        userInput = -1;

                        break;


                    case EditSelection.Delete:

                        EducationCSV education_select = new EducationCSV();
                        education_select.GetEducation();
                        check2 = true;
                        userInput = -1;
                        break;

                    case EditSelection.Edit:

                        EditSkills es = new EditSkills();
                        es.CRUDSkills();
                        check2 = true;
                        userInput = -1;
                        break;

                    case EditSelection.Exit:

                        check1 = false;
                        userInput = -1;
                        break;
                }
            } while (check1);
        }
    }
}
