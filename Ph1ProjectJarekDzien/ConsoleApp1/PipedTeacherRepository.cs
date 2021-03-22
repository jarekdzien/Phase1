using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class PipedTeacherRepository : ITeacherRepository
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
            Console.WriteLine("Listing DB");

            //List<Teacher> listTeachers = new List<Teacher>();

            

                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("ID\t|NAME\t\t|SURNAME|CLASS\t|SECTION");
                Console.WriteLine("-------------------------------------------------");


                //dopisac sortowanie

                //listTeachers.Sort();

                //List<Teacher> SortedList = listTeachers.OrderBy(n => o.OrderDate).ToList();


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
    }
}
