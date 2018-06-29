﻿using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Address;
using Plivo.Utilities;
using System;
using Xunit.Sdk;

namespace Plivo.NetCore.Test.Resources
{
    public class TestAddress : BaseTestCase
    {
        [Fact]
        public void TestAddressCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"country_iso", "US"},
                {"salutation", "MR"},
                {"first_name", "Bruce"},
                {"last_name", "Wayne"},
                {"address_line1", "124"},
                {"address_line2", "Gotham City"},
                {"city", "New York"},
                {"region", "New York"},
                {"postal_code", "50607"},
                {"address_proof_type", "others"},
            };

            string fileToUpload = "filetoupload.jpg";

            var filesToUpload = new Dictionary<string, string>()
            {
                {"file", fileToUpload}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Address/",
                    "",
                    data,
                    filesToUpload
                );

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/addressCreateResponse.json"
                );

            Setup<AddressCreateResponse>(
                200,
                response
            );

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Address.Create("US", "MR", "Bruce", "Wayne", "124", "Gotham City", "New York", "New York",
                        "50607", "others", fileToUpload: fileToUpload)));
            AssertRequest(request);
        }

        [Fact]
        public void TestAddressGet()
        {
            var id = "20220771838737";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Address/" + id + "/",
                    "");
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/addressGetResponse.json"
                );
            Setup<Address>(
                200,
                response
            );

            Assert.Empty(ComparisonUtilities.Compare(response, Api.Address.Get(id)));
            AssertRequest(request);
        }

        [Fact]
        public void TestAddressList()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Address/",
                    ""
                );
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/addressListResponse.json"
                );
            Setup<Address>(
                200,
                response
            );

            Assert.Empty(ComparisonUtilities.Compare(response, Api.Address.List()));
            AssertRequest(request);
        }

        [Fact]
        public void TestAddressDelete()
        {
            var id = "20220771838737";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Verification/Address/" + id + "/",
                    ""
                );

            var response = "";
            Setup<UpdateResponse<Address>>(
                204,
                response
            );

            Assert.Null(Api.Address.Delete(id));
            AssertRequest(request);
        }
    }
}