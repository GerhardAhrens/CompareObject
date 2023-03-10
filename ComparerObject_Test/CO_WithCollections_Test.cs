using CompareObj;

namespace EasyPrototypingTest
{

    [TestClass]
    public class CO_WithCollections_Test
    {
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

        [TestMethod]
        public void ComparerObjectWithTwoObjectAndList3_EqualsFalse()
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

            Department dept1 = new Department();
            dept1.DepartmentId = 1;
            dept1.DepartmentName = "Development";
            List<Department> deptList1 = new List<Department>();
            deptList1.Add(dept1);
            p1.Department = deptList1;

            Department dept2 = new Department();
            dept2.DepartmentId = 2;
            dept2.DepartmentName = "Development";
            List<Department> deptList2 = new List<Department>();
            deptList2.Add(dept2);
            p2.Department = deptList2;

            List<CompareResult> compareResult = CompareObject.GetDifferences(p1, p2);
            Assert.IsNotNull(compareResult);
            Assert.IsTrue(compareResult.Count == 1);
        }
    }
}