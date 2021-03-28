using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeachersApp
{
    public abstract class AbstractTeacherApp
    {
        public void Run()
        {
            bool checkmenu = true;

            var methods = new MethodsTeacher();
            var listOfTeachers = methods.Load();

            while (checkmenu)
            {
                methods.DrawMenu();

                string UserOption = Console.ReadLine();

                if (UserOption == "1")
                {
                    var ile = listOfTeachers.Count;
                    methods.addTeacher(ile + 1, listOfTeachers);
                }

                if (UserOption == "2")
                {
                    var option = 2;
                    methods.Update(option, listOfTeachers);
                }

                if (UserOption == "3")
                {

                    methods.ListTeachers(listOfTeachers);

                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                        Console.WriteLine("Press enter to return to main menu.");
                    }
                }

                if (UserOption == "4")
                {
                    methods.DeleteTeacher(listOfTeachers);
                }

                if (UserOption == "5")
                {
                    methods.SortTeachers(listOfTeachers);
                }

                if (UserOption != "1" && UserOption != "2" && UserOption != "3" && UserOption != "Q" && UserOption != "q")
                {
                    methods.DrawMenu();
                }

                if (UserOption == "Q" || UserOption == "q")
                {
                    Console.WriteLine($"{UserOption}  - exit selected");

                    checkmenu = false;

                    Console.WriteLine("Press enter to exit.");
                }
            }
        }

        protected abstract void NewMenu();

    }
}
