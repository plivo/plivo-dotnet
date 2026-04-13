using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.PhoneNumberCompliance;
using Plivo.Utilities;
using System;
using Plivo.Test;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestPhoneNumberCompliance : BaseTestCase
    {
        // =============================================
        // Requirements
        // =============================================

        [Test]
        public void TestGetRequirements()
        {
            var data = new Dictionary<string, object>()
            {
                {"country_iso", "US"},
                {"number_type", "local"},
                {"user_type", "business"}
            };

            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/Requirements/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceRequirementGetResponse.json"
                );
            Setup<PhoneNumberComplianceRequirement>(
                200,
                response
            );

            Assert.IsNotNull(Api.PhoneNumberComplianceRequirement.Get("US", "local", "business"));
            AssertRequest(request);
        }

        [Test]
        public void TestGetRequirementsEmptyDocumentTypes()
        {
            var data = new Dictionary<string, object>()
            {
                {"country_iso", "US"},
                {"number_type", "local"},
                {"user_type", "business"}
            };

            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/Requirements/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceRequirementGetEmptyResponse.json"
                );
            Setup<PhoneNumberComplianceRequirement>(
                200,
                response
            );

            var result = Api.PhoneNumberComplianceRequirement.Get("US", "local", "business");
            Assert.IsNotNull(result);
            AssertRequest(request);
        }

        // =============================================
        // Create
        // =============================================

        [Test]
        public void TestComplianceCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"country_iso", "US"},
                {"number_type", "local"},
                {"user_type", "business"},
                {"alias", "My US Local Compliance"},
                {"end_user_id", "EU-001"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceCreateResponse.json"
                );
            Setup<ComplianceCreateResponse>(
                201,
                response
            );

            var dataJson = "{\"country_iso\":\"US\",\"number_type\":\"local\",\"user_type\":\"business\",\"alias\":\"My US Local Compliance\",\"end_user_id\":\"EU-001\"}";
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.Create(dataJson)));
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceCreateWithDocuments()
        {
            var data = new Dictionary<string, object>()
            {
                {"country_iso", "US"},
                {"number_type", "local"},
                {"user_type", "business"},
                {"alias", "My US Local Compliance"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceCreateResponse.json"
                );
            Setup<ComplianceCreateResponse>(
                201,
                response
            );

            var dataJson = "{\"country_iso\":\"US\",\"number_type\":\"local\",\"user_type\":\"business\",\"alias\":\"My US Local Compliance\"}";
            var documentFiles = new Dictionary<string, string>()
            {
                {"document_file", "/path/to/document.pdf"}
            };
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.Create(dataJson, documentFiles)));
            AssertRequest(request);
        }

        // =============================================
        // List
        // =============================================

        [Test]
        public void TestComplianceList()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 20},
                {"offset", 0}
            };

            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceListResponse.json"
                );
            Setup<ComplianceListResponse>(
                200,
                response
            );

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.List()));
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceListWithFilters()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 10},
                {"offset", 0},
                {"status", "approved"},
                {"country_iso", "US"},
                {"number_type", "local"}
            };

            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceListResponse.json"
                );
            Setup<ComplianceListResponse>(
                200,
                response
            );

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.List(
                        limit: 10, offset: 0, status: "approved",
                        countryIso: "US", numberType: "local")));
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceListEmpty()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 20},
                {"offset", 0}
            };

            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceListEmptyResponse.json"
                );
            Setup<ComplianceListResponse>(
                200,
                response
            );

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.List()));
            AssertRequest(request);
        }

        // =============================================
        // Get
        // =============================================

        [Test]
        public void TestComplianceGet()
        {
            var id = "COMP-12345";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceGetResponse.json"
                );
            Setup<ComplianceGetResponse>(
                200,
                response
            );

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.Get(id)));
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceGetWithExpand()
        {
            var id = "COMP-12345";
            var data = new Dictionary<string, object>()
            {
                {"expand", "end_user,documents"}
            };

            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceGetResponse.json"
                );
            Setup<ComplianceGetResponse>(
                200,
                response
            );

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.Get(id, expand: "end_user,documents")));
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceGetUrlPath()
        {
            var id = "COMP-12345";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceGetResponse.json"
                );
            Setup<ComplianceGetResponse>(
                200,
                response
            );

            Api.PhoneNumberCompliance.Get(id);

            // Verify the URL path includes PhoneNumber/Compliance
            Assert.AreEqual(
                "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/" + id + "/",
                ((TestClient)Api.Client._client).Request.Uri);
        }

        // =============================================
        // Update (PATCH)
        // =============================================

        [Test]
        public void TestComplianceUpdate()
        {
            var id = "COMP-12345";
            var data = new Dictionary<string, object>()
            {
                {"alias", "Updated Compliance Name"},
                {"callback_url", "https://example.com/new-callback"}
            };

            var request =
                new PlivoRequest(
                    "PATCH",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceUpdateResponse.json"
                );
            Setup<ComplianceUpdateResponse>(
                200,
                response
            );

            var dataJson = "{\"alias\":\"Updated Compliance Name\",\"callback_url\":\"https://example.com/new-callback\"}";
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.Update(id, dataJson)));
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceUpdatePatchMethod()
        {
            var id = "COMP-12345";
            var data = new Dictionary<string, object>()
            {
                {"alias", "Updated Name"}
            };

            var request =
                new PlivoRequest(
                    "PATCH",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceUpdateResponse.json"
                );
            Setup<ComplianceUpdateResponse>(
                200,
                response
            );

            var dataJson = "{\"alias\":\"Updated Name\"}";
            Api.PhoneNumberCompliance.Update(id, dataJson);

            // Verify that PATCH method is used
            Assert.AreEqual("PATCH", ((TestClient)Api.Client._client).Request.Method);
            AssertRequest(request);
        }

        // =============================================
        // Delete
        // =============================================

        [Test]
        public void TestComplianceDelete()
        {
            var id = "COMP-12345";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceDeleteResponse.json"
                );
            Setup<ComplianceDeleteResponse>(
                204,
                response
            );

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.Delete(id)));
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceDeleteUrlPath()
        {
            var id = "COMP-67890";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceDeleteResponse.json"
                );
            Setup<ComplianceDeleteResponse>(
                204,
                response
            );

            Api.PhoneNumberCompliance.Delete(id);

            // Verify the URL path is correct for delete
            Assert.AreEqual(
                "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/" + id + "/",
                ((TestClient)Api.Client._client).Request.Uri);
            AssertRequest(request);
        }

        // =============================================
        // Link Numbers
        // =============================================

        [Test]
        public void TestComplianceLinkNumbers()
        {
            var numbers = new List<object>
            {
                new Dictionary<string, object>
                {
                    {"number", "+14151234567"},
                    {"compliance_id", "COMP-12345"}
                },
                new Dictionary<string, object>
                {
                    {"number", "+14159876543"},
                    {"compliance_id", "COMP-12345"}
                }
            };

            var data = new Dictionary<string, object>()
            {
                {"numbers", numbers}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/Link/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceLinkResponse.json"
                );
            Setup<ComplianceLinkResponse>(
                200,
                response
            );

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.LinkNumbers(numbers)));
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceLinkNumbersEmptyReport()
        {
            var numbers = new List<object>();

            var data = new Dictionary<string, object>()
            {
                {"numbers", numbers}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/Link/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceLinkEmptyReportResponse.json"
                );
            Setup<ComplianceLinkResponse>(
                200,
                response
            );

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.LinkNumbers(numbers)));
            AssertRequest(request);
        }

        // =============================================
        // Edge Cases
        // =============================================

        [Test]
        public void TestComplianceListPagination()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 5},
                {"offset", 10}
            };

            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceListResponse.json"
                );
            Setup<ComplianceListResponse>(
                200,
                response
            );

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.List(limit: 5, offset: 10)));
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceListWithAllFilters()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 10},
                {"offset", 5},
                {"status", "pending"},
                {"country_iso", "DE"},
                {"number_type", "mobile"},
                {"user_type", "individual"},
                {"alias", "my-compliance"},
                {"expand", "end_user"}
            };

            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceListResponse.json"
                );
            Setup<ComplianceListResponse>(
                200,
                response
            );

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.List(
                        limit: 10, offset: 5, status: "pending",
                        countryIso: "DE", numberType: "mobile",
                        userType: "individual", alias: "my-compliance",
                        expand: "end_user")));
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceCreateRequestBodyStructure()
        {
            var data = new Dictionary<string, object>()
            {
                {"country_iso", "GB"},
                {"number_type", "mobile"},
                {"user_type", "individual"},
                {"alias", "UK Mobile Compliance"},
                {"callback_url", "https://example.com/callback"},
                {"callback_method", "POST"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceCreateResponse.json"
                );
            Setup<ComplianceCreateResponse>(
                201,
                response
            );

            var dataJson = "{\"country_iso\":\"GB\",\"number_type\":\"mobile\",\"user_type\":\"individual\",\"alias\":\"UK Mobile Compliance\",\"callback_url\":\"https://example.com/callback\",\"callback_method\":\"POST\"}";
            Api.PhoneNumberCompliance.Create(dataJson);

            // Verify the request body contains all expected fields
            var sentRequest = ((TestClient)Api.Client._client).Request;
            Assert.AreEqual("POST", sentRequest.Method);
            Assert.IsTrue(sentRequest.Data.ContainsKey("country_iso"));
            Assert.IsTrue(sentRequest.Data.ContainsKey("number_type"));
            Assert.IsTrue(sentRequest.Data.ContainsKey("user_type"));
            Assert.IsTrue(sentRequest.Data.ContainsKey("alias"));
            Assert.IsTrue(sentRequest.Data.ContainsKey("callback_url"));
            Assert.IsTrue(sentRequest.Data.ContainsKey("callback_method"));
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceLinkUrlPath()
        {
            var numbers = new List<object>
            {
                new Dictionary<string, object>
                {
                    {"number", "+14151234567"},
                    {"compliance_id", "COMP-12345"}
                }
            };

            var data = new Dictionary<string, object>()
            {
                {"numbers", numbers}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/Link/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceLinkResponse.json"
                );
            Setup<ComplianceLinkResponse>(
                200,
                response
            );

            Api.PhoneNumberCompliance.LinkNumbers(numbers);

            // Verify the Link URL path is correct
            Assert.AreEqual(
                "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/Link/",
                ((TestClient)Api.Client._client).Request.Uri);
            AssertRequest(request);
        }

        [Test]
        public void TestComplianceUpdateWithDocuments()
        {
            var id = "COMP-12345";
            var data = new Dictionary<string, object>()
            {
                {"alias", "Updated with docs"}
            };

            var request =
                new PlivoRequest(
                    "PATCH",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceUpdateResponse.json"
                );
            Setup<ComplianceUpdateResponse>(
                200,
                response
            );

            var dataJson = "{\"alias\":\"Updated with docs\"}";
            var documentFiles = new Dictionary<string, string>()
            {
                {"document_file", "/path/to/updated_document.pdf"}
            };
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.PhoneNumberCompliance.Update(id, dataJson, documentFiles)));
            AssertRequest(request);
        }

        [Test]
        public void TestRequirementsUrlPath()
        {
            var data = new Dictionary<string, object>()
            {
                {"country_iso", "DE"},
                {"number_type", "mobile"},
                {"user_type", "individual"}
            };

            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/Requirements/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/complianceRequirementGetResponse.json"
                );
            Setup<PhoneNumberComplianceRequirement>(
                200,
                response
            );

            Api.PhoneNumberComplianceRequirement.Get("DE", "mobile", "individual");

            // Verify the Requirements URL path is correct
            Assert.AreEqual(
                "Account/MAXXXXXXXXXXXXXXXXXX/PhoneNumber/Compliance/Requirements/",
                ((TestClient)Api.Client._client).Request.Uri);
            AssertRequest(request);
        }
    }
}
