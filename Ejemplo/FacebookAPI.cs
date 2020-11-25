using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace Test{
    public class FacebookAPI{
        private string tokenApi;
        private const string fb_addres = "https://graph.facebook.com/";

        public FacebookAPI(string tokenApi) => (this.tokenApi) = (tokenApi); 

        public async Task<string> GET(string fields){
            using(var httpclient = new HttpClient()){
                httpclient.BaseAddress = new Uri(fb_addres);
                var result = await httpclient.GetAsync(String.Format("me?fields={0}&access_token={1}", fields, tokenApi));
                var msg = result.EnsureSuccessStatusCode();
                return await msg.Content.ReadAsStringAsync();
            }
        }
    }
}