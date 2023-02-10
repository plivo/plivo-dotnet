using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Brand;
using Plivo.Utilities;
using System;

namespace Plivo.NetCore.Test.Resources
{
    public class TestBrand : BaseTestCase
    {
        [Fact]
        public void TestBrandList()
        {
            var data = new Dictionary<string, object>();
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/10dlc/Brand/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/brandListResponse.json"
                );
            Setup<ListResponse<ListBrands>>(
                200,
                response
            );
           var resp =  Api.Brand.List();
            AssertRequest(request);
        }

        [Fact]
        public void TestBrandGet()
        {
            var id = "BRPXS6E";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/10dlc/Brand/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/brandGetResponse.json"
                );
            Setup<GetBrand>(
                200,
                response
            );
            var resp =  Api.Brand.Get(id);
            AssertRequest(request);
        }

        [Fact]
        public void TestBrandUsecase()
        {
            var id = "BSWXXXX";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/10dlc/Brand/" + id + "/usecases/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/brandListUsecase.json"
                );
            Setup<GetBrandUsecases>(
                200,
                response
            );
            var resp =  Api.Brand.ListUsecases(id);
            AssertRequest(request);
        }

        [Fact]
        public void TestBrandDelete()
        {
            var id = "BSWXXXX";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/10dlc/Brand/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/brandDeleteResponse.json"
                );
            Setup<DeleteResponse<DeleteBrand>>(
                200,
                response
            );
            var resp =  Api.Brand.Delete(id);
            AssertRequest(request);
        }
    }
}
