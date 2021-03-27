using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class MethodsTeacher : ITeacherRepository
    {
        private const string _TechersFile = "db.txt";
        public List<Teacher> Load()
        {
            var lines = File.ReadAllLines(_TechersFile);
            var teachers = new List<Teacher>();

            foreach (var line in lines)
            {
                var splits = line.Split('|');
                var teacher = new Teacher(splits[0], splits[1], splits[2], splits[3], splits[4]);
                teachers.Add(teacher);
            }
            return teachers;

        }

        public void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("------------- MENU ------------");
            Console.WriteLine("select (1) to add a new teacher account.");
            Console.WriteLine("select (2) to edit teacher's account.");
            Console.WriteLine("select (3) to list all teachers.");
            Console.WriteLine("select (4) to delete teacher account.");
            Console.WriteLine("select (5) to sort teacher account.");
            Console.WriteLine("select (Q) or (q) to EXIT");
        }

        public void Save(List<Teacher> teachers)
        {
            var pipedObjects = new List<String>();
            foreach (var teacher in teachers)
            {
                var pipedTeacherObject = $"{teacher.Id}|{teacher.Name}|{teacher.Surname}|{teacher.AClass}|{teacher.Section}";
                pipedObjects.Add(pipedTeacherObject);
            }
        }

        public void ListTeachers(List<Teacher> teachers)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("ID\t|NAME\t\t|SURNAME|CLASS\t|SECTION");
            Console.WriteLine("-------------------------------------------------");

                foreach (var item in teachers)
                {
                    if (item.Name.Length >= 7)
                    {
                        Console.WriteLine($"{item.Id}.\t|{item.Name}\t|{item.Surname}\t|{item.AClass}\t|{item.Section}");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Id}.\t|{item.Name}\t\t|{item.Surname}\t|{item.AClass}\t|{item.Section}");
                    }
                }
                Console.WriteLine("-------------------------------------------------");
        }

        public void Update(int option, List<Teacher> teachers)
        {
            Console.WriteLine($"Menu -> Option {option} - updating teacher record");
            var repo = new MethodsTeacher();
            repo.ListTeachers(teachers);
            //ListTeachers();

            Console.Write("\n Enter ID: ");
            string id = Console.ReadLine();
            bool found = false;
            bool updated = false;

            foreach (var teacher in teachers)
            {
                if (teacher.Id == id)
                {
                    Console.WriteLine($"Updating : {teacher.Name} {teacher.Surname} ");
                    string OldSurname = $"{teacher.Name} {teacher.Surname}";
                    string TName = teacher.Name;
                    string TSurname = teacher.Surname;

                    Console.Write($"New Name : ");
                    teacher.Name = Console.ReadLine();

                    Console.Write($"New Surname : ");
                    teacher.Surname = Console.ReadLine();

                    if (teacher.Surname == "") { Console.WriteLine("surname stays the same"); teacher.Surname = TSurname; }
                    if (teacher.Name == "") { Console.WriteLine("name stays the same"); teacher.Name = TName; }

                    if (teacher.Surname != "" || teacher.Name != "")
                    {

                        updated = true;
                        Console.WriteLine($"{OldSurname} -> {teacher.Name} {teacher.Surname}");
                    }

                    found = true;
                    break;
                }
            }

            if (found)
            {

                if (updated)
                {
                    Console.WriteLine($"Position {id} updated.");
                    repo.Save(teachers);

                    Console.WriteLine("\n");

                    repo.ListTeachers(teachers);

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
        public void SortTeachers(List<Teacher> teachers)
        {
            var repo = new MethodsTeacher();

            var sorted = new List<Teacher>();

            foreach (var teacher in teachers)
            {
                var inserted = false;
                for (var i = 0; i < sorted.Count; i++)
                {
                    if ((int.Parse(teacher.Id) < int.Parse(sorted[i].Id)))
                    {
                        inserted = true;
                        sorted.Insert(i, teacher);
                        break;
                    }
                }

                if (!inserted) sorted.Add(teacher);
            }

            var sortedByName = new List<Teacher>();

            foreach (var teacher in teachers)
            {
                var inserted = false;
                for (var i = 0; i < sortedByName.Count; i++)
                {
                    if (string.Compare(teacher.Name, sortedByName[i].Name) == -1)
                    {
                        inserted = true;
                        sortedByName.Insert(i, teacher);
                        break;
                    }
                }

                if (!inserted) sortedByName.Add(teacher);
            }


            var sortedBySurname = new List<Teacher>();

            foreach (var teacher in teachers)
            {
                var inserted = false;
                for (var i = 0; i < sortedBySurname.Count; i++)
                {
                    if (string.Compare(teacher.Surname, sortedBySurname[i].Surname) == -1)
                    {
                        inserted = true;
                        sortedBySurname.Insert(i, teacher);
                        break;
                    }
                }

                if (!inserted) sortedBySurname.Add(teacher);
            }


            repo.ListTeachers(teachers);

            Console.WriteLine("How to sort them?");
            Console.WriteLine("1: by ID");
            Console.WriteLine("2: by 1st Name");
            Console.WriteLine("3: by 2nd Name");

            var option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1: repo.ListTeachers(sorted); Console.WriteLine("Sorted by ID"); break;
                case 2: repo.ListTeachers(sortedByName); Console.WriteLine("Sorted by Name"); break;
                case 3: repo.ListTeachers(sortedBySurname); Console.WriteLine("Sorted by Surname"); break;
            }

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Press any key to return to main menu.");
                Console.ReadKey();
            }
        }
        public void DeleteTeacher(List<Teacher> listOfTeachers)
        {
            var repository = new MethodsTeacher();

            Console.Clear();
            Console.WriteLine("Option 4 - removing teachers record.");
            Console.WriteLine("\n");
            repository.ListTeachers(listOfTeachers);
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

                    Console.Write("Are you sure you want to go ahead? (y/n): ");
                    var check = Console.Read();
                    if (check == 'n')
                    {

                        break;
                    }
                    else if (check == 'y')
                    {
                        makingSure = true;
                        listOfTeachers.Remove(teacher);
                    }
                    else
                    {
                        Console.WriteLine("wrong option / skipping. ");
                        makingSure = false;

                    }
                    break;
                }
            }

            if (found)
            {
                if (makingSure)
                {
                    Console.WriteLine($"Position {id} removed.");
                    Console.WriteLine("\n");
                    
                    repository.Save(listOfTeachers);
                    
                    Console.WriteLine("\n");

                    repository.ListTeachers(listOfTeachers);
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

        public void addTeacher(int IdNumber, List<Teacher> listOfTeachers)
        {
            var repository = new MethodsTeacher();

            var id = IdNumber;
            string teacherName = "";
            string teacherSurname = "";
            Console.WriteLine("Option 1 : Adding teacher into the db");

            while (string.IsNullOrEmpty(teacherName) || string.IsNullOrEmpty(teacherSurname))
            {
                Console.Write("Teachers name: ");
                teacherName = Console.ReadLine();
                Console.Write("Teachers surname: ");
                teacherSurname = Console.ReadLine();

                //Console.Write("Class: ");
                //string _teacherClass = Console.ReadLine();

                //Console.Write("Section: ");
                //string teacherSection = Console.ReadLine();

                if (string.IsNullOrEmpty(teacherName) || string.IsNullOrEmpty(teacherSurname))
                {
                    Console.WriteLine("Menu -> Option 1 and adding teacher into the db");
                    Console.WriteLine("Either name or surname is empty");
                }
                else
                {
                    listOfTeachers.Add(new Teacher(id.ToString(), teacherName, teacherSurname, "Class", "Section"));
                    
                    repository.Save(listOfTeachers);
                    repository.ListTeachers(listOfTeachers);
                }
            }

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Press enter to return to main menu.");
            }
        }

    }
}
