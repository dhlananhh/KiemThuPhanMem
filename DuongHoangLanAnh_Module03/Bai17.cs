using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai17
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai17.csv", "Bai17#csv", DataAccessMethod.Sequential), DeploymentItem("Bai17.csv"), TestMethod]
        public void DateValidationFunction_DataDrivenTest()
        {
            int year = Convert.ToInt32(TestContext.DataRow["Year"]);
            int month = Convert.ToInt32(TestContext.DataRow["Month"]);
            int day = Convert.ToInt32(TestContext.DataRow["Day"]);
            bool expectedResult = Convert.ToBoolean(TestContext.DataRow["ExpectedResult"]);

            bool result = IsValidDate(year, month, day);
            Assert.AreEqual(expectedResult, result);
        }

        public bool IsValidDate(int year, int month, int day)
        {
            if (month < 1 || month > 12)
            {
                return false;
            }

            if (day < 1 || day > 30)
            {
                return false;
            }

            return true;
        }
    }
}