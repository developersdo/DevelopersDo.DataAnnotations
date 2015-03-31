using System.Collections.Generic;
using DevelopersDo.Validator;
using FluentAssertions;
using NUnit.Framework;

namespace DevelopersDo.DataAnnotations.Test
{
    [TestFixture]
    public class CedulaAttributeTest
    {
        [Test]
        [TestCase("001-0068331-7")]
        [TestCase("00100683317")]
        [TestCase(null)]
        [TestCase("")]
        [TestCaseSource("ValidCedulaExceptions")]
        public void TestValidCedulas(string cedula)
        {
            var attr = new CedulaAttribute();
            attr.IsValid(cedula).Should().BeTrue();
        }

        [Test]
        [TestCase("foo")]
        [TestCase("001-2222222-2")]
        [TestCase("00122222222")]
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("\n")]
        [TestCase("\n \t")]
        public void TestInvalidCedulas(string cedula)
        {
            var attr = new CedulaAttribute();
            attr.IsValid(cedula).Should().BeFalse();
            
        }

        private IEnumerable<string> ValidCedulaExceptions()
        {
            return CedulaValidator.ValidExceptions;
        }
    }
}
