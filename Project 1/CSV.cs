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
        private readonly string Description = "\nDescription:\n\n" + "I am Keshav Lolljee and currently studying Software Engineering at the University of " +
                    "Technology, Mauritius. I am a final year student who is open to learning new technologies or developing new skills";
        private List<string> headings = new List<string>();
        private List<string> info = new List<string>();
        private int expChoice = 0;

        public void FetchExperience()
        {
            headings.Clear();
            info.Clear();
            ExperienceHeadingExtraction();
            ExperienceValuesExtraction();
            GetExperience();
        }

        public void ExperienceHeadingExtraction()
        {
            string[] fields;

            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\doxlo\Desktop\CSV_Files\csv_data.csv"))
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
                    }
                }
            }
        }
        
        public void ExperienceValuesExtraction()
        {
            string[] fields;

            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\doxlo\Desktop\CSV_Files\csv_data.csv"))
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
                        if (i > (strCount / 2))
                        {
                            info.Add(fields[i]);
                        }
                    }
                }
            }
        }
        
        public void GetExperience()
        {
            bool checkGetExp = true;

            do
            {
                Console.Clear();

                Console.WriteLine(Description);

                Console.WriteLine("Choose a company:");

                foreach (var elem in headings)
                {
                    Console.WriteLine($"\n{headings.IndexOf(elem)} : {elem}");
                }

                try
                {
                    expChoice = int.Parse(Console.ReadLine());

                    if (expChoice < 0 || expChoice > ((headings.Count) - 1))
                    {
                        Console.Clear();

                        //Brief Description
                        Console.WriteLine(Description);

                        Console.WriteLine("Choose a company:");

                        foreach (var elem in headings)
                        {
                            Console.WriteLine($"\n{headings.IndexOf(elem)} : {elem}");
                        }

                        Console.WriteLine("\nWrong input! Try again.");
                    }
                    else
                    {
                        Console.Clear();

                        //Brief Description
                        Console.WriteLine(Description);

                        Console.WriteLine($"\n{headings[expChoice]}:\n{info[expChoice]}");

                        Console.WriteLine($"\nPress any key to go back...");

                        Console.ReadKey();
                        checkGetExp = false;

                    }

                }
                catch
                {
                    Console.Clear();

                    //Brief Description
                    Console.WriteLine(Description);

                    foreach (var elem in headings)
                    {
                        Console.WriteLine($"\n{headings.IndexOf(elem)} : {elem}");
                    }

                    Console.WriteLine("\nWrong Input! Try again.");

                    checkGetExp = true;
                }                
            } while (checkGetExp);
        }
    }
}
