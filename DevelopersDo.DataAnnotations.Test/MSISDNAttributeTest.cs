using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevelopersDo.DataAnnotations.Test
{
    [TestClass]
    public class MSISDNAttributeTest
    {
        [TestMethod]
        public void TestValidMSISDNs()
        {
            var attr = new MSISDNAttribute();
            Assert.IsTrue(attr.IsValid("8091234567"));
            Assert.IsTrue(attr.IsValid("809-123-4567"));
            Assert.IsTrue(attr.IsValid(null));
            Assert.IsTrue(attr.IsValid(String.Empty));
        }

        [TestMethod]
        public void TestInvalidMSISDNs()
        {
            var attr = new MSISDNAttribute();
            Assert.IsFalse(attr.IsValid("foo"));
            Assert.IsFalse(attr.IsValid("0211234567"));
            Assert.IsFalse(attr.IsValid("021-123-4567"));
            Assert.IsFalse(attr.IsValid(" "));
            Assert.IsFalse(attr.IsValid("\t"));
            Assert.IsFalse(attr.IsValid("\n"));
            Assert.IsFalse(attr.IsValid("\n \t"));
        }
    }
}
