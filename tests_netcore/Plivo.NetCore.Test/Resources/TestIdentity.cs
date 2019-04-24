using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Identity;
using Plivo.Utilities;
using System;

namespace Plivo.NetCore.Test.Resources
{
    public class TestIdentity : BaseTestCase
    {
        [Fact]
        public void TestIdentityCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"country_iso", "US"},
                {"salutation", "MR"},
                {"first_name", "Bruce"},
                {"last_name", "Wayne"},
                {"birth_place", "Gotham City"},
                {"birth_date", "1900-01-01"},
                {"nationality", "US"},
                {"id_nationality", "New York"},
                {"id_issue_date", "1900-01-01"},
                {"id_type", "passport"},
                {"id_number", "1234567890"},
                {"address_line1", "124"},
                {"address_line2", "Gotham City"},
                {"city", "New York"},
                {"region", "New York"},
                {"postal_code", "50607"},
            };

            string fileToUpload = "filetoupload.jpg";

            var filesToUpload = new Dictionary<string, string>()
            {
                {"file", fileToUpload}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Identity/",
                    "",
                    data,
                    filesToUpload
                );

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/identityCreateResponse.json"
                );

            Setup<IdentityCreateResponse>(
                200,
                response
            );

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Identity.CreateOld(
                        "US", "MR", "Bruce", "Wayne", "Gotham City", "1900-01-01", "US",
                                        "New York", "1900-01-01", "passport", "1234567890",
                        "124", "Gotham City", "New York", "New York", "50607",
                        fileToUpload: fileToUpload)));

            AssertRequest(request);
        }

        [Fact]
        public void TestIdentityCreateNew()
        {
            var data = new Dictionary<string, object>()
            {
                {"phone_number_country" , "US" },
                {"number_type" , "local" },
                {"country_iso", "US"},
                {"salutation", "MR"},
                {"first_name", "Bruce"},
                {"last_name", "Wayne"},
                {"birth_place", "Gotham City"},
                {"birth_date", "1900-01-01"},
                {"nationality", "US"},
                {"id_nationality", "New York"},
                {"id_issue_date", "1900-01-01"},
                {"address_proof_type", "passport"},
                {"id_number", "1234567890"},
                {"address_line1", "124"},
                {"address_line2", "Gotham City"},
                {"city", "New York"},
                {"region", "New York"},
                {"postal_code", "50607"},
            };

            string fileToUpload = "filetoupload.jpg";

            var filesToUpload = new Dictionary<string, string>()
            {
                {"file", fileToUpload}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Identity/",
                    "",
                    data,
                    filesToUpload
                );

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/identityCreateResponse.json"
                );

            Setup<IdentityCreateResponse>(
                200,
                response
            );

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Identity.Create(
                        "US", "local", "US", "MR", "Bruce", "Wayne", "Gotham City", "1900-01-01", "US",
                        "New York", "1900-01-01", "passport", "1234567890",
                        "124", "Gotham City", "New York", "New York", "50607",
                        fileToUpload: fileToUpload)));

            AssertRequest(request);
        }

        [Fact]
        public void TestIdentityGet()
        {
            var id = "24856289978366";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Identity/" + id + "/",
                    ""
                );
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/identityGetResponse.json"
                );
            Setup<Identity>(
                200,
                response
            );

            Assert.Empty(ComparisonUtilities.Compare(response, Api.Identity.GetOld(id)));
            AssertRequest(request);
        }

        [Fact]
        public void TestIdentityGetNew()
        {
            var id = "24856289978366";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Identity/" + id + "/",
                    ""
                );
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/identityGetResponseNew.json"
                );
            Setup<IdentityGetResponse>(
                200,
                response
            );

            Assert.Empty(ComparisonUtilities.Compare(response, Api.Identity.Get(id)));
            AssertRequest(request);
        }

        [Fact]
        public void TestIdentityList()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Identity/",
                    ""
                );
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/identityListResponse.json"
                );
            Setup<Identity>(
                200,
                response
            );

            Assert.Empty(ComparisonUtilities.Compare(response, Api.Identity.ListOld()));
            AssertRequest(request);
        }

        [Fact]
        public void TestIdentityListNew()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Identity/",
                    ""
                );
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/identityListResponseNew.json"
                );
            Setup<Identity>(
                200,
                response
            );

            Assert.Empty(ComparisonUtilities.Compare(response, Api.Identity.List()));
            AssertRequest(request);
        }

        [Fact]
        public void TestIdentityDelete()
        {
            var id = "24856289978366";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Identity/" + id + "/",
                    ""
                );
            var response = "";

            Setup<Identity>(
                204,
                response
            );

            Assert.Null(Api.Identity.DeleteOld(id));
            AssertRequest(request);
        }

        [Fact]
        public void TestIdentityDeleteNew()
        {
            var id = "24856289978366";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Identity/" + id + "/",
                    ""
                );

            var response = System.IO.File.ReadAllText(
                SOURCE_DIR + @"../Mocks/identityDeleteResponse.json"
            );
            Setup<IdentityDeleteResponse>(
                204,
                response
            );

            Assert.Empty(ComparisonUtilities.Compare(response, Api.Identity.Delete(id)));
            AssertRequest(request);
        }
    }
}