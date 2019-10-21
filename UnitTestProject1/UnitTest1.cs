using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MojaBazaWiedzy;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EmployeeRoster employeeRoster = new EmployeeRoster();
            employeeRoster.Add("David Jones", 50000);
            employeeRoster.Add("Harris", 75000);
            int expectedSalary = 75000;
            int actualSalary = employeeRoster["Harris"];
            Assert.AreEqual(expectedSalary, actualSalary);
        }
    }
}
