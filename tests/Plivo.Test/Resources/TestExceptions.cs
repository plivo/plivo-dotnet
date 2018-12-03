using NUnit.Framework;
using Plivo.Exception;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestExceptions : BaseTestCase
    {
        [Test]
        public void TestThrowsPlivoValidationException()
        {
            var ex =
                Assert.Throws<PlivoValidationException>(
                    () => Api.Application.Create(
                        appName: ""));
            Assert.That(ex.Message, Is.EqualTo("appName is mandatory, can not be null or empty"));
        }

        [Test]
        public void TestThrowsPlivoException()
        {
            var ex =
                Assert.Throws<PlivoValidationException>(
                    () => Api.Application.Create(
                        appName: "", answerUrl: "http://www.com", answerMethod: null));
            Assert.That(ex.Message, Is.EqualTo("appName is mandatory, can not be null or empty"));
        }

        [Test]
        public void TestLimitException()
        {
            var ex =
                Assert.Throws<PlivoValidationException>(
                    code: () => Api.Call.List(limit: 112));
            Assert.That(ex.Message, Is.EqualTo("limit:112 is out of range [0,20]"));
        }
    }
}