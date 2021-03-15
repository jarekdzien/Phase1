using System;

namespace Phase1Section4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            //runApp();
            runApp2();
        }

        public static void runApp2()
        {
            int[][] a = new int[2][];
            a[0] = new int[] { 1, 2, 3 };
            a[1] = new int[] { 19 };

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }


            int[,] mda = new int[,] { { 1, 2 },{ 3, 4 } };
            //Console.WriteLine(mda.Length);
            //Console.WriteLine(mda.Rank);

            foreach (var item in mda)
            {
                Console.WriteLine(item);
            }
            int[] array = new int[3] { 0, 1, 2 };
            //Console.WriteLine(array.Length);
            
        }
            public static void runApp()
        {
            string[] students3A, students3B;

            students3A = new string[10] { "Rahul", "Sheela", "Mukesh", "Afzal", "Ramesh", "Geeta", "Jason", "Robert", "Gopal", "Meera" };
            students3B = new string[10] { "Pinky", "Rakesh", "Rafi", "Mumtaz", "Derek", "Sukhwinder", "Gopi", "Tulsi", "Chandrika", "Ann" };

            string[] subjects = new string[6];
            subjects[0] = "Physics";
            subjects[1] = "Chemistry";
            subjects[2] = "Biology";
            subjects[3] = "Calculus";
            subjects[4] = "Computer Science";
            subjects[5] = "Algebra";

            int[] marks = new int[6];
            marks[0] = 67;
            marks[1] = 90;
            marks[2] = 80;
            marks[3] = 55;
            marks[4] = 71;
            marks[5] = 92;

            Console.WriteLine("Students of Class 3A:");
            foreach (string s in students3A)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine("");

            Console.WriteLine("Students of Class 3B:");
            foreach (string s in students3B)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine("");

            Console.WriteLine("Marks of Kamal:");
            int total = 0;
            for (int i = 0; i < 6; i++)
            {
                total += marks[i];
                Console.WriteLine(subjects[i] + " = " + marks[i]);
            }
            Console.WriteLine("TOTAL = " + total + "/600 = " + (total * 100 / 600) + " percent");
        }
    }
}
