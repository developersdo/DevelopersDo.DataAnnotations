using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mariuzzo.DO.DataAnnotations;

namespace Mariuzzo.DO.DataAnnotations.Test
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
            Assert.IsTrue(attr.IsValid(" "));
            Assert.IsTrue(attr.IsValid("\t"));
            Assert.IsTrue(attr.IsValid("\n"));
        }

        [TestMethod]
        public void TestInvalidMSISDNs()
        {
            var attr = new MSISDNAttribute();
            Assert.IsFalse(attr.IsValid("foo"));
            Assert.IsFalse(attr.IsValid("0211234567"));
            Assert.IsFalse(attr.IsValid("021-123-4567"));
        }
    }
}
