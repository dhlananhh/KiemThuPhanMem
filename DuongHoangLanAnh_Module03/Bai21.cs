using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai21
    {
        public TestContext TestContext { get; set; }
                
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai21.csv", "Bai21#csv", DataAccessMethod.Sequential), DeploymentItem("Bai21.csv"), TestMethod]
        public void HexToDecFunction_DataDrivenTest()
        {
            string hexaString = TestContext.DataRow["hexaString"].ToString();
            int expectedResult = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);
            bool expectedError = Convert.ToBoolean(TestContext.DataRow["ExpectedError"]);

            if (expectedError)
            {
                Assert.ThrowsException<ArgumentException>(
                    () => HexToDec(hexaString)
                );
            }
            else
            {
                int result = HexToDec(hexaString);
                Assert.AreEqual(expectedResult, result);
            }
        }

        public int HexToDec(string hexaString)
        {
            int c;
            int hexnum = 0;
            int nhex = 0;
            int i = 0;

            while (i < hexaString.Length)
            {
                c = hexaString[i++];
                if (c >= '0' && c <= '9')
                {
                    nhex++;
                    hexnum = hexnum * 0x10 + (c - '0');
                }
                else if (c >= 'a' && c <= 'f')
                {
                    nhex++;
                    hexnum = hexnum * 0x10 + (c - 'a' + 0xa);
                }
                else if (c >= 'A' && c <= 'F')
                {
                    nhex++;
                    hexnum = hexnum * 0x10 + (c - 'A' + 0xA);
                }
                else
                {
                    throw new ArgumentException("Invalid hexadecimal character");
                }
            }

            return hexnum;
        }
    }
}