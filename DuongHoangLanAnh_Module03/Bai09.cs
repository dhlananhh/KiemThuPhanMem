using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai09
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai09.csv", "Bai09#csv", DataAccessMethod.Sequential), DeploymentItem("Bai09.csv"), TestMethod]
        public void CustomFunction_DataDrivenTest()
        {
            int a = Convert.ToInt32(TestContext.DataRow["a"]);
            int b = Convert.ToInt32(TestContext.DataRow["b"]);
            int x = Convert.ToInt32(TestContext.DataRow["x"]);
            string expectedResult = TestContext.DataRow["ExpectedResult"].ToString();
            bool expectedError = Convert.ToBoolean(TestContext.DataRow["ExpectedError"]);

            if (expectedError)
            {
                Assert.ThrowsException<ArgumentException>(
                    () => CustomFunction(a, b, x),
                    "Invalid range: a should be less than or equal to b"
                );
            }
            else
            {
                string result = CustomFunction(a, b, x);
                Assert.AreEqual(expectedResult, result);
            }
        }

        public string CustomFunction(int a, int b, int x)
        {
            if (a > b)
            {
                throw new ArgumentException("Invalid range: a should be less than or equal to b");
            }
            else if (x < a)
            {
                return a.ToString();
            }
            else if (x > b)
            {
                return b.ToString();
            }
            else
            {
                return x.ToString();
            }
        }
    }
}
