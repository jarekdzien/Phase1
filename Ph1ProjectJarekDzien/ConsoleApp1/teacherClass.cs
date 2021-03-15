using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class TeacherClass
    {
  
        public TeacherClass()
        {
          
        }
        public string TeacherId { get; set; }

        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }

        public string TeacherFullName { get { return TeacherName + " " + TeacherSurname; } }

        public void Nauczyciel(string name, string surname)
        {
            Console.WriteLine($"created: {name + " " + surname}");
            Console.WriteLine($"id|{name}|{surname}|whatever else");
            
        }

    }
}
