using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai06
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai06.csv", "Bai06#csv", DataAccessMethod.Sequential), DeploymentItem("Bai06.csv"), TestMethod]
        public void Average_DataDrivenTest()
        {
            double Sum = Convert.ToDouble(TestContext.DataRow["Sum"]);
            double Count = Convert.ToDouble(TestContext.DataRow["Count"]);
            double expectedResult = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);

            double result = Average(Sum, Count);
            Assert.AreEqual(expectedResult, result);
        }

        public double Average(double Sum, double Count)
        {
            if (Count == 1)
                return Sum;
            else if (Count > 0)
                return Sum / Count;
            else
                return 0;
        }
    }
}
