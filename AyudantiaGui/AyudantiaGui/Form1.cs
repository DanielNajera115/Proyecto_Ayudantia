using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AyudantiaGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e) {
            //PopulateItem();   
        }

        private void PopulateItem() {
            PostList[] listaDePost = new PostList[20];

            for (int i = 0; i < listaDePost.Length; i++)
            {
                listaDePost[i] = new PostList();
                listaDePost[i].Name = "Daniel";
                listaDePost[i].Message = "Commentario";
                flowLayoutPanel1.Controls.Add(listaDePost[i]);

            }
        }

        private async void enterData_Click(object sender, EventArgs e)
        {
            takeDataFromFaceBook();
        }

        public async void takeDataFromFaceBook() {
            int i=0;
            
            string fbtoken = "EAAmrG2OoYasBAO7aheE5uOqFNC7izPqope10gA2LGafomC71sMzfgUc6DvDEOsKEBJGWdWQGQrWLTlyayza6NNd4kIEWfN8pz3SZACmFkqWhZBa8U1n1salyh0ZCwUBiTLP91ZBf2B1IRdvjhieZA81mz6eHWUfyzhXGkuRHK1XcqcpRhY0P8SXroq9mJ7WxpRLu2kNetUQZDZD";
            string fbfields = "posts{id,message}";
            //List<string> names = new List<string>();
            FacebookAPI fb = new FacebookAPI(fbtoken);
            
            
            string result = fb.GET(fbfields).Result;
            var res = JsonConvert.DeserializeObject(result);
            JObject jObject = JObject.Parse(result);
            JToken memberName = jObject["posts"];
            JToken toGetAllNames = memberName.First.First.First;

            flowLayoutPanel1.Controls.Clear();
            PostList[] listaDePost = new PostList[20];

            while (toGetAllNames != null)
            {

              Console.WriteLine(toGetAllNames.SelectToken("message"));
                //names.Add(toGetAllNames.SelectToken("message"));
                listaDePost[i] = new PostList();
                listaDePost[i].Title = "Daniel Najera";
                listaDePost[i].Message = toGetAllNames.SelectToken("message").ToString();
                flowLayoutPanel1.Controls.Add(listaDePost[i]);
                toGetAllNames = toGetAllNames.Next;
            }
        }

    }
}
