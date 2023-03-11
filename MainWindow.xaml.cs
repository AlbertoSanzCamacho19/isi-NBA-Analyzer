using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;
using NBA_Analyzer.API;
using System.IO;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using NBA_Analyzer.API2;

namespace NBA_Analyzer
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();

            using (var client = new HttpClient())
            {
                string url2 = "https://image-charts.com/chart.js/2.8.0?bkg=white&c=";
                client.DefaultRequestHeaders.Clear();
                string data = "[ 23, 64, 21, 53, -39, -30, 28, -10]";
                string prametros = "{  \"type\": \"line\", \"data\": {   \"labels\": [\"Jan\", \"Feb\", \"Mar\", \"Apr\", \"May\", \"Jun\", \"Jul\", \"Aug\"],    \"datasets\": [      {        \"backgroundColor\": \"rgba(255,150,150,0.5)\",       \"borderColor\": \"rgb(255,150,150)\",       \"data\": "+data+",        \"label\": \"Dataset\",       \"fill\": \"origin\"      }    ]  }}";
                dynamic jsonString = JObject.Parse(prametros);
                Fotos fotos = new Fotos();
                var httpContent = new StringContent(jsonString.ToString(), Encoding.UTF8);
                fotos.url= url2 + "" + jsonString;
                
                DataContext = fotos;
            }

        }

        private void boton_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                string url = "https://www.balldontlie.io/api/v1/teams";

                client.DefaultRequestHeaders.Clear();

                var response = client.GetAsync(url).Result;

                var res = response.Content.ReadAsStringAsync().Result;
                dynamic r = JObject.Parse(res);
                foreach(var equipo in r.data)
                {
                    listaJugadores.Items.Add(equipo.full_name);
                }
                

            }
        }

        private void boton2_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                string url2 = "https://image-charts.com/chart";
                client.DefaultRequestHeaders.Clear();
                string prametros = "{  \"type\": \"line\"  \"data\": {  \"labels\": [\"Jan\", \"Feb\", \"Mar\", \"Apr\", \"May\", \"Jun\", \"Jul\", \"Aug\"],  \"datasets\": [ { \"backgroundColor\": \"rgba(255,150,150,0.5)\",    \"borderColor\": \"rgb(255,150,150)\",   \"data\": [-23, 64, 21, 53, -39, -30, 28, -10], \"label\": \"Dataset\",        \"fill\": \"origin\" }    ]  }}";
                dynamic jsonString=JObject.Parse(prametros);
                Fotos fotos = new Fotos();
                var httpContent=new StringContent(jsonString.ToString(),Encoding.UTF8);
                fotos.url = "https://image-charts.com/chart.js/2.8.0?bkg=white&c={type:'line',data:{labels:['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug'],datasets:[{backgroundColor:'rgba(255,150,150,0.5)',borderColor:'rgb(255,150,150)',data:[-23,64,21,53,-39,-30,28,-10],label:'Dataset',fill:'origin'}]}}";
          
                DataContext = fotos;
            }
        }



    }
}
