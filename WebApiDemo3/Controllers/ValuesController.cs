using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace WebApiDemo3.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        static List<string> stringsList = new List<string>()
        {
            "value0", "value1","value2"
        };

        public partial class JString
        {
            public string subject { get; set; }
            public string message { get; set; }
        }

        static string txt = "recd message";
        static string path = "C:\\temp\\webhook.txt";
        // GET api/values
        public IEnumerable<string> Get()
        {
            File.WriteAllText(path, txt);
            return stringsList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return stringsList[id];
        }
        

        public string Get(string sms)
        {
            return stringsList[1];
        }

        
        public void Post([FromBody] JString jstr)
        {
            string path = "C:\\temp\\posthook.txt";
            string jsonString = JsonSerializer.Serialize(jstr);
            File.WriteAllText(path, jsonString);
        }        

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
