using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class CSV
    {
        private readonly string Description = "Description:\n\n" + "I am Keshav Lolljee and currently studying Software Engineering at the University of " +
                    "Technology, Mauritius. I am a final year student who is open to learning new technologies or developing new skills\n";
        private string csv_url = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\csv_data.csv";
        private List<string> headings = new List<string>();
        private List<string> info = new List<string>();
        private int expChoice;
        

        public void GetExperience()
        {
            headings.Clear();
            info.Clear();

            string[] fields;

            using (TextFieldParser parser = new TextFieldParser(csv_url))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                { 
                    //Process row
                    fields = parser.ReadFields();

                    int strCount = fields.Length - 1;

                    for (int i = 0; i < fields.Length; i++)
                    {
                        if (i <= (strCount / 2))
                        {
                            headings.Add(fields[i].ToString());
                        }
                        if (i > (strCount / 2))
                        {
                            info.Add(fields[i]);
                        }
                    }
                }
            }
            headings.Remove("");


            bool checkGetExp = true;
            bool loopcheck2 = true;

            while (checkGetExp)
            {
                Console.Clear();

                Console.WriteLine(Description);

                Console.WriteLine("Choose a company: \n");

                foreach (var elem in headings)
                {
                    Console.WriteLine($"{headings.IndexOf(elem)} : {elem}");
                }

                Console.WriteLine($"{headings.Count} : Go Back");

                while (loopcheck2)
                {
                    try
                    {
                        expChoice = int.Parse(Console.ReadLine());

                        if (expChoice >= 0 && expChoice <= ((headings.Count) - 1))
                        {
                            Console.Clear();

                            //Brief Description
                            Console.WriteLine(Description);

                            Console.WriteLine($"{headings[expChoice]}:\n{info[expChoice]}");

                            Console.WriteLine($"\nPress any key to go back...");

                            loopcheck2 = false;
                            checkGetExp = false;

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
                            Console.Clear();

                            //Brief Description
                            Console.WriteLine(Description);


                            Console.WriteLine("Choose a company: \n");
                            foreach (var elem in headings)
                            {
                                Console.WriteLine($"{headings.IndexOf(elem)} : {elem}");
                            }

                            Console.WriteLine($"{headings.Count} : Go Back");

                            Console.WriteLine("\nWrong Input! Try again.");

                            loopcheck2 = true;
                        }
                    }
                    catch
                    {
                        loopcheck2 = true;
                    }
                }
            }
        }
        

        /*public void ExperienceHeadingExtraction()
        {
            
        }

        public void ExperienceValuesExtraction()
        {
            
        }*/
    }
}
