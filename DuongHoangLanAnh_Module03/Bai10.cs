using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai10
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai10.csv", "Bai10#csv", DataAccessMethod.Sequential), DeploymentItem("Bai10.csv"), TestMethod]
        public void TriangleFunction_DataDrivenTest()
        {
            int a = Convert.ToInt32(TestContext.DataRow["a"]);
            int b = Convert.ToInt32(TestContext.DataRow["b"]);
            int c = Convert.ToInt32(TestContext.DataRow["c"]);
            bool expectedResult = Convert.ToBoolean(TestContext.DataRow["ExpectedResult"]);

            bool result = IsTriangle(a, b, c);
            Assert.AreEqual(expectedResult, result);
        }

        public bool IsTriangle(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return false;
            }
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                return false;
            }
            return true;
        }
    }
}