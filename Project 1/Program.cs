﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project_1
{
    class Program
    {
        static bool modeCheck = true, inputCheck = true;
        static int UserInput;

        static void Main(string[] args)
        {
            

            GuestMode g_mode = new GuestMode();
            AdminMode a_mode = new AdminMode();

            while (modeCheck)
            {
                Console.Clear();

                Console.WriteLine("Choose an option:\n0 for Guest Mode \n1 for Admin Mode\n2 for Exit");
                do
                {
                    try
                    {
                        UserInput = int.Parse(Console.ReadLine());
                        inputCheck = false;
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Choose an option:\n0 for Guest Mode \n1 for Admin Mode\n2 for Exit");
                        Console.WriteLine("\nWrong Input! Try again.");
                        inputCheck = true;
                    }
                } while (inputCheck);
                

                switch ((ModeSelection)UserInput)
                {
                    case ModeSelection.GuestMode:

                        g_mode.Guest();

                        break;

                    case ModeSelection.AdminMode:

                        a_mode.Admin();

                        break;

                    case ModeSelection.Exit:

                        modeCheck = false;
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
