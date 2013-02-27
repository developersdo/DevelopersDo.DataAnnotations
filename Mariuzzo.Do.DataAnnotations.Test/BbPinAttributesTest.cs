using System;
using Mariuzzo.DO.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mariuzzo.Do.DataAnnotations.Test
{
    [TestClass]
    public class BbPinAttributesTest
    {
        [TestMethod]
        public void TestValidBbPins()
        {
            var attr = new BbPinAttribute();
            Assert.IsTrue(attr.IsValid("223CEC0A"));
            Assert.IsTrue(attr.IsValid(null));
            Assert.IsTrue(attr.IsValid(String.Empty));
        }

        [TestMethod]
        public void TestInvalidBbPins()
        {
            var attr = new BbPinAttribute();
            Assert.IsFalse(attr.IsValid("223CEC0"));
            Assert.IsFalse(attr.IsValid("223CEC0AA"));
            Assert.IsFalse(attr.IsValid(" "));
            Assert.IsFalse(attr.IsValid("\t"));
            Assert.IsFalse(attr.IsValid("\n"));
            Assert.IsFalse(attr.IsValid("\n \t"));
        }
    }
}
