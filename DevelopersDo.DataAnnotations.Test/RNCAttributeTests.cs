using FluentAssertions;
using NUnit.Framework;

namespace DevelopersDo.DataAnnotations.Test
{
    [TestFixture]
    public class RNCAttributeTests
    {
        [Test]
        [TestCase("1-01-02779-7")]
        [TestCase("101027797")]
        [TestCase(null)]
        [TestCase("")]
        public void TestValidRNCs(string rnc)
        {
            var attr = new RNCAttribute();
            attr.IsValid(rnc).Should().BeTrue();
        }

        [Test]
        [TestCase("foo")]
        [TestCase("1-01-02777-7")]
        [TestCase("101027777")]
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("\n")]
        [TestCase("\n \t")]
        public void TestInvalidRNCs(string rnc)
        {
            var attr = new RNCAttribute();
            attr.IsValid(rnc).Should().BeFalse();
        }
    }
}
