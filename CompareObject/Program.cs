//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Lifeprojects.de">
//     Class: Program
//     Copyright © Lifeprojects.de 2023
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>developer@lifeprojects.de</email>
// <date>03.02.2023 14:00:02</date>
//
// <summary>
// Konsolen Applikation zum demonstrieren einer Klasse die dazu dient zwei
// Objekte des gleichen Types zu vergleichen
// </summary>
//-----------------------------------------------------------------------

namespace CompareObj
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            Person CurrentPerson = new Person();
            CurrentPerson.PersonId = 13;
            CurrentPerson.Name = "Gerhard";
            CurrentPerson.Age = 60;
            CurrentPerson.MeetingDate = null;

            Person oldPerson = new Person();
            oldPerson.PersonId = 12;
            oldPerson.Name = "Gerhard Ahrens";
            oldPerson.Age = 58;
            oldPerson.MeetingDate = null;

            Department dept = new Department();
            dept.DepartmentId = 1;
            dept.DepartmentName = "Development";
            List<Department> deptList = new List<Department>();
            deptList.Add(dept);

            CurrentPerson.Department = deptList;
            oldPerson.Department = null;

            string[] ignorProperty = new IgnorWords().IgnorPropertiesAsArray;
            List<CompareResult> compareResult = CompareObject.GetDifferences(CurrentPerson, oldPerson, ignorProperty);

            Console.WriteLine($"\t");
            foreach (CompareResult item in compareResult)
            {
                var fullname = item.FullName;
                Console.WriteLine($"\t{fullname}");
            }

            Console.ReadKey();
        }

        public class Person
        {
            public int PersonId { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }

            public DateTime? MeetingDate { get; set; }

            public List<Department> Department { get; set; }
        }

        public class Department
        {
            public int DepartmentId { get; set; }

            public string DepartmentName { get; set; }
        }

        private class IgnorWords
        {
            public IgnorWords()
            {
                if (this.IgnorProperties == null)
                {
                    this.IgnorProperties = new List<string>();
                    this.IgnorProperties.Add("Age");
                }
            }

            public List<string> IgnorProperties { get; private set; }

            public string[] IgnorPropertiesAsArray { get { return IgnorProperties.ToArray(); } }
        }
    }
}