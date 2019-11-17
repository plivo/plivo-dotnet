using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Powerpack;
using Plivo.Utilities;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestPowerpack : BaseTestCase
    {

        [Test]
        public void TestPowerpackCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"name", "vishnu"},
                {"StickySender", True}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Powerpack/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/powerpack.json"
                );
            Setup<Powerpack>(
                201,
                response
            );
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Powerpacks.Create( new List<string>() {name="vishnu", sticky_sender=True}
                       )));
            AssertRequest(request);
        }

        [Test]
        public void TestPowerpackList()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 10}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Powerpack/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/powerpackList.json"
                );
            Setup<ListResponse<Powerpack>>(
                200,
                response
            );
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Powerpacks.List(limit: 10)));

            AssertRequest(request);
        }

        [Test]
        public void TestPowerpackGet()
        {
            var id = "5ec4c8c9-cd74-42b5-9e41-0d7670d6bb46";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Powerpack/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/powerpack.json"
                );
            Setup<Powerpack>(
                200,
                response
            );
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Powerpacks.Get(id)));

            AssertRequest(request);
        }

        [Test]
        public void TestPowerpackUpdate()
        {
            var id = "5ec4c8c9-cd74-42b5-9e41-0d7670d6bb46";
            var data = new Dictionary<string, object>()
            {
                {"name", "vishnu123"}
               
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Powerpack/" + id + "/",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/powerpack.json"
                );
            Setup<Powerpack>(
                200,
                response
            );
            var powerpack = Api.Powerpack.Get(id);
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    powerpack.Update(name="vishnu123" )));

            AssertRequest(request);
        }
        [Test]
        public void TestPowerpackDelete()
        {
            var id = "d35f2e82-d387-427f-8594-6fa07613c43a";
            var data = new Dictionary<string, object>()
            {
                {"unrent_numbers", true}
               
            };
            var request =
                new PlivoRequest(
                    "Delete",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Powerpack/" + id + "/",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/powerpackDeleteResponse.json"
                );
            Setup<Powerpack>(
                200,
                response
            );
            var powerpack = Api.Powerpack.Get(id);
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    powerpack.Delete( unrent_numbers=True )));

            AssertRequest(request);
        }

        [Test]
        public void TestListNumbers()
        {
            var id = "d35f2e82-d387-427f-8594-6fa07613c43a";
            var data = new Dictionary<string, object>()
            {
                {"limit", 1}
               
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/NumberPool/ca5fd1f2-26c0-43e9-a7e4-0dc426e9dd2f/Number/",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/numberpoolNumberResponse.json"
                );
            Setup<NumberPool>(
                200,
                response
            );
            var powerpack = Api.Powerpack.Get(id);
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    powerpack.List_Numbers( limit=1 )));

            AssertRequest(request);
        }

        [Test]
        public void TestAddNumbers()
        {
            var id = "d35f2e82-d387-427f-8594-6fa07613c43a";
            var number ="15799140336";
           
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/NumberPool/ca5fd1f2-26c0-43e9-a7e4-0dc426e9dd2f/Number/"+number+"/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/numberpoolSingleNoResponse.json"
                );
            Setup<NumberPool>(
                200,
                response
            );
            var powerpack = Api.Powerpack.Get(id);
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    powerpack.Add_Number( number )));

            AssertRequest(request);
        }
        
        [Test]
         public void TestFindNumbers()
        {
            var id = "d35f2e82-d387-427f-8594-6fa07613c43a";
            var number ="15799140336";
           
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/NumberPool/ca5fd1f2-26c0-43e9-a7e4-0dc426e9dd2f/Number/"+number+"/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/numberpoolSingleNoResponse.json"
                );
            Setup<NumberPool>(
                200,
                response
            );
            var powerpack = Api.Powerpack.Get(id);
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    powerpack.Find_Number( number )));

            AssertRequest(request);
        }


        [Test]
         public void TestFindShortcode()
        {
            var id = "d35f2e82-d387-427f-8594-6fa07613c43a";
            var shortcode ="444444";
           
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/NumberPool/ca5fd1f2-26c0-43e9-a7e4-0dc426e9dd2f/Shortcode/"+shortcode+"/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/numberpoolSingleShortcodeResponse.json"
                );
            Setup<NumberPool>(
                200,
                response
            );
            var powerpack = Api.Powerpack.Get(id);
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    powerpack.Find_Shortcode( shortcode )));

            AssertRequest(request);
        }
         [Test]
         public void TestListShortcode()
        {
            var id = "d35f2e82-d387-427f-8594-6fa07613c43a";
            var number ="444444";
            var id = "d35f2e82-d387-427f-8594-6fa07613c43a";
            var data = new Dictionary<string, object>()
            {
                {"limit", 1}
               
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/NumberPool/ca5fd1f2-26c0-43e9-a7e4-0dc426e9dd2f/Shortcode/",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/numberpoolShortcodeResponse.json"
                );
            Setup<Shortcode>(
                200,
                response
            );
            var powerpack = Api.Powerpack.Get(id);
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    powerpack.List_Shortcode( limit: 1)));

            AssertRequest(request);
        }
    }
}