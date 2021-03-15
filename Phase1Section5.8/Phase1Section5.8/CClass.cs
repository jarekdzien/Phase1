using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Phase1Section5._8
{
    public class CClass
    {
        private string name;
        private ClassTeacher whichTeacher;
        private List<SubjectTeacher> subjectTeachers;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ClassTeacher WhichTeacher
        {
            get { return whichTeacher; }
            set { whichTeacher = value; }
        }

        public List<SubjectTeacher> SubjectTeachers
        {
            get { return subjectTeachers; }
            set { subjectTeachers = value; }
        }


    }
}
