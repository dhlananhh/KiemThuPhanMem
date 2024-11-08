using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai04
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai04.csv", "Bai04#csv", DataAccessMethod.Sequential), DeploymentItem("Bai04.csv"), TestMethod]
        public void Max_DataDrivenTest()
        {
            int a = Convert.ToInt32(TestContext.DataRow["a"]);
            int b = Convert.ToInt32(TestContext.DataRow["b"]);
            int c = Convert.ToInt32(TestContext.DataRow["c"]);
            int expectedMax = Convert.ToInt32(TestContext.DataRow["ExpectedMax"]);
            double expectedMean = Convert.ToDouble(TestContext.DataRow["ExpectedMean"]);

            int result = Max(a, b, c);
            double mean = (a + b + c) / 3.0;
            Assert.AreEqual(expectedMax, result);
            Assert.AreEqual(expectedMean, mean, 0.01);
        }

        public int Max(int a, int b, int c)
        {
            int max = 0;
            if (a > 0 && b > 0 && c > 0)
                max = a;
            else
                return 0;
            if (max < b)
                max = b;
            if (max < c)
                max = c;
            return max;
        }
    }
}