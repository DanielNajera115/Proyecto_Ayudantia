using System;
using Newtonsoft.Json;
namespace Ejemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            string fbtoken = "EAASeftzCv2EBANcGVBK3vUdSIxVZCjDPZC95MKFYXl3xH9F5OcRMGtSSwDH9eXMRfbcEE25Jwmc1hd3LEREKuD6655odPEokwidsWgu7PZBOzxMuJd0SD46d81xsUhZCIw8ss8ZC117BmchmEB0UYfdKPXYL2jNRqVNZB8c3864ZBFkKlU99NxWS09rtNBkKrVVRxWEvCsP1gZDZD";
            string fbfields = "posts{id,message}";
            FacebookAPI fb = new FacebookAPI(fbtoken);
            string result = fb.GET(fbfields).Result;
            var res = JsonConvert.DeserializeObject(result);
            Console.Write(res);
        }
    }
}
