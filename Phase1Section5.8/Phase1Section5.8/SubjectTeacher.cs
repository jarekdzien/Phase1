using System;
using System.Collections.Generic;
using System.Text;

namespace Phase1Section5._8
{
    public class SubjectTeacher : Teacher
    {
        private Subject whichSubject;

        public Subject WhichSubject
        {
            get { return whichSubject; }
            set { whichSubject = value; }
        }
    }
}
