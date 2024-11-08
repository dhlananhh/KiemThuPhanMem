using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongHoangLanAnh_Module03
{
    [TestClass]
    public class Bai18
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\Bai18.csv", "Bai18#csv", DataAccessMethod.Sequential), DeploymentItem("Bai18.csv"), TestMethod]
        public void EmailValidationFunction_DataDrivenTest()
        {
            string email = TestContext.DataRow["Email"].ToString();
            bool expectedResult = Convert.ToBoolean(TestContext.DataRow["ExpectedResult"]);

            bool result = IsValidEmail(email);
            Assert.AreEqual(expectedResult, result);
        }

        public bool IsValidEmail(string email)
        {
            if (!email.Contains("@"))
            {
                return false;
            }

            if (email.Contains(".."))
            {
                return false;
            }

            if (!email.Contains("."))
            {
                return false;
            }

            if (email.Contains("@.") || email.Contains(".@"))
            {
                return false;
            }

            return true;
        }
    }
}