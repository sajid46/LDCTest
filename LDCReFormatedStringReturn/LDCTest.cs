using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LDCReFormatedStringReturn
{
    [TestClass]
    public class LDCTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            LDCStringManipulation ldc = new LDCStringManipulation();
            string InputString = "AAAc91%cWwWkLq$1ci3_848v3d__K";
            //string InputString = "AAca__$_4Cca";

            //Act
            var result = ldc.ReturnString(InputString);

            //Assert
            //Assert.AreEqual("Ac91%WwkLq£i38vdK", result);
            Assert.AreEqual("Aca£C", result);
        }
    }
}
