using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai11
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai11.csv", "Bai11#csv", DataAccessMethod.Sequential), DeploymentItem("Bai11.csv"), TestMethod]
        public void ImageAlignment_DataDrivenTest()
        {
            int w = Convert.ToInt32(TestContext.DataRow["w"]);
            int h = Convert.ToInt32(TestContext.DataRow["h"]);
            int ww = Convert.ToInt32(TestContext.DataRow["ww"]);
            int wh = Convert.ToInt32(TestContext.DataRow["wh"]);
            int? expectedX = string.IsNullOrEmpty(TestContext.DataRow["ExpectedX"].ToString()) ? (int?)null : Convert.ToInt32(TestContext.DataRow["ExpectedX"]);
            int? expectedY = string.IsNullOrEmpty(TestContext.DataRow["ExpectedY"].ToString()) ? (int?)null : Convert.ToInt32(TestContext.DataRow["ExpectedY"]);
            bool expectedError = Convert.ToBoolean(TestContext.DataRow["ExpectedError"]);

            try
            {
                var (x, y) = AlignImage(w, h, ww, wh);
                Assert.IsFalse(expectedError, "Expected an error but none was thrown.");
                Assert.AreEqual(expectedX, x);
                Assert.AreEqual(expectedY, y);
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(expectedError, "Expected no error but one was thrown.");
            }
        }

        public (int x, int y) AlignImage(int w, int h, int ww, int wh)
        {
            if (w <= 0 || h <= 0 || ww <= 0 || wh <= 0)
            {
                throw new ArgumentException("Invalid input dimensions.");
            }

            int x, y;

            if (w > ww && h > wh)
            {
                x = 0;
                y = 0;
            }
            else if (w > ww && h <= wh)
            {
                x = 0;
                y = (wh - h) / 2;
            }
            else if (w <= ww && h > wh)
            {
                x = (ww - w) / 2;
                y = 0;
            }
            else
            {
                x = (ww - w) / 2;
                y = (wh - h) / 2;
            }

            return (x, y);
        }
    }
}