using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.PhoneNumber;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestPhoneNumber : BaseTestCase
    {
        [Fact]
        public void TestPhoneNumberList()
        {
            var data = new Dictionary<string, object>()
            {
                {"country_iso", "IN"},
                {"limit", 12}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/phoneNumberListResponse.json"
                );
            Setup<ListResponse<PhoneNumber>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumber.List("IN", limit: 12)));

            AssertRequest(request);
        }

        [Fact]
        public void TestPhoneNumberListUsdAccountHasNoInrFields()
        {
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/phoneNumberListResponse.json"
                );
            Setup<ListResponse<PhoneNumber>>(200, response);

            var numbers = Api.PhoneNumber.List("IN", limit: 12);

            Assert.Equal("0.80000", numbers.Objects[0].MonthlyRentalRate);
            Assert.Null(numbers.Objects[0].SetupRateInr);
            Assert.Null(numbers.Objects[0].MonthlyRentalRateInr);
            Assert.Null(numbers.Objects[0].SmsRateInr);
            Assert.Null(numbers.Objects[0].MmsRateInr);
            Assert.Null(numbers.Objects[0].VoiceRateInr);
        }

        [Fact]
        public void TestPhoneNumberListInrAccount()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"country_iso", "US"},
                        {"limit", 2}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/phoneNumberListInrResponse.json"
                );
            Setup<ListResponse<PhoneNumber>>(200, response);

            var numbers = Api.PhoneNumber.List("US", limit: 2);

            Assert.Empty(ComparisonUtilities.Compare(response, numbers));
            Assert.Equal(2, numbers.Objects.Count);
            Assert.Equal("0.00000", numbers.Objects[0].SetupRateInr);
            Assert.Equal("66.40000", numbers.Objects[0].MonthlyRentalRateInr);
            Assert.Equal("0.66400", numbers.Objects[0].SmsRateInr);
            Assert.Equal("1.49400", numbers.Objects[0].MmsRateInr);
            Assert.Equal("0.41500", numbers.Objects[0].VoiceRateInr);
            Assert.Equal("83.00000", numbers.Objects[1].SetupRateInr);
            // MMS disabled: neither mms_rate nor mms_rate_inr is sent.
            Assert.Null(numbers.Objects[1].MmsRate);
            Assert.Null(numbers.Objects[1].MmsRateInr);
            AssertRequest(request);
        }

        [Fact]
        public void TestPhoneNumberBuy()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"app_id", "123"}
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/phoneNumberCreateResponse.json"
                );
            Setup<PhoneNumberBuyResponse>(
                201,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumber.Buy(id, "123")));

            AssertRequest(request);
        }

        [Fact]
        public void TestPhoneNumberBuyWithComplianceApplicationId()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"app_id", "123"},
                {"compliance_application_id", "compAppId123"}
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/phoneNumberCreateResponse.json"
                );
            Setup<PhoneNumberBuyResponse>(
                201,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumber.Buy(id, "123", complianceApplicationId: "compAppId123")));

            AssertRequest(request);
        }
    }
}