using Xunit;
using Plivo.Exception;

namespace Plivo.NetCore.Test.Resources
{
    public class TestExceptions : BaseTestCase
    {
        [Fact]
        public void TestThrowsPlivoValidationException()
        {
            var ex =
                Assert.Throws<PlivoValidationException>(
                    () => Api.Application.Create(
                        ""));
            Assert.Equal(ex.Message, "appName is mandatory, can not be null or empty");
        }

        [Fact]
        public void TestThrowsPlivoException()
        {
            var ex =
                Assert.Throws<PlivoValidationException>(
                    () => Api.Application.Create(
                        "", "http://www.com", null));
            Assert.Equal(ex.Message, "appName is mandatory, can not be null or empty");
        }

        [Fact]
        public void TestLimitException()
        {
            var ex =
                Assert.Throws<PlivoValidationException>(
                    () => Api.Call.List(limit: 112));
            Assert.Equal(ex.Message, "limit:112 is out of range [0,20]");
        }
    }
}