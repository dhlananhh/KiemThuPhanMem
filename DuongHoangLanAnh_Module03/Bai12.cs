using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai12
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai12.csv", "Bai12#csv", DataAccessMethod.Sequential), DeploymentItem("Bai12.csv"), TestMethod]
        public void PricingFunction_DataDrivenTest()
        {
            int total = Convert.ToInt32(TestContext.DataRow["Total"]);
            int p1 = Convert.ToInt32(TestContext.DataRow["p1"]);
            int p2 = Convert.ToInt32(TestContext.DataRow["p2"]);
            int p3 = Convert.ToInt32(TestContext.DataRow["p3"]);
            bool expectedError = Convert.ToBoolean(TestContext.DataRow["ExpectedError"]);
            int expectedResult = expectedError ? 0 : Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            if (expectedError)
            {
                Assert.ThrowsException<ArgumentException>(
                    () => CalculatePricing(total, p1, p2, p3),
                    "Invalid input"
                );
            }
            else
            {
                int result = CalculatePricing(total, p1, p2, p3);
                Assert.AreEqual(expectedResult, result);
            }
        }

        public int CalculatePricing(int total, int p1, int p2, int p3)
        {
            if (total < 0 || p1 < 0 || p2 < 0 || p3 < 0)
            {
                throw new ArgumentException("Invalid input");
            }

            if (total <= 100)
            {
                return total * p1;
            }
            else if (total <= 150)
            {
                return 100 * p1 + (total - 100) * p2;
            }
            else
            {
                return 100 * p1 + 50 * p2 + (total - 150) * p3;
            }
        }
    }
}