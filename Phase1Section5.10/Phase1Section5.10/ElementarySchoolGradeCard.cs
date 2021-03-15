using System;
using System.Collections.Generic;
using System.Text;

namespace Phase1Section5._10
{
    public class ElementarySchoolGradeCard : BasicGradeCard
    {
        private int maths = 0;
        private int english = 0;
        private int secondLanguage = 0;
        private int socialScience = 0;

        public int Maths
        {
            get { return maths; }
            set { maths = value; }
        }

        public int English
        {
            get { return english; }
            set { english = value; }
        }

        public int SecondLanguage
        {
            get { return secondLanguage; }
            set { secondLanguage = value; }
        }

        public int SocialScience
        {
            get { return socialScience; }
            set { socialScience = value; }
        }

        public virtual int getTotalMarks()
        {
            this.totalMarks = maths + english + socialScience + secondLanguage;
            return totalMarks;
        }
    }
}
