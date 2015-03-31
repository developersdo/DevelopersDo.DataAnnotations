using System;
using System.Linq;
using Mariuzzo.DO.DataAnnotations;
using Mariuzzo.DO.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mariuzzo.Do.DataAnnotations.Test
{
    [TestClass]
    public class CedulaAttributeTest
    {
        [TestMethod]
        public void TestValidCedulas()
        {
            var attr = new CedulaAttribute();
            Assert.IsTrue(attr.IsValid("001-0068331-7"));
            Assert.IsTrue(attr.IsValid("00100683317"));
            Assert.IsTrue(attr.IsValid(null));
            Assert.IsTrue(attr.IsValid(String.Empty));
        }

        [TestMethod]
        public void TestInvalidCedulas()
        {
            var attr = new CedulaAttribute();
            Assert.IsFalse(attr.IsValid("foo"));
            Assert.IsFalse(attr.IsValid("001-2222222-2"));
            Assert.IsFalse(attr.IsValid("00122222222"));
            Assert.IsFalse(attr.IsValid(" "));
            Assert.IsFalse(attr.IsValid("\t"));
            Assert.IsFalse(attr.IsValid("\n"));
            Assert.IsFalse(attr.IsValid("\n \t"));
        }

        [TestMethod]
        public void TestShouldBeValidForCedulasExceptions()
        {
            var attr = new CedulaAttribute();
            var cedulasExceptions = CedulaValidator.ValidExceptions;
            Assert.IsFalse(cedulasExceptions.Any(c => !attr.IsValid(c)));
        }
    }
}
