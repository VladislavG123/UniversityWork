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
            Student newStudent = new Student { Name = "studentsName", GroupId = 1, Id = 8 };

            Console.WriteLine(studentService.Insert(newStudent));

            Console.WriteLine("Id| Name | GroupId ");
            var students = studentService.Select();
            foreach (var student in students)
            {
                Console.Write(student.Id + " | ");
                Console.Write(student.Name + " | ");
                Console.WriteLine(student.GroupId);
            }

            if (studentService.Delete(newStudent.Id - 1))
                Console.WriteLine("deleted");

            Console.WriteLine("\nId| Name | GroupId ");
            students = studentService.Select();
            foreach (var student in students)
            {
                Console.Write(student.Id + " | ");
                Console.Write(student.Name + " | ");
                Console.WriteLine(student.GroupId);
            }

            /*  for (int i = 0; i < studentService.Select().Count; i++)
              {
                  if (!(studentService.Select()[i] is null))
                  {
                      Console.WriteLine(i + " Id =" + studentService.Select()[i].Id);
                      if (studentService.Select()[i].Name == "studentsName")
                      {
                          if (studentService.Delete(i))
                              Console.WriteLine("deleted");
                      }
                      continue;
                  }

              }*/
            Console.Read();
        }
    }
}
