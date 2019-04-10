using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataAccess;
using UniversityApp.Models;

namespace UniversityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();

            Console.WriteLine("Id| Name | GroupId ");
            foreach (var student in studentService.Select())
            {
                Console.Write(student.Id + " | ");
                Console.Write(student.Name + " | ");
                Console.WriteLine(student.GroupId);
            }

            Console.Read();
        }
    }
}
