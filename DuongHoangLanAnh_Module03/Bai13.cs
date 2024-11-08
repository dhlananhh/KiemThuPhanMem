using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai13
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai13.csv", "Bai13#csv", DataAccessMethod.Sequential), DeploymentItem("Bai13.csv"), TestMethod]
        public void RectangleFunction_DataDrivenTest()
        {
            int x1 = Convert.ToInt32(TestContext.DataRow["x1"]);
            int y1 = Convert.ToInt32(TestContext.DataRow["y1"]);
            int x2 = Convert.ToInt32(TestContext.DataRow["x2"]);
            int y2 = Convert.ToInt32(TestContext.DataRow["y2"]);
            int x = Convert.ToInt32(TestContext.DataRow["x"]);
            int y = Convert.ToInt32(TestContext.DataRow["y"]);
            string expectedResult = TestContext.DataRow["ExpectedResult"].ToString();
            bool expectedError = Convert.ToBoolean(TestContext.DataRow["ExpectedError"]);

            if (expectedError)
            {
                Assert.ThrowsException<ArgumentException>(() => IsPointInRectangle(x1, y1, x2, y2, x, y));
            }
            else
            {
                bool result = IsPointInRectangle(x1, y1, x2, y2, x, y);
                Assert.AreEqual(Convert.ToBoolean(expectedResult), result);
            }
        }

        public bool IsPointInRectangle(int x1, int y1, int x2, int y2, int x, int y)
        {
            if (x1 > x2 || y1 > y2)
            {
                throw new ArgumentException("Invalid rectangle coordinates");
            }
            if (x < x1 || x > x2 || y < y1 || y > y2)
            {
                return false;
            }
            return true;
        }
    }
}
