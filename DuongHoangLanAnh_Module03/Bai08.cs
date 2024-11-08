using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai08
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai08.csv", "Bai08#csv", DataAccessMethod.Sequential), DeploymentItem("Bai08.csv"), TestMethod]
        public void QuadraticEquation_DataDrivenTest()
        {
            int a = Convert.ToInt32(TestContext.DataRow["a"]);
            int b = Convert.ToInt32(TestContext.DataRow["b"]);
            int c = Convert.ToInt32(TestContext.DataRow["c"]);
            string expectedResult = TestContext.DataRow["ExpectedResult"].ToString();

            string result = SolveQuadraticEquation(a, b, c);
            Assert.AreEqual(expectedResult, result);
        }

        public string SolveQuadraticEquation(int a, int b, int c)
        {
            if (a == 0)
            {
                return "error";
            }

            int delta = b * b - 4 * a * c;

            if (delta < 0)
            {
                return "no results";
            }
            else if (delta == 0)
            {
                double x = -b / (2.0 * a);
                return x.ToString();
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                return $"2 solutions: x1 = {x1}, x2 = {x2}";
            }
        }
    }
}