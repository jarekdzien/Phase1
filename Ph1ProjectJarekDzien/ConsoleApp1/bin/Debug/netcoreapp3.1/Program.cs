using ConsoleApp1;
using System;
using System.Collections;
using System.Collections.Generic;   
using System.IO;
using TeachersApp;

//jarek_dzien.
//I am not a programmer.
//I'ts my first ever c# app.
//I'ts my first ever OOP app.

namespace aConsoleApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            var app = new TeacherApp();
            app.Run();
        }

    }
}
