using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Test
{

    class Post{
        string message;
        int id;
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            string fbtoken = "EAAmrG2OoYasBADZAeYkwU0Rhk9C2W5KrkO4ABQSkZBnV9WrKEQZCiFGzPMfFpH7IvJektMChwSYv2j2K6k5LBIZAwUZAZBxIICq7Nleqianbq2foTk1HPaUtWxoQuPkRfseBdfhMDqwRODUHnvIunI3aUgd7wMc19SqZAMGyZBmqz8nTLGvo5ixqmXyl6pOmQjIZD";
            string fbfields = "posts{message,reactions}";
            FacebookAPI fb = new FacebookAPI(fbtoken);
            string result = fb.GET(fbfields).Result;
            var res = JsonConvert.DeserializeObject(result);

            JObject jObject = JObject.Parse(result);
            JToken memberName = jObject["posts"];
            //Console.WriteLine(memberName.First.First.First.Next.SelectToken("message"));
            JToken toGetAllNames = memberName.First.First.First;
            while(toGetAllNames != null){
                Console.WriteLine(toGetAllNames.SelectToken("message"));
                toGetAllNames = toGetAllNames.Next;
            }
            //Console.WriteLine(memberName.First.Item("message"));
            
            //Console.Write(result);

        }
    }
}
