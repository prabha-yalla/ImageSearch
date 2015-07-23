using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Web;
using Microsoft.Owin.Security.Cookies;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using System.Net.Http.Headers;

namespace AP_ImageSearch.Controllers
{
    [RoutePrefix("api/APSearch")]
    public class APSearchController : ApiController
    {
        string apikey = "AsGd3Ib2TXOfkPL3idZ24LO0vB7ksrHa";
        // http://localhost:49407/api/values/example3/2
        [Route("example2")]
        [HttpGet]
        public JObject Get()
        {
            string keyword = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.QueryString["q"]);
            string str = "";
            string URL = string.Format(@"http://api.ap.org/v2/search?&apikey={0}&q={1}&format={2}",
            apikey, System.Web.HttpUtility.UrlEncode(keyword), "json");
            using (var webClient = new System.Net.WebClient())
            {
                str = webClient.DownloadString(URL);
            }
            JObject json = JObject.Parse(str);
            return json;
        }
       
        // http://localhost:49407/api/values/example3/2/3/4
        [Route("example3")]
        [HttpGet]
        public HttpResponseMessage GetWith3ParametersAttributeRouting()
        {
            
            string imageUrl = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.QueryString["href"]);            
            string imgURL=(imageUrl+"&apikey=AsGd3Ib2TXOfkPL3idZ24LO0vB7ksrHa");
            WebClient lWebClient = new WebClient();
            byte[] lImageBytes = lWebClient.DownloadData(imgURL);
            MemoryStream imgStream = new MemoryStream(lImageBytes);
            var resp = new HttpResponseMessage()
            {
                Content = new StreamContent(imgStream)
            };
            // Find the MIME type      
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return resp;
        }
    }
}

