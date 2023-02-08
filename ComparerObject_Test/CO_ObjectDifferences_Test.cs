using CompareObj;

namespace EasyPrototypingTest
{

    [TestClass]
    public class CO_ObjectDifferences_Test
    {
        [TestMethod]
        public void ComparerObjectWithNullObject_EqualsTrue()
        {
            Person p1 = null;

            Person p2 = null;

            List<CompareResult> compareResult = CompareObject.GetDifferences(p1, p2);
            Assert.IsNotNull(compareResult);
            Assert.IsTrue(compareResult.Count == 0);
        }

        [TestMethod]
        public void ComparerObjectWithOneObject_EqualsFalse()
        {
            Person p1 = new Person();
            p1.PersonId = 12;
            p1.Name = "Gerhard";
            p1.Age = 58;
            p1.MeetingDate = null;

            Person p2 = null;

            List<CompareResult> compareResult = CompareObject.GetDifferences(p1, p2);
            Assert.IsNotNull(compareResult);
            Assert.IsTrue(compareResult.Count == 3);
        }

        [TestMethod]
        public void ObjectEqualsTrue()
        {
            Person p1 = new Person();
            p1.PersonId = 12;
            p1.Name = "Gerhard";
            p1.Age = 58;
            p1.MeetingDate = null;

            Person p2 = new Person();
            p2.PersonId = 12;
            p2.Name = "Gerhard";
            p2.Age = 58;
            p2.MeetingDate = null;

            List<CompareResult> compareResult = CompareObject.GetDifferences(p1,p2);
            Assert.IsNotNull(compareResult);
            Assert.IsTrue(compareResult.Count == 0);
        }

        [TestMethod]
        public void ObjectEqualsTrue_IgnorProperty()
        {
            Person p1 = new Person();
            p1.PersonId = 12;
            p1.Name = "Gerhard";
            p1.Age = 58;
            p1.MeetingDate = null;

            Person p2 = new Person();
            p2.PersonId = 12;
            p2.Name = "Gerhard";
            p2.Age = 58;
            p2.MeetingDate = null;

            List<CompareResult> compareResult = CompareObject.GetDifferences(p1, p2,"Age");
            Assert.IsNotNull(compareResult);
            Assert.IsTrue(compareResult.Count == 0);
        }

        [TestMethod]
        public void ObjectEqualsFalse()
        {
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

            List<CompareResult> compareResult = CompareObject.GetDifferences(CurrentPerson, oldPerson);
            Assert.IsNotNull(compareResult);
            Assert.IsTrue(compareResult.Count == 3);
        }

        [TestMethod]
        public void ObjectEqualsFalse_IgnorProperty1()
        {
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

            List<CompareResult> compareResult = CompareObject.GetDifferences(CurrentPerson, oldPerson,"Age");
            Assert.IsNotNull(compareResult);
            Assert.IsTrue(compareResult.Count == 2);
        }

        [TestMethod]
        public void ObjectEqualsFalse_IgnorProperty2()
        {
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

            string[] ignorProperty = new IgnorWords().IgnorPropertiesAsArray;
            List<CompareResult> compareResult = CompareObject.GetDifferences(CurrentPerson, oldPerson, ignorProperty);
            Assert.IsNotNull(compareResult);
            Assert.IsTrue(compareResult.Count == 2);
        }

        [TestMethod]
        public void ObjectEqualsFalse_IgnorProperty3()
        {
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

            string[] ignorProperty = new IgnorWords().IgnorPropertiesAsArray;
            List<CompareResult> compareResult = CompareObject.GetDifferences(CurrentPerson, oldPerson, null);
            Assert.IsNotNull(compareResult);
            Assert.IsTrue(compareResult.Count == 3);
        }

        [TestMethod]
        public void ObjectWithTwoObjectAndList1_EqualsTrue()
        {
            Person CurrentPerson = new Person();
            CurrentPerson.PersonId = 12;
            CurrentPerson.Name = "Gerhard";
            CurrentPerson.Age = 58;
            CurrentPerson.MeetingDate = null;

            Person oldPerson = new Person();
            oldPerson.PersonId = 12;
            oldPerson.Name = "Gerhard";
            oldPerson.Age = 58;
            oldPerson.MeetingDate = null;

            Department dept = new Department();
            dept.DepartmentId = 1;
            dept.DepartmentName = "Development";
            List<Department> deptList = new List<Department>();
            deptList.Add(dept);

            CurrentPerson.Department = deptList;
            oldPerson.Department = deptList;

            List<CompareResult> compareResult = CompareObject.GetDifferences(CurrentPerson, oldPerson);
            Assert.IsNotNull(compareResult);
            Assert.IsTrue(compareResult.Count == 0);
        }

        [TestMethod]
        public void ComparerObjectWithTwoObjectAndList2_EqualsFalse()
        {
            Person p1 = new Person();
            p1.PersonId = 12;
            p1.Name = "Gerhard Ahrens";
            p1.Age = 58;
            p1.MeetingDate = null;

            Person p2 = new Person();
            p2.PersonId = 12;
            p2.Name = "Gerhard";
            p2.Age = 58;
            p2.MeetingDate = null;

            Department dept = new Department();
            dept.DepartmentId = 1;
            dept.DepartmentName = "Development";
            List<Department> deptList = new List<Department>();
            deptList.Add(dept);

            p1.Department = deptList;
            p2.Department = null;

            List<CompareResult> compareResult = CompareObject.GetDifferences(p1, p2);
            Assert.IsNotNull(compareResult);
            Assert.IsTrue(compareResult.Count == 2);
        }
    }
}