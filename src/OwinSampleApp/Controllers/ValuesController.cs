namespace OwinSampleApp.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;

    public class ValuesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            string ipaddress = this.GetIPAddress();

            return new string[] { "value1", "value2", ipaddress };
        }

        public string Get(int id)
        {
            return "value";
        }

        ////public void Post([FromBody]string value)
        ////{
        ////}

        ////public void Put(int id, [FromBody]string value)
        ////{
        ////}

        ////public void Delete(int id)
        ////{
        ////}
        private string GetIPAddress()
        {
            string strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipHostInfo = Dns.GetHostEntry(strHostName);
            IPAddress ipAddress = ipHostInfo.AddressList[0];

            return ipAddress.ToString();
        }
    }
}