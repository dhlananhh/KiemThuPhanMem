using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai07
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai07.csv", "Bai07#csv", DataAccessMethod.Sequential), DeploymentItem("Bai07.csv"), TestMethod]
        public void DaysInMonth_DataDrivenTest()
        {
            int month = Convert.ToInt32(TestContext.DataRow["Month"]);
            int year = Convert.ToInt32(TestContext.DataRow["Year"]);
            int expectedResult = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            int result = DaysInMonth(month, year);
            Assert.AreEqual(expectedResult, result);
        }

        public int DaysInMonth(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (year % 400 == 0)
                        return 29;
                    else if (year % 100 == 0)
                        return 28;
                    else if (year % 4 == 0)
                        return 29;
                    else
                        return 28;
                default:
                    return 0;
            }
        }
    }
}