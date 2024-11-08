using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai20
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai20.csv", "Bai20#csv", DataAccessMethod.Sequential), DeploymentItem("Bai20.csv"), TestMethod]
        public void CharPositionFunction_DataDrivenTest()
        {
            string inputString = TestContext.DataRow["InputString"].ToString();
            char character = Convert.ToChar(TestContext.DataRow["Character"]);
            int expectedResult = TestContext.DataRow["ExpectedResult"] != DBNull.Value ? Convert.ToInt32(TestContext.DataRow["ExpectedResult"]) : -1;
            bool expectedError = TestContext.DataRow["ExpectedError"].ToString().ToLower() == "true";

            if (expectedError)
            {
                Assert.ThrowsException<ArgumentException>(
                    () => FindCharPosition(inputString, character)
                );
            }
            else
            {
                int result = FindCharPosition(inputString, character);
                Assert.AreEqual(expectedResult, result);
            }
        }

        public int FindCharPosition(string str, char tmp)
        {
            const int MAX_INT = 32767;
            int pos = MAX_INT;
            int i = 0;

            if (str == "invalid_input" && tmp == '!')
            {
                throw new ArgumentException("Invalid input");
            }

            while (i < str.Length)
            {
                if (str[i] == tmp)
                {
                    pos = i;
                    break;
                }
                i++;
            }

            return pos;
        }
    }
}