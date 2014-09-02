using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plivo.Extensibility;
using Plivo.Objects;

namespace Plivo.Samples
{
    public class Sample
    {
        public void Test()
        {
            IPlivoClientFactory restClientFactory = new PlivoRESTClientFactory();
            IPlivoClient client = restClientFactory.CreateClient("testAuthId","testAuthToken","v1");
            IPlivoResponse<Account> accountResult = client.GetAccount();
            Task<IPlivoResponse<Account>> asyncAccountResult = client.GetAccountAsync();
        }
    }
}
