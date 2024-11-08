using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai02
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai02.csv", "Bai02#csv", DataAccessMethod.Sequential), DeploymentItem("Bai02.csv"), TestMethod]
        public void FunctionToTest_DataDrivenTest()
        {
            int X = Convert.ToInt32(TestContext.DataRow["X"]);
            int Y = Convert.ToInt32(TestContext.DataRow["Y"]);
            int Z = Convert.ToInt32(TestContext.DataRow["Z"]);
            string expected = TestContext.DataRow["ExpectedResult"].ToString();

            string result = FunctionToTest(X, Y, Z);
            Assert.AreEqual(expected, result);
        }

        public string FunctionToTest(int X, int Y, int Z)
        {
            if (X == 1 || X == 2)
            {
                return "A";
            }
            else
            {
                if (Y <= 10)
                {
                    return "B";
                }
                else
                {
                    if (Z < 5)
                    {
                        return "C";
                    }
                    else
                    {
                        return "D";
                    }
                }
            }
        }
    }
}
