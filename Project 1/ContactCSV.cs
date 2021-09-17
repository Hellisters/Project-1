using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class ContactCSV
    {
        private string csv_url = @"C:\Users\doxlo\Desktop\Ceridian\CSV_Files\Contact.csv";
        private List<string> contact = new List<string>();
        private List<string> displayCon = new List<string>();


        public void GetContact()
        {
            ExtractContact();

            Console.Clear();

            Console.WriteLine("Contact Details: \n");

            foreach (var elem in contact)
            {
                Console.WriteLine($"{elem}: {displayCon[contact.IndexOf(elem)]}");
            }

            Console.WriteLine($"\nPress any key to go back...");

            Console.ReadKey();
        }

        public void ExtractContact()
        {
            contact.Clear();

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
                        if (i <= 0)
                        {
                            contact.Add(fields[i]);
                            contact.Remove("");
                        }
                        else
                        {
                            displayCon.Add(fields[i]);
                            displayCon.Remove("");
                        }
                    }
                }
            }
        }
    }
}
