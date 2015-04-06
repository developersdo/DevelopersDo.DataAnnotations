using FluentAssertions;
using NUnit.Framework;

namespace DevelopersDo.DataAnnotations.Test
{
    [TestFixture]
    public class MSISDNAttributeTest
    {
        [Test]
        [TestCase("8091234567")]
        [TestCase("809-123-4567")]
        [TestCase(null)]
        [TestCase("")]
        public void TestValidMSISDNs(string msisdn)
        {
            var attr = new MSISDNAttribute();
            attr.IsValid(msisdn).Should().BeTrue();
        }

        [Test]
        [TestCase("8691234567")]
        [TestCase("839-123-4567")]
        [TestCase(null)]
        [TestCase("")]
        public void TestValidMSISDNs_WithCustomPrefixes(string msisdn)
        {
            var attr = new MSISDNAttribute
            {
                Prefixes = new[] { "839", "869" }
            };
            attr.IsValid(msisdn).Should().BeTrue();
        }

        [Test]
        [TestCase("foo")]
        [TestCase("0211234567")]
        [TestCase("021-123-4567")]
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("\n")]
        [TestCase("\n \t")]
        public void TestInvalidMSISDNs(string msisdn)
        {
            var attr = new MSISDNAttribute();
            attr.IsValid(msisdn).Should().BeFalse();
        }
    }
}
