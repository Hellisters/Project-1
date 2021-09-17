using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project_1
{
    class Program
    {
        public delegate void GoToFunction();

        static bool modeCheck = true, inputCheck = true;
        static int UserInput;

        static void Main(string[] args)
        {

            GoToFunction gtf;

            do
            {
                Console.Clear();

                Console.WriteLine("Choose an option:\n0 for Guest Mode \n1 for Admin Mode\n2 for Exit\n");

                do
                {
                    try
                    {
                        UserInput = int.Parse(Console.ReadLine());

                        if (UserInput >= 0 && UserInput <=2)
                        {
                            inputCheck = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Choose an option:\n0 for Guest Mode \n1 for Admin Mode\n2 for Exit");
                            Console.WriteLine("\nWrong Input! Try again.\n");
                            inputCheck = true;
                        }
                        
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Choose an option:\n0 for Guest Mode \n1 for Admin Mode\n2 for Exit");
                        Console.WriteLine("\nWrong Input! Try again.\n");
                        inputCheck = true;
                    }
                } while (inputCheck);

                switch ((ModeSelection)UserInput)
                {
                    case ModeSelection.GuestMode:

                        gtf = new GoToFunction(GuestMode.Guest);
                        gtf();

                        break;

                    case ModeSelection.AdminMode:

                        gtf = new GoToFunction(AdminMode.Admin);
                        gtf();

                        break;

                    case ModeSelection.Exit:

                        modeCheck = false;
                        Environment.Exit(0);
                        break;
                }
            } while (modeCheck);
        } 
    }
}
