using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.RentedNumber;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestNumber : BaseTestCase
    {
        [Fact]
        public void TestRentedNumberList()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 10}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Number/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/numberListResponse.json"
                );
            Setup<ListResponse<RentedNumber>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Number.List(limit: 10)));

            AssertRequest(request);
        }

        [Fact]
        public void TestRentedNumberGet()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Number/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/numberGetResponse.json"
                );
            Setup<RentedNumber>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Number.Get(id)));

            AssertRequest(request);
        }

        [Fact]
        public void TestRentedNumberGetUsdAccountHasNoInrFields()
        {
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/numberGetResponse.json"
                );
            Setup<RentedNumber>(200, response);

            var number = Api.Number.Get("abcabcabc");

            Assert.Equal("0.80000", number.MonthlyRentalRate);
            Assert.Null(number.MonthlyRentalRateInr);
            Assert.Null(number.SmsRateInr);
            Assert.Null(number.MmsRateInr);
            Assert.Null(number.VoiceRateInr);
        }

        [Fact]
        public void TestRentedNumberGetInrAccount()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Number/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/numberGetInrResponse.json"
                );
            Setup<RentedNumber>(200, response);

            var number = Api.Number.Get(id);

            Assert.Empty(ComparisonUtilities.Compare(response, number));
            Assert.Equal("0.80000", number.MonthlyRentalRate);
            Assert.Equal("66.40000", number.MonthlyRentalRateInr);
            Assert.Equal("0.00250", number.SmsRate);
            Assert.Equal("0.20750", number.SmsRateInr);
            Assert.Equal("0.00400", number.MmsRate);
            Assert.Equal("0.33200", number.MmsRateInr);
            Assert.Equal("0.00850", number.VoiceRate);
            Assert.Equal("0.70550", number.VoiceRateInr);
            AssertRequest(request);
        }

        [Fact]
        public void TestRentedNumberListInrAccount()
        {
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/numberListInrResponse.json"
                );
            Setup<ListResponse<RentedNumber>>(200, response);

            var numbers = Api.Number.List(limit: 10);

            Assert.Empty(ComparisonUtilities.Compare(response, numbers));
            Assert.Equal(2, numbers.Objects.Count);
            Assert.Equal("66.40000", numbers.Objects[0].MonthlyRentalRateInr);
            Assert.Equal("0.20750", numbers.Objects[0].SmsRateInr);
            Assert.Equal("0.33200", numbers.Objects[0].MmsRateInr);
            Assert.Equal("0.70550", numbers.Objects[0].VoiceRateInr);
            // BYOC number: no rental ("-1" sentinel) and no MMS, so neither INR sibling.
            Assert.Null(numbers.Objects[1].MonthlyRentalRateInr);
            Assert.Null(numbers.Objects[1].MmsRateInr);
            Assert.Equal("0.08300", numbers.Objects[1].SmsRateInr);
            Assert.Equal("0.41500", numbers.Objects[1].VoiceRateInr);
        }

        [Fact]
        public void TestRentedNumberAdd()
        {
            var data = new Dictionary<string, object>()
            {
                {"numbers", "+919999999999,+919898989898"},
                {"carrier", "carry me"},
                {"region", "somewhere here"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Number/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/numberCreateResponse.json"
                );
            Setup<UpdateResponse<RentedNumber>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Number.AddNumber(new List<string>() {"+919999999999", "+919898989898"}, "carry me",
                        "somewhere here")));

            AssertRequest(request);
        }

        [Fact]
        public void TestNumberUpdate()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"alias", "alalaalalala"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Number/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/endpointUpdateResponse.json"
                );
            Setup<UpdateResponse<RentedNumber>>(
                202,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Number.Update(id, alias: "alalaalalala")));
            AssertRequest(request);
        }

        [Fact]
        public void TestNumberDelete()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Number/" + id + "/",
                    "");

            var response = "";
            Setup<UpdateResponse<RentedNumber>>(
                204,
                response
            );
            Api.Number.Delete(id);
            AssertRequest(request);
        }
    }
}