using System;
using Newtonsoft.Json;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string fbtoken = "EAASeftzCv2EBABU5lgkmKiDn6IU7fWHG2f6TWEpY48ykKGX11qVowo19SVlKAghLs54gxRAy2eopSFEgTD26dvWAdxULv7UA4hAlFqZCt0ZB1RtMN2ZBe9ojV87FZBfm5sD9IntMl8BL0dyM1ZAKiJgqcCgGBDdlKNKmnzMBuva8QnnOFl6CNO2lOES9XZAZCkZD";
            string fbfields = "posts{id,message}";
            FacebookAPI fb = new FacebookAPI(fbtoken);
            string result = fb.GET(fbfields).Result;
            var res = JsonConvert.DeserializeObject(result);
            Console.Write(res);
        }
    }
}
