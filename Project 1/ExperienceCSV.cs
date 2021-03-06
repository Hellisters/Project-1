using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class ExperienceCSV
    {
        private string csv_url = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Experience.csv";
        private List<string> headings = new List<string>();
        private List<string> info = new List<string>();
        private int expChoice;
        

        public void GetExperience()
        {
            ExtractExperience();

            bool checkGetExp = true;
            bool loopcheck2 = true;

            do
            {
                Console.Clear();

                Console.WriteLine("Choose a company: \n");

                foreach (var elem in headings)
                {
                    Console.WriteLine($"{headings.IndexOf(elem)} : {elem}");
                }

                Console.WriteLine($"{headings.Count} : Go Back\n");

                do
                {
                    try
                    {
                        expChoice = int.Parse(Console.ReadLine());

                        if (expChoice >= 0 && expChoice <= ((headings.Count) - 1))
                        {
                            Console.Clear();

                            Console.WriteLine($"{headings[expChoice]}:\n{info[expChoice]}");

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

        public void ExtractExperience()
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

                    int strCount = fields.Length;
                    
                    if (strCount == 2)
                    {
                        headings.Add(fields[0]);
                        info.Add(fields[1]);
                    }
                    else
                    {
                        for (int i = 0; i < strCount; i++)
                        {

                            if (i <= 0)
                            {
                                headings.Add(fields[i].ToString());
                                headings.Remove("");
                            }
                            else
                            {
                                info.Add(fields[i].ToString());
                                info.Remove("");
                            }
                        }
                    }
                }
            }
        }
        
        private  void errorCases()
        {
            Console.Clear();

            Console.WriteLine("Choose an Experience / Job History: \n");

            foreach (var elem in headings)
            {
                Console.WriteLine($"{headings.IndexOf(elem)} : {elem}");
            }

            Console.WriteLine($"{headings.Count} : Go Back");

            Console.WriteLine("\nWrong Input! Try again.\n");
        }
    }
}
