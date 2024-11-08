using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai01
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai01.csv", "Bai01#csv", DataAccessMethod.Sequential), DeploymentItem("Bai01.csv"), TestMethod]
        public void getPositionOf2Cir_DataDrivenTest()
        {
            int distance = Convert.ToInt32(TestContext.DataRow["distance"]);
            int firstRadius = Convert.ToInt32(TestContext.DataRow["firstRadius"]);
            int secRadius = Convert.ToInt32(TestContext.DataRow["secRadius"]);
            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            int result = getPositionOf2Cir(distance, firstRadius, secRadius);
            Assert.AreEqual(expected, result);
        }

        public int getPositionOf2Cir(int distance, int firstRadius, int secRadius)
        {
            if (distance == 0)
            {
                if (firstRadius == secRadius)
                    return 1;
                else
                    return 1;
            }
            else if (firstRadius < secRadius)
                return 0;
            else if (distance > 0)
                return 2;
            else
                return 3;
        }
    }
}