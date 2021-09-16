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
            
            bool check1 = true;
            CSV m_select = new CSV();

            do
            {
                Console.Clear();


                //Brief Description
                Console.WriteLine(Description);

                Console.WriteLine("\nEnter:\n0 : Experience / Job History\n1 : Education / Training\n2 : Skills\n3 : Technological Skills\n4" +
                    " : Contact Details\n5 : Back to Main Menu\n");

                int userInput = int.Parse(Console.ReadLine());

                switch ((GuestSelection)userInput)
                {
                    case GuestSelection.Experience :

                        m_select.FetchExperience();

                        break;

                    case GuestSelection.Education :



                        break;

                    case GuestSelection.Skills :



                        break;

                    case GuestSelection.TechnologicalSkills :



                        break;

                    case GuestSelection.ContactDetails :



                        break;

                    case GuestSelection.GoBack :

                        check1 = false;

                        break;

                }
            } while (check1);

        }
    }
}
