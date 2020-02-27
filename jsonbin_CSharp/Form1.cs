using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsonbin_CSharp
{
    public partial class Form1 : Form
    {
        public string secretkey = "$2b$10$CdNSq//d5XdPeYciIDAZ7OvuT0TehaArai2EJEElc1w98azsffjda";
        public string BinID = "";
        public Form1()
        {
            InitializeComponent();

            ReadBin();
        }

        public async void CreateBin()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.jsonbin.io/b"))
                {
                    request.Content = new StringContent("[{\"name\": \"Shahrukh Yousafzai\"");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content.Headers.Add("secret-key", secretkey);

                    var response = await httpClient.SendAsync(request);
                }
            }
        }

        public async void ReadBin()
        {

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.jsonbin.io/b/" + BinID))
                {
                    request.Headers.TryAddWithoutValidation("secret-key", secretkey);

                    var response = await httpClient.SendAsync(request);
                    var rs = await response.Content.ReadAsStringAsync();

                    MessageBox.Show(rs);
                }
            }
        }

        public async void UpdateBin()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("PUT"), "https://api.jsonbin.io/b/" + BinID))
                {
                    request.Content = new StringContent("{\"sample\": \"Hello World\"}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Headers.TryAddWithoutValidation("secret-key", secretkey);

                    var response = await httpClient.SendAsync(request);
                }
            }
        }

        public async void DeleteBin()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), "https://api.jsonbin.io/b/" + BinID))
                {
                    request.Headers.TryAddWithoutValidation("secret-key", secretkey);

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
    }
}
