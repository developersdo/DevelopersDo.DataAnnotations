using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mariuzzo.DO.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mariuzzo.Do.DataAnnotations.Test
{
    [TestClass]
    public class RNCAttributeTests
    {
        [TestMethod]
        public void TestValidRNCs()
        {
            var attr = new RNCAttribute();

            Assert.IsTrue(attr.IsValid("1-01-02779-7"));
            Assert.IsTrue(attr.IsValid("101027797"));
            Assert.IsTrue(attr.IsValid(null));
            Assert.IsTrue(attr.IsValid(String.Empty));
        }

        [TestMethod]
        public void TestInvalidRNCs()
        {
            var attr = new RNCAttribute();

            Assert.IsFalse(attr.IsValid("foo"));
            Assert.IsFalse(attr.IsValid("1-01-02777-7"));
            Assert.IsFalse(attr.IsValid("101027777"));
            Assert.IsFalse(attr.IsValid(" "));
            Assert.IsFalse(attr.IsValid("\t"));
            Assert.IsFalse(attr.IsValid("\n"));
            Assert.IsFalse(attr.IsValid("\n \t"));
        }
    }
}
