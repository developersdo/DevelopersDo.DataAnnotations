using FluentAssertions;
using NUnit.Framework;

namespace DevelopersDo.DataAnnotations.Test
{
    [TestFixture]
    public class BbPinAttributesTest
    {
        [Test]
        [TestCase("223CEC0A")]
        [TestCase(null)]
        [TestCase("")]
        public void TestValidBbPins(string bbPin)
        {
            var attr = new BbPinAttribute();
            attr.IsValid(bbPin).Should().BeTrue();
        }

        [Test]
        [TestCase("223CEC0")]
        [TestCase("223CEC0AA")]
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("\n")]
        [TestCase("\n \t")]
        public void TestInvalidBbPins(string bbPin)
        {
            var attr = new BbPinAttribute();
            attr.IsValid(bbPin).Should().BeFalse();
        }
    }
}
