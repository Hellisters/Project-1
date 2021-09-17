using Microsoft.VisualBasic;
using System;

namespace Project_1
{
    class AdminMode
    {
        public static void Admin()
        {
            int userInput = -1;
            bool check1 = true, check2 = true;

            do
            {
                Console.Clear();

                Console.WriteLine("Welcome to Admin Mode.");

                Console.WriteLine("\nChoose an option to make changes:\n0 : Experience / Job History\n1 : Education / Training\n2 : Skills\n3 : Technological Skills\n4" +
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

                            Console.WriteLine("\nChoose an Option:\n0 : Experience / Job History\n1 : Education / Training\n2 : Skills\n3 : Technological Skills\n4" +
                            " : Contact Details\n5 : Back to Main Menu\n");

                            Console.WriteLine("\nWrong Input! Try again.");

                            userInput = int.Parse(Console.ReadLine());

                            check2 = true;
                        }
                    }
                    catch
                    {
                        Console.Clear();

                        Console.WriteLine("\nChoose an Option:\n0 : Experience / Job History\n1 : Education / Training\n2 : Skills\n3 : Technological Skills\n4" +
                        " : Contact Details\n5 : Back to Main Menu\n");

                        Console.WriteLine("\nWrong Input! Try again.");

                        check2 = true;
                    }
                } while (check2);

                switch ((GuestSelection)userInput)
                {
                    case GuestSelection.Experience:

                        
                        check2 = true;
                        userInput = -1;

                        break;


                    case GuestSelection.Education:

                        EducationCSV education_select = new EducationCSV();
                        education_select.GetEducation();
                        check2 = true;
                        userInput = -1;
                        break;

                    case GuestSelection.Skills:

                        EditSkills es = new EditSkills();
                        es.CRUDSkills();
                        check2 = true;
                        userInput = -1;
                        break;

                    case GuestSelection.TechnologicalSkills:

                        TechSkillsCSV techskill = new TechSkillsCSV();
                        techskill.GetTechSkills();
                        check2 = true;
                        userInput = -1;
                        break;

                    case GuestSelection.ContactDetails:

                        ContactCSV con = new ContactCSV();
                        con.GetContact();
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

 