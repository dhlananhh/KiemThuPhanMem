using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai05
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai05.csv", "Bai05#csv", DataAccessMethod.Sequential), DeploymentItem("Bai05.csv"), TestMethod]
        public void Triangle_DataDrivenTest()
        {
            int a = Convert.ToInt32(TestContext.DataRow["a"]);
            int b = Convert.ToInt32(TestContext.DataRow["b"]);
            int c = Convert.ToInt32(TestContext.DataRow["c"]);
            string expected = TestContext.DataRow["ExpectedResult"].ToString();

            string result = Triangle(a, b, c);
            Assert.AreEqual(expected, result);
        }

        public string Triangle(int a, int b, int c)
        {
            int match = 0;
            if (a == b)
                match = match + 1;
            if (a == c)
                match = match + 2;
            if (b == c)
                match = match + 3;
            if (match == 0)
            {
                if ((a + b) <= c)
                    return "Not a Triangle";
                else if ((b + c) <= a)
                    return "Not a Triangle";
                else if ((a + c) <= b)
                    return "Not a Triangle";
                else
                    return "Triangle is Scalene";
            }
            else if (match == 1)
            {
                if ((a + c) <= b)
                    return "Not a Triangle";
                else
                    return "Triangle is Isosceles";
            }
            else if (match == 2)
            {
                if ((a + c) <= b)
                    return "Not a Triangle";
                else
                    return "Triangle is Isosceles";
            }
            else if (match == 3)
            {
                if ((b + c) <= a)
                    return "Not a Triangle";
                else
                    return "Triangle is Isosceles";
            }
            else
                return "Triangle is Equilateral";
        }
    }
}
