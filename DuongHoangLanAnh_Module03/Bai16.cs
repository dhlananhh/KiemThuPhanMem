using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai16
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai16.csv", "Bai16#csv", DataAccessMethod.Sequential), DeploymentItem("Bai16.csv"), TestMethod]
        public void PasswordFunction_DataDrivenTest()
        {
            string password = TestContext.DataRow["Password"].ToString();
            bool expectedResult = Convert.ToBoolean(TestContext.DataRow["ExpectedResult"]);
            bool expectedError = Convert.ToBoolean(TestContext.DataRow["ExpectedError"]);

            bool result = IsPasswordValid(password);
            Assert.AreEqual(expectedResult, result);
        }

        public bool IsPasswordValid(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}