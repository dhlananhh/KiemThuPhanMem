using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai15
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai15.csv", "Bai15#csv", DataAccessMethod.Sequential), DeploymentItem("Bai15.csv"), TestMethod]
        public void LeapYearFunction_DataDrivenTest()
        {
            int year = Convert.ToInt32(TestContext.DataRow["Year"]);
            bool expectedResult = Convert.ToBoolean(TestContext.DataRow["ExpectedResult"]);
            bool expectedError = Convert.ToBoolean(TestContext.DataRow["ExpectedError"]);

            if (expectedError)
            {
                Assert.ThrowsException<ArgumentException>(() => IsLeapYear(year));
            }
            else
            {
                bool result = IsLeapYear(year);
                Assert.AreEqual(expectedResult, result);
            }
        }

        public bool IsLeapYear(int year)
        {
            if (year > 10000 || year < 1000)
            {
                throw new ArgumentException("Year is out of valid range");
            }

            if (year % 100 == 0)
            {
                if (year % 400 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (year % 4 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
