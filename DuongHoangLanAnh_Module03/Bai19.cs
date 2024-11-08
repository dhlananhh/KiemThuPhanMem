using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai19
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai19.csv", "Bai19#csv", DataAccessMethod.Sequential), DeploymentItem("Bai19.csv"), TestMethod]
        public void BMICheckFunction_DataDrivenTest()
        {
            int height = Convert.ToInt32(TestContext.DataRow["Height"]);
            int weight = Convert.ToInt32(TestContext.DataRow["Weight"]);
            int expectedResult = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            int result = CheckBMI(height, weight);
            Assert.AreEqual(expectedResult, result);
        }

        public int CheckBMI(int height, int weight)
        {
            if (height <= 0)
            {
                return -1;
            }

            if (weight <= 0)
            {
                return -1;
            }

            double heightInMeters = height / 100.0;
            double bmi = weight / (heightInMeters * heightInMeters);

            if (bmi < 18)
            {
                return 2; // Thin
            }
            else if (bmi > 20)
            {
                return 1; // Fat
            }
            else
            {
                return 0; // Normal
            }
        }
    }
}
