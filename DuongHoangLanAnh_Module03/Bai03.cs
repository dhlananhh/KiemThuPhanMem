using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai03
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai03.csv", "Bai03#csv", DataAccessMethod.Sequential), DeploymentItem("Bai03.csv"), TestMethod]
        public void MaxAndMean_DataDrivenTest()
        {
            int A = Convert.ToInt32(TestContext.DataRow["A"]);
            int B = Convert.ToInt32(TestContext.DataRow["B"]);
            int C = Convert.ToInt32(TestContext.DataRow["C"]);
            int expectedMax = Convert.ToInt32(TestContext.DataRow["ExpectedMax"]);
            double expectedMean = Convert.ToDouble(TestContext.DataRow["ExpectedMean"]);

            double mean;
            int max = MaxAndMean(A, B, C, out mean);
            Assert.AreEqual(expectedMax, max);
            Assert.AreEqual(expectedMean, mean, 0.01);
        }

        public int MaxAndMean(int A, int B, int C, out double Mean)
        {
            Mean = (A + B + C) / 3.0;
            int Maximum;
            if (A > B)
            {
                if (A > C)
                {
                    Maximum = A;
                }
                else
                {
                    Maximum = C;
                }
            }
            else
            {
                if (B > C)
                {
                    Maximum = B;
                }
                else
                {
                    Maximum = C;
                }
            }
            return Maximum;
        }
    }
}