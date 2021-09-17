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
        private string y1_module = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Year1_Modules.csv";
        private string y1_project = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Year1_Projects.csv";
        private string y2_module = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Year2_Modules.csv";
        private string y2_project = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Year2_Projects.csv";
        private string y3_module = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Year3_Modules.csv";
        private string y3_project = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Year3_Projects.csv";
        private List<string> headings = new List<string>();
        private List<string> modules = new List<string>();
        private List<string> projects = new List<string>();
        private int expChoice;


        public void GetEducation()
        {
            

            bool checkGetExp = true;
            bool loopcheck2 = true;

            do
            {
                Console.Clear();

                Console.WriteLine("Choose a Education / Training:\n0 : Software Engineering ( Year 1 )\n1 : Software Engineering ( Year 2 )\n2 : Software Engineering ( Year 3 )\n3 : Go Back");

                do
                {
                    try
                    {
                        expChoice = int.Parse(Console.ReadLine());

                        if (expChoice >= 0 && expChoice <=3)
                        {
                            switch ((EducationSelection)expChoice)
                            {
                                case EducationSelection.Year1:

                                    ExtractYear1();

                                    Console.Clear();

                                    Console.WriteLine($"Software Engineering ( Year 2 ):\n");
                                    Console.WriteLine($"Module(s):\n");

                                    foreach (var elem1 in modules)
                                    {
                                        Console.WriteLine($"{modules.IndexOf(elem1) + 1}) {elem1}");
                                    }

                                    Console.WriteLine($"\nProject(s):\n");

                                    foreach (var elem2 in projects)
                                    {
                                        Console.WriteLine($"{projects.IndexOf(elem2) + 1}) {elem2}");
                                    }

                                    Console.WriteLine($"\nPress any key to go back...");

                                    loopcheck2 = false;
                                    checkGetExp = true;

                                    Console.ReadKey();

                                    break;

                                case EducationSelection.Year2:

                                    ExtractYear2();

                                    Console.Clear();

                                    Console.WriteLine($"Software Engineering ( Year 2 ):\n");
                                    Console.WriteLine($"Module(s):\n");

                                    foreach (var elem1 in modules)
                                    {
                                        Console.WriteLine($"{modules.IndexOf(elem1) + 1}) {elem1}");
                                    }

                                    Console.WriteLine($"\nProject(s):\n");

                                    foreach (var elem2 in projects)
                                    {
                                        Console.WriteLine($"{projects.IndexOf(elem2) + 1}) {elem2}");
                                    }

                                    Console.WriteLine($"\nPress any key to go back...");

                                    loopcheck2 = false;
                                    checkGetExp = true;

                                    Console.ReadKey();

                                    break;

                                case EducationSelection.Year3:

                                    ExtractYear3();

                                    Console.Clear();

                                    Console.WriteLine($"Software Engineering ( Year 3 ):\n");
                                    Console.WriteLine($"Module(s):\n");

                                    foreach (var elem1 in modules)
                                    {
                                        Console.WriteLine($"{modules.IndexOf(elem1) + 1}) {elem1}");
                                    }

                                    Console.WriteLine($"\nProject(s):\n");

                                    foreach (var elem2 in projects)
                                    {
                                        Console.WriteLine($"{projects.IndexOf(elem2) + 1}) {elem2}");
                                    }

                                    Console.WriteLine($"\nPress any key to go back...");

                                    loopcheck2 = false;
                                    checkGetExp = true;

                                    Console.ReadKey();

                                    break;

                                case EducationSelection.Exit:

                                    loopcheck2 = false;
                                    checkGetExp = false;

                                    break;
                            }
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

        public void ExtractYear1()
        {
            modules.Clear();
            projects.Clear();

            string[] field1;
            string[] field2;

            using (TextFieldParser parser = new TextFieldParser(y1_module))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    field1 = parser.ReadFields();

                    int strCount = field1.Length;

                    for (int i = 0; i < strCount; i++)
                    {
                        modules.Add(field1[i]);                         
                    }                   
                }
            }

            using (TextFieldParser parser = new TextFieldParser(y1_project))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    field2 = parser.ReadFields();

                    int strCount = field2.Length;

                    for (int i = 0; i < strCount; i++)
                    {
                        projects.Add(field2[i]);
                    }
                }
            }
        }

        public void ExtractYear2()
        {
            modules.Clear();
            projects.Clear();

            string[] field1;
            string[] field2;

            using (TextFieldParser parser = new TextFieldParser(y2_module))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    field1 = parser.ReadFields();

                    int strCount = field1.Length;

                    for (int i = 0; i < strCount; i++)
                    {
                        modules.Add(field1[i]);
                    }
                }
            }

            using (TextFieldParser parser = new TextFieldParser(y2_project))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    field2 = parser.ReadFields();

                    int strCount = field2.Length;

                    for (int i = 0; i < strCount; i++)
                    {
                        projects.Add(field2[i]);
                    }
                }
            }
        }

        public void ExtractYear3()
        {
            modules.Clear();
            projects.Clear();

            string[] field1;
            string[] field2;

            using (TextFieldParser parser = new TextFieldParser(y3_module))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    field1 = parser.ReadFields();

                    int strCount = field1.Length;

                    for (int i = 0; i < strCount; i++)
                    {
                        modules.Add(field1[i]);
                    }
                }
            }

            using (TextFieldParser parser = new TextFieldParser(y3_project))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    field2 = parser.ReadFields();

                    int strCount = field2.Length;

                    for (int i = 0; i < strCount; i++)
                    {
                        projects.Add(field2[i]);
                    }
                }
            }
        }

        public void errorCases()
        {
            Console.Clear();

            Console.WriteLine("Choose a Education / Training:\n0 : Software Engineering ( Year 1 )\n1 : Software Engineering ( Year 2 )\n2 : Software Engineering ( Year 3 )\n3 : Go Back");

            ExtractYear1();

            Console.WriteLine("\nWrong Input! Try again.");
        }
    }
}
