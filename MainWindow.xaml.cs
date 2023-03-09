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
    }
}
