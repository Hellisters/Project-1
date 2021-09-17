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
        private static readonly string Description = "\nDescription:\n\n" + "I am Keshav Lolljee and currently studying Software Engineering at the University of " +
                    "Technology, Mauritius. I am a final year student who is open to learning new technologies or developing new skills";

        public static void Guest()
        {
            int userInput = -1;
            bool check1 = true, check2 = true;
            
            do
            {
                Console.Clear();


                //Brief Description
                Console.WriteLine(Description);

                Console.WriteLine("\nChoose an Option:\n0 : Experience / Job History\n1 : Education / Training\n2 : Skills\n3 : Technological Skills\n4" +
                    " : Contact Details\n5 : Back to Main Menu\n");

                do
                {
                    try
                    {
                        userInput = int.Parse(Console.ReadLine());

                        var choice = (ModeOptions)userInput;

                        if ( choice == ModeOptions.Experience || choice == ModeOptions.Education || 
                            choice == ModeOptions.ContactDetails || choice == ModeOptions.BackMainMenu || 
                            choice == ModeOptions.TechnologicalSkills || choice == ModeOptions.Skills)
                        {
                            check2 = false;
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();

                            //Brief Description
                            Console.WriteLine(Description);

                            Console.WriteLine("\nChoose an Option:\n0 : Experience / Job History\n1 : Education / Training\n2 : Skills\n3 : Technological Skills\n4" +
                            " : Contact Details\n5 : Back to Main Menu\n");

                            Console.WriteLine("\nWrong Input! Try again.\n");

                            userInput = int.Parse(Console.ReadLine());

                            check2 = true;
                        }
                    }
                    catch
                    {
                        Console.Clear();

                        //Brief Description
                        Console.WriteLine(Description);

                        Console.WriteLine("\nChoose an Option:\n0 : Experience / Job History\n1 : Education / Training\n2 : Skills\n3 : Technological Skills\n4" +
                        " : Contact Details\n5 : Back to Main Menu\n");

                        Console.WriteLine("\nWrong Input! Try again.\n");

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

                        EducationCSV education_select = new EducationCSV();
                        education_select.GetEducation();
                        check2 = true;
                        userInput = -1;
                        break;

                    case GuestSelection.Skills:

                        SkillsCSV skill = new SkillsCSV();
                        skill.GetSkills();
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
