using System;
using System.Collections.Generic;
using System.Text;

namespace Phase1Section5._10
{
    public class BasicGradeCard
    {
        protected int totalMarks;

        public BasicGradeCard()
        {
            totalMarks = 0;
        }

        public virtual int getTotalMarks()
        {
            return totalMarks;
        }
    }
}
