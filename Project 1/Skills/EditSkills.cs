using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class EditSkills : SkillsCRUD
    {
        private static bool check1 = true, check2 = true;
        private static int userInput;
        public void CRUDSkills()
        {    

            do
            {
                Console.Clear();

                Console.WriteLine("Choose an operation:\n0 : Add\n1 : Delete\n2 : Update\n3 : Exit\n");

                DisplaySkills();

                do
                {
                    try
                    {
                        userInput = int.Parse(Console.ReadLine());

                        var choice = (CRUD)userInput;

                        if (choice == CRUD.Add || choice == CRUD.Delete ||
                            choice == CRUD.Update || choice == CRUD.Exit)

                            if (userInput >= 0 && userInput <= 3)
                        {
                            check2 = false;
                            Console.Clear();
                        }
                        else
                        {
                            errorCaseEditSkills();

                            userInput = int.Parse(Console.ReadLine());

                            check2 = true;
                        }
                    }
                    catch
                    {
                        errorCaseEditSkills();
                        check2 = true;
                    }
                } while (check2);

                switch ((CRUD)userInput)
                {
                    case CRUD.Add:

                        AddSkills();
                        check2 = true;
                        userInput = -1;

                        Console.Clear();

                        Console.WriteLine("Skill added successfully!");
                        Console.WriteLine($"\nPress any key to go back...");

                        Console.ReadKey();

                        break;


                    case CRUD.Delete:

                        DeleteSkills();
                        check2 = true;
                        userInput = -1;

                        Console.Clear();

                        Console.WriteLine("Skill deleted successfully!");
                        Console.WriteLine($"\nPress any key to go back...");

                        Console.ReadKey();

                        break;

                    case CRUD.Update:

                        EditSkills es = new EditSkills();
                        es.CRUDSkills();
                        check2 = true;
                        userInput = -1;
                        break;

                    case CRUD.Exit:

                        check1 = false;
                        userInput = -1;
                        break;
                }
            } while (check1);
        }

        private void errorCaseEditSkills()
        {
            Console.Clear();

            Console.WriteLine("Choose an operation:\n0 : Add\n1 : Delete\n2 : Update\n3 : Exit\n");

            Console.WriteLine("Current list of skills:\n");

            foreach (var elem in ReturnList())
            {
                Console.WriteLine($"{ReturnList().IndexOf(elem)} : {elem}");
            }

            Console.WriteLine("\nWrong Input! Try again.\n");
        }
    }
}
