using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class EducationCSV
    {
        private readonly string Description = "Description:\n\n" + "I am Keshav Lolljee and currently studying Software Engineering at the University of " +
                    "Technology, Mauritius. I am a final year student who is open to learning new technologies or developing new skills\n";

        private string csv_url = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Education.csv";
        private List<string> headings = new List<string>();
        private List<string> modules = new List<string>();
        private List<List<string>> sep_modules = new List<List<string>>();
        private List<string> projects = new List<string>();
        private List<string> sep_projects = new List<string>();
        private int expChoice;


        public void GetEducation()
        {
            ExtractEducation();
            SeparateInfo();

            bool checkGetExp = true;
            bool loopcheck2 = true;

            do
            {
                Console.Clear();

                Console.WriteLine(Description);

                Console.WriteLine("Choose a Education / Training: \n");

                foreach (var elem in headings)
                {
                    Console.WriteLine($"{headings.IndexOf(elem)} : {elem}");
                }
                Console.WriteLine($"\n\n");
                foreach (var elem in modules)
                {
                    Console.WriteLine($"{modules.IndexOf(elem)} : {elem}");
                }
                Console.WriteLine($"\n\n");
                foreach (var elem in projects)
                {
                    Console.WriteLine($"{projects.IndexOf(elem)} : {elem}");
                }
                Console.WriteLine($"\n\n");
                Console.WriteLine($"\n\n");
                foreach (var elem in sep_modules)
                {
                    Console.WriteLine($"{sep_modules.IndexOf(elem)} : {elem}");
                }
                /*Console.WriteLine($"{headings.Count} : Go Back");*/

                do
                {
                    try
                    {
                        expChoice = int.Parse(Console.ReadLine());

                        if (expChoice >= 0 && expChoice <= ((headings.Count) - 1))
                        {
                            Console.Clear();

                            //Brief Description
                            Console.WriteLine(Description);

                            Console.WriteLine($"{headings[expChoice]}:\n\n{modules[expChoice]}");

                            Console.WriteLine($"\nPress any key to go back...");

                            loopcheck2 = false;
                            checkGetExp = true;

                            Console.ReadKey();

                            break;
                        }
                        else if (expChoice == headings.Count)
                        {
                            loopcheck2 = false;
                            checkGetExp = false;

                            break;
                        }
                        else
                        {
                            errorCases();
                            loopcheck2 = true;
                            checkGetExp = true;
                        }
                    }
                    catch
                    {
                        errorCases();
                        loopcheck2 = true;
                        checkGetExp = true;
                    }
                } while (loopcheck2);
            } while (checkGetExp);
        }

        public void ExtractEducation()
        {
            headings.Clear();
            modules.Clear();
            projects.Clear();

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

                    

                    if (strCount == 2)
                    {
                        headings.Add(fields[0]);
                        modules.Add(fields[1]);
                    }
                    else
                    {
                        for (int i = 0; i < strCount; i++)
                        {

                            if (i <= ((strCount - 1) / 3))
                            {
                                headings.Add(fields[i]);
                                headings.Remove("");
                            }
                            else if (i > ((strCount - 1) / 3) && i <= (((strCount - 1) * 2) / 3))
                            {
                                modules.Add(fields[i]);
                                modules.Remove("");
                            }
                            else
                            {
                                projects.Add(fields[i]);
                                projects.Remove("");
                            }
                        }
                    }
                }
            }
        }

        public void SeparateInfo()
        {
            for (int i = 0; i < modules.Count; i++)
            {
            }
        }

        public void errorCases()
        {
            Console.Clear();

            Console.WriteLine(Description);

            Console.WriteLine("Choose a company: \n");

            foreach (var elem in headings)
            {
                Console.WriteLine($"{headings.IndexOf(elem)} : {elem}");
            }

            Console.WriteLine($"{headings.Count} : Go Back");

            Console.WriteLine("\nWrong Input! Try again.");
        }
    }
}
