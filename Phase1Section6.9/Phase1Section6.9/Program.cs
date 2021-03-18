using System;

namespace Phase1Section6._9
{
    public class MyPackage
    {
        public void displayText(string text)
        {
            Console.WriteLine(text);
        }

        public void displayDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }
    }
}
