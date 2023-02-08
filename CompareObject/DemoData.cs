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

    public class Person
    {
        public int PersonId { get; set; }

        public Status Status { get; set; } = Status.InAktiv;

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime? MeetingDate { get; set; }

        public List<Department> Department { get; set; }

        public Dictionary<int, string> Roles { get; set; }
    }

    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }

    public class IgnorWords
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

    public enum Status : int
    {
        None = 0,
        Aktiv,
        InAktiv
    }
}