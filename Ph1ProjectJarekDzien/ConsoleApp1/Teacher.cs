using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Teacher 
    {
        //public string TeacherrId { get; private set; }
        //public string TeacherrName { get; private set; }
        //public string TeacherrSurname { get; private set; }

        private string id;
        private string name;
        private string surname;
        private string section;
        private string aclass;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        
        public string AClass
        {
            get { return aclass; }
            set { aclass = value; }
        }
        public string Section
        {
            get { return section; }
            set { section = value; }
        }

        public Teacher(string id, string name, string surname, string aclass, string section)
        {
            //Console.WriteLine("init");
            Id = id;
            Name = name;
            Surname = surname;
            AClass = aclass;
            Section = section;

        }

        public Teacher(string line)
        {
            var fields = line.Split("|");
            Id = fields[0];
            Name = fields[1];
            Surname = fields[2];
            AClass = fields[3];
            Section = fields[4];
        }
    }
}
