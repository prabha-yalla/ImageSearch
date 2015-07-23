using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Web;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string apiKey = "AsGd3Ib2TXOfkPL3idZ24LO0vB7ksrHa";
            var json = "";
            string keyword_search = "Tom cruise";
            string URL = string.Format(@"http://api.ap.org/v2/search?count=1&apikey={0}&q={1}",
                apiKey, HttpUtility.UrlEncode(keyword_search));


                using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString(URL);
                // Now parse with JSON.Net
            }
            return json;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
