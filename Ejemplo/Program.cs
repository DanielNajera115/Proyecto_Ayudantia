using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Ejemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            string fbtoken = "EAAmrG2OoYasBAONBgdswCAfCG5OH2kV4kKcZBSNcUW2ssrUSgq5skwB0rZBrcFMZBbtx4x6T8HZCnfdR4Rb0D3bMnwk3f1ZCRyWL9ZBTZCnlScZCFs4vtJsLiFU07d6b87ZCcZCRlZCdiSERMV8AwQoCqpdwcajG2TD5gShFxFSvN83T7ITUf9yX7UVPrzZC6SCPPldIvr3RoCQahwZDZD";
            string fbfields = "posts{id,message}";
            FacebookAPI fb = new FacebookAPI(fbtoken);
            string result = fb.GET(fbfields).Result;
            var res = JsonConvert.DeserializeObject(result);
            //Console.Write(res);
            JObject jObject = JObject.Parse(result);
            JToken memberName = jObject["posts"];
            //Console.WriteLine(memberName.First.First.First.Next.SelectToken("message"));
            JToken toGetAllNames = memberName.First.First.First;
            while(toGetAllNames != null){
                Console.WriteLine(toGetAllNames.SelectToken("message"));
                toGetAllNames = toGetAllNames.Next;
            }
        }
    }
}
