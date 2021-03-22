using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface ITeacherRepository
    {
        List<Teacher> Load();
        void Save(List<Teacher> teachers);
    }
}
