using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
namespace DemoAPIClient
{
    static class Program
    {
      
        [STAThread]
       
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RunClient();
            Application.Run(new Form1());
        }
        public static HttpClient APIClient;
        static void RunClient()
        {
            APIClient = new HttpClient();

            APIClient.BaseAddress = new Uri("http://localhost:54065");
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
    }
}
