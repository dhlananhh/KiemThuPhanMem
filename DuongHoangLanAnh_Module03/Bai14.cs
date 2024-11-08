using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai14
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai14.csv", "Bai14#csv", DataAccessMethod.Sequential), DeploymentItem("Bai14.csv"), TestMethod]
        public void IconFunction_DataDrivenTest()
        {
            int w = Convert.ToInt32(TestContext.DataRow["w"]);
            int h = Convert.ToInt32(TestContext.DataRow["h"]);
            int? expectedX = string.IsNullOrEmpty(TestContext.DataRow["ExpectedX"].ToString()) ? (int?)null : Convert.ToInt32(TestContext.DataRow["ExpectedX"]);
            int? expectedY = string.IsNullOrEmpty(TestContext.DataRow["ExpectedY"].ToString()) ? (int?)null : Convert.ToInt32(TestContext.DataRow["ExpectedY"]);
            int? expectedS = string.IsNullOrEmpty(TestContext.DataRow["ExpectedS"].ToString()) ? (int?)null : Convert.ToInt32(TestContext.DataRow["ExpectedS"]);
            bool expectedError = Convert.ToBoolean(TestContext.DataRow["ExpectedError"]);

            if (expectedError)
            {
                Assert.ThrowsException<ArgumentException>(() => CreateIcon(w, h));
            }
            else
            {
                var (x, y, s) = CreateIcon(w, h);
                Assert.AreEqual(expectedX, x);
                Assert.AreEqual(expectedY, y);
                Assert.AreEqual(expectedS, s);
            }
        }

        public (int x, int y, int s) CreateIcon(int w, int h)
        {
            if (w <= 0 || h <= 0)
            {
                throw new ArgumentException("Invalid input dimensions");
            }

            if (w > h)
            {
                return ((w - h) / 2, 0, h);
            }
            else
            {
                return (0, (h - w) / 2, w);
            }
        }
    }
}