using ConsoleApp1;
using System;
using System.Collections;
using System.Collections.Generic;   
using System.IO;


namespace aConsoleApp
{
    class Program
    {
        static int Add(int first, int second)
        {
            int result = first + second;
            return result;
        }

        static void PrintMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;

        }
        private static void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("------------- MENU ------------");
            Console.WriteLine("select (1) to add a new teacher account.");
            Console.WriteLine("select (2) to edit teacher's account.");
            Console.WriteLine("select (3) to list all teachers.");
            Console.WriteLine("select (4) to delete teacher account.");
            Console.WriteLine("select (Q) or (q) to EXIT");
        }

        public static void ListTeachers()
        {
            //Console.Write($"Menu -> Option 3 - ");   
            Console.WriteLine("Listing DB");

            List<Teacher> listTeachers = new List<Teacher>();
            //var ListT = new List<Teacher>();

            try {
                var fileName = "db.txt";
                var lines = File.ReadAllLines(fileName);

                foreach (var line in lines)
                {
                    //var splits = line.Split("|");
                    //listTeachers.Add(new Teacher(splits[0], splits[1], splits[2], splits[3], splits[4]));
                    var T = new Teacher(line);
                    listTeachers.Add(T);
                }
                
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("ID\t|NAME\t\t|SURNAME|CLASS\t|SECTION");
                Console.WriteLine("-------------------------------------------------");

                foreach (var item in listTeachers)
                {
                    if (item.Name.Length >= 7) { Console.WriteLine($"{item.Id}.\t|{item.Name}\t|{item.Surname}\t|{item.AClass}\t|{item.Section}"); 
                    } 
                    else 
                    { 
                        Console.WriteLine($"{item.Id}.\t|{item.Name}\t\t|{item.Surname}\t|{item.AClass}\t|{item.Section}");
                    }
                }
                Console.WriteLine("-------------------------------------------------");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void UpdateTeacher(int option, List<Teacher> teachers)
        {
            Console.Clear();
            Console.WriteLine($"Menu -> Option {option} - updating teacher record");    
            ListTeachers();

            Console.Write("\n Enter ID: ");
            var id = Console.ReadLine();
            var found = false;
            var OldSurname = "";
            var TName = "";
            var TSurname = "";

            var updated = false;
            foreach (var teacher in teachers)
            {

                if (teacher.Id == id)
                {
                    Console.WriteLine($"Updating : {teacher.Name} {teacher.Surname} ");
                    OldSurname = $"{teacher.Name} {teacher.Surname}";
                    TName = teacher.Name;
                    TSurname = teacher.Surname;
                    Console.Write($"New Name : ");
                    teacher.Name = Console.ReadLine(); 
                    Console.Write($"New Surname : ");
                    teacher.Surname = Console.ReadLine();

                    if (teacher.Surname == "") { Console.WriteLine("surname stays the same"); teacher.Surname = TSurname; }
                    if (teacher.Name == "")    { Console.WriteLine("name stays the same");    teacher.Name = TName; }

                    if (teacher.Surname != "" || teacher.Name != "") {

                        updated = true;
                        Console.WriteLine($"{OldSurname} -> {teacher.Name} {teacher.Surname}");
                    }
                    
                    found = true;
                    break;
                }
            }

            if (found)
            {

                if (updated) { 
                    Console.WriteLine($"Position {id} updated.");
                    saveFile(teachers);
                    Console.WriteLine("\n");
                    ListTeachers();
                }
                else
                {
                    Console.WriteLine($"Position {id} not updated.");
                }
            }
            else
            {
                Console.WriteLine($"{id} not found.");
            }
        }

        static void saveFile(List<Teacher> listOfTeachers)
        {
            var ile = listOfTeachers.Count;
            var fileName = "db.txt";
            var lastID = "";

            using (TextWriter tw = new StreamWriter(fileName))

                try
                {
                    foreach (var item in listOfTeachers)
                    {
                        tw.WriteLine($"{item.Id}|{item.Name}|{item.Surname}|{item.AClass}|{item.Section}");
                        lastID = item.Surname;
                    }

                    Console.WriteLine("db saved ->  press enter");

                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
        }

        static void addTeacher(int IdNumber, List<Teacher> listOfTeachers)
        {
            var id = IdNumber;
            string teacherName = "";
            string teacherSurname = "";
            string teacherClass = "";
            string teacherSection = "";

            Console.WriteLine("Menu -> Option 1 and adding teacher into the db");

            while (string.IsNullOrEmpty(teacherName) || string.IsNullOrEmpty(teacherSurname))
            {
                Console.Write("Teachers name: ");
                teacherName = Console.ReadLine();
                Console.Write("Teachers surname: ");
                teacherSurname = Console.ReadLine();

                Console.Write("Class: ");
                teacherClass = Console.ReadLine();

                Console.Write("Section: ");
                teacherSection = Console.ReadLine();


                if (string.IsNullOrEmpty(teacherName) || string.IsNullOrEmpty(teacherSurname))
                {
                    Console.Clear();
                    Console.WriteLine("Menu -> Option 1 and adding teacher into the db");
                    Console.WriteLine("Either name or surname is empty");
                }
                else
                {
                    listOfTeachers.Add(new Teacher(id.ToString(), teacherName, teacherSurname, teacherClass, teacherSection));
                    saveFile(listOfTeachers);
                    ListTeachers();
                }
            }

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("Press enter to return to main menu.");
            }
        }

        private static List<Teacher> loadList()
        {
            var teachers = new List<Teacher>();
            var lines = File.ReadAllLines("db.txt");

            foreach (var line in lines)
            {
                var teacher = new Teacher(line);
                teachers.Add(teacher);
            }

            return teachers;

        }

        private static void Main(string[] args)
        {

            var checkmenu = true;
            string UserOption = "0";

            DrawMenu();
            
            while (checkmenu)
            {
                var listOfTeachers = loadList(); 
                
                UserOption = Console.ReadLine();
 
                if (UserOption == "1")
                {
                    Console.Clear();
                   
                    var ile = listOfTeachers.Count;

                    addTeacher(ile+1, listOfTeachers);
                    
                    Console.Clear();
                    DrawMenu();

                }

                if (UserOption == "2")
                {
                    var option = 2;

                    UpdateTeacher(option, listOfTeachers);
                }

                if (UserOption == "3")
                {
                    Console.Clear();
                    ListTeachers();

                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                       
                        Console.Clear();
                        Console.WriteLine("Press enter to return to main menu.");
                    }
                    
                    DrawMenu();
                }

                if (UserOption == "4")
                {
                    //add options - call function do say what option selected?

                    DeleteTeacher(listOfTeachers);
                }

                if (UserOption != "1" && UserOption != "2" && UserOption != "3" && UserOption != "Q" && UserOption != "q")
                {
                    Console.Clear();
                    DrawMenu();
                }

                if (UserOption == "Q" || UserOption == "q")
                {
                    Console.WriteLine($"{UserOption}  - exit selected");
                    checkmenu = false;
                 
                    Console.WriteLine("Press enter to exit.");

                    //var X = Console.ReadKey();

                }
            }
        }

        private static void DeleteTeacher(List<Teacher> listOfTeachers)
        {
            Console.Clear();
            Console.WriteLine("Menu -> Option 4 - removing teachers record.");
            Console.WriteLine("\n");
            ListTeachers();
            Console.WriteLine("\n");

            Console.Write("Enter id to be removed (press enter to skip): ");
            var id = Console.ReadLine();
            var found = false;
            var makingSure = false;
            
            foreach (var teacher in listOfTeachers)
            {

                if (teacher.Id == id)
                {
                    found = true;

                    Console.WriteLine($"Removing: {teacher.Name} {teacher.Surname} ");
                    
                    Console.Write("Are you sure you want to go ahead? (y/n): " );
                    var check = Console.Read();
                    if (check == 'n')
                    {
                        
                        break;
                    }
                    else if (check == 'y') {
                        makingSure = true;
                        listOfTeachers.Remove(teacher);
                    }
                    else {
                        Console.WriteLine("wrong option / skipping. ");
                        makingSure = false;

                    }

                    break;
                }
            }

            if (found)
            {
                if (makingSure) { 
                Console.WriteLine($"Position {id} removed.");
                Console.WriteLine("\n");
                saveFile(listOfTeachers);
                Console.WriteLine("\n");
                
                ListTeachers();
                }
                else
                {
                    Console.WriteLine("Nothing removed.");
                }
               
                
            }
            else
            {
                Console.WriteLine($"{id} not found.");
            }

            Console.WriteLine("Press enter to return to main menu.");


            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("Press enter to return to main menu.");
            }


        }
    }
}
