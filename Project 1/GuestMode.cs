﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class GuestMode
    {
        private readonly string Description = "Description:\n\n" + "I am Keshav Lolljee and currently studying Software Engineering at the University of " +
                    "Technology, Mauritius. I am a final year student who is open to learning new technologies or developing new skills";
        

        public void Guest()
        {
            int userInput = -1;
            bool check1 = true, check2 = true;
            CSV m_select = new CSV();

            do
            {
                Console.Clear();

                //Brief Description
                Console.WriteLine(Description);

                Console.WriteLine("\nEnter:\n0 : Experience / Job History\n1 : Education / Training\n2 : Skills\n3 : Technological Skills\n4" +
                    " : Contact Details\n5 : Back to Main Menu\n");
                while (check2)
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
                }
                


                switch ((GuestSelection)userInput)
                {
                    case GuestSelection.Experience :

                        CSV csv = new CSV();
                        csv.GetExperience();
                        check2 = true;
                        userInput = -1;

                        break;

                    case GuestSelection.Education :

                        Console.WriteLine("Change successfull");
                        Console.ReadKey();

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
