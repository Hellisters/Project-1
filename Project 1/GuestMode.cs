using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class GuestMode
    {
        private readonly string Description = "\nDescription:\n\n" + "I am Keshav Lolljee and currently studying Software Engineering at the University of " +
                    "Technology, Mauritius. I am a final year student who is open to learning new technologies or developing new skills";

        public void Guest()
        {
            
            CSV m_select = new CSV();

            int userInput = -1;
            bool check1 = true, check2 = true;
            
            do
            {
                Console.Clear();


                //Brief Description
                Console.WriteLine(Description);

                Console.WriteLine("\nEnter:\n0 : Experience / Job History\n1 : Education / Training\n2 : Skills\n3 : Technological Skills\n4" +
                    " : Contact Details\n5 : Back to Main Menu\n");

                do
                {
                    try
                    {
                        userInput = int.Parse(Console.ReadLine());

                        if (userInput >= 0 && userInput <= 5)
                        {
                            check2 = false;
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();

                            //Brief Description
                            Console.WriteLine(Description);

                            Console.WriteLine("\nEnter:\n0 : Experience / Job History\n1 : Education / Training\n2 : Skills\n3 : Technological Skills\n4" +
                            " : Contact Details\n5 : Back to Main Menu\n");

                            Console.WriteLine("\nWrong Input! Try again.");

                            userInput = int.Parse(Console.ReadLine());

                            check2 = true;
                        }
                    }
                    catch
                    {
                        Console.Clear();

                        //Brief Description
                        Console.WriteLine(Description);

                        Console.WriteLine("\nEnter:\n0 : Experience / Job History\n1 : Education / Training\n2 : Skills\n3 : Technological Skills\n4" +
                        " : Contact Details\n5 : Back to Main Menu\n");

                        Console.WriteLine("\nWrong Input! Try again.");

                        check2 = true;
                    }
                } while (check2);

                switch ((GuestSelection)userInput)
                {
                    case GuestSelection.Experience:

                        ExperienceCSV experience_select = new ExperienceCSV();
                        experience_select.GetExperience();
                        check2 = true;
                        userInput = -1;

                        break;


                    case GuestSelection.Education:

                        /*EducationCSV education_select = new EducationCSV();*/
                        /*education_select.GetEducation();*/
                        check2 = true;
                        userInput = -1;
                        break;

                    case GuestSelection.Skills:
                        
                        check2 = true;
                        userInput = -1;
                        break;

                    case GuestSelection.TechnologicalSkills:

                        check2 = true;
                        userInput = -1;
                        break;

                    case GuestSelection.ContactDetails:

                        check2 = true;
                        userInput = -1;
                        break;

                    case GuestSelection.GoBack:

                        check1 = false;
                        userInput = -1;
                        break;

                }
            } while (check1);
        }
    }
}
