using NBA_Analyzer.API;
using NBA_Analyzer.API2;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace NBA_Analyzer
{
    /// <summary>
    /// Lógica de interacción para equipos.xaml
    /// </summary>
    public partial class equipos : UserControl
    {
        public List<Jugador> lista_Jugadores=new List<Jugador>();
        public List<Team> lista_team=new List<Team>();
        static HttpClient client = new HttpClient();
        public Fotos fotos = new Fotos();
        public Jugador jugadorr;
        public Team equipito;
        public equipos(List<Jugador>lista_jugadores,List<Team> lista_equipos)
        {

            this.InitializeComponent();
            lista_Jugadores = lista_jugadores;
            lista_team= lista_equipos;
            foreach ( Team equipo in lista_equipos) 
            {
                listaEquipos.Items.Add(equipo.full_name);
            }
        }

        private void listaEquipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaJugadores.Items.Clear();
            var equipo =listaEquipos.SelectedItem;
            foreach (Team team in lista_team)
            {
                if (team.full_name == equipo)
                {
                    equipito = team;
                }
            }
            foreach( Jugador jugador in lista_Jugadores)
            {
                if (jugador.equipo.full_name == equipo)
                {
                    listaJugadores.Items.Add(jugador.first_name+ " "+ jugador.last_name);
                }
            }

        }


        private UserControl activeWindow = null;

        public void OpenControl(UserControl cont)
        {
            if (activeWindow != null)
            {
                ventana.Children.Clear();
            }
            activeWindow = cont;
            ventana.Children.Add(cont);
        }

        private void listaJugadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ultAnio = 2022;
            try { 
                fotos.url = "";
                fotos.url2 = "";

                var jugador = listaJugadores.SelectedItem;
                if (jugador != null)
                {


                    string id = "";
                    string datitos = "]";
                    string ppartidos = "]";
                    Boolean salir = false;
                    
                    string[] anios = new string[5];

                    string puntos="0";
                    string rebotes="0";
                    string robos = "0";
                    string asistencias = "0";
                    string tapones = "0";
                    string perdidas = "0";

                    for (int i = 0; i < anios.Length; i++)
                    {
                        anios[i] = "nada";
                    }
                    int x = 4;
                    foreach (Jugador ju in lista_Jugadores)
                    {
                        string nombre = ju.first_name + " " + ju.last_name;
                        if (nombre == jugador.ToString())
                        {
                            jugadorr = ju;
                            id = ju.id;
                            break;
                        }

                    }

                    using (var client = new HttpClient())
                    {
                        for (int i = 2022; salir == false; i--)
                        {
                            string url = "https://www.balldontlie.io/api/v1/season_averages?season=" + i + "&player_ids[]=" + id;

                            client.DefaultRequestHeaders.Clear();

                            var response = client.GetAsync(url).Result;

                            var res = response.Content.ReadAsStringAsync().Result;
                            dynamic r = JObject.Parse(res);
                            foreach (var datos in r.data)
                            {
                                salir = true;
                                ultAnio = i;
                                 puntos=datos.pts.ToString().Replace(',', '.');
                                 rebotes=datos.reb.ToString().Replace(',', '.');
                                robos=datos.stl.ToString().Replace(',', '.');
                                 asistencias = datos.ast.ToString().Replace(',', '.');
                                tapones = datos.blk.ToString().Replace(',', '.');
                                perdidas = datos.turnover.ToString().Replace(',', '.');

                            }

                        }
                        using (var cliente = new HttpClient())
                        {
                            string url2 = "https://image-charts.com/chart.js/2.8.0?bkg=white&c=";
                            cliente.DefaultRequestHeaders.Clear();
                            string parametros = "{\"type\": \"radar\", \"data\": { \"labels\": [ 'Puntos' ,'Rebotes', 'Robos', 'Asistencias','Tapones','perdidas'], \"datasets\":[ { \"backgroundColor\": \"rgba(255,150,150,0.5)\",       \"borderColor\": \"rgb(255,150,150)\", \"data\": [" + puntos + "," + rebotes + "," + robos + "," + asistencias + "," + tapones + "," + perdidas + "],\"label\": "+ultAnio+"}]}}";
                            dynamic jsonString = JObject.Parse(parametros);
                            var httpContent = new StringContent(jsonString.ToString(), Encoding.UTF8);
                            fotos.url2 = url2 + "" + jsonString;

                        }
                    }


                    for (int j = ultAnio; j > (ultAnio - 5); j--)
                        {
                            Boolean entrado = false;
                            string url = "https://www.balldontlie.io/api/v1/season_averages?season=" + j + "&player_ids[]=" + id;

                            client.DefaultRequestHeaders.Clear();

                            var response = client.GetAsync(url).Result;

                            var res = response.Content.ReadAsStringAsync().Result;
                            dynamic r = JObject.Parse(res);
                            foreach (var datos in r.data)
                            {
                                string partidos = datos.games_played.ToString().Replace(',', '.');
                            string ppuntos = datos.pts.ToString().Replace(',', '.');
                                anios[x] = j.ToString();
                                datitos =partidos + ","+datitos;
                                ppartidos = ppuntos +","+ppartidos;
                                x -= 1;
                                entrado = true;
                            }
                            if (entrado == false)
                            {
                                anios[x] = j.ToString();
                                x -= 1;
                                datitos= "0,"+datitos;
                                ppartidos= "0,"+ppartidos;
                            }



                        
                    }

                    datitos= "["+datitos;
                    ppartidos= "["+ppartidos;

                    using (var client = new HttpClient())
                    {
                        string url2 = "https://image-charts.com/chart.js/2.8.0?bkg=white&c=";
                        client.DefaultRequestHeaders.Clear();
                        string prametros = "{  \"type\": \"line\", \"data\": {   \"labels\": [" + anios[0] + ", " + anios[1] + ", " + anios[2] + "," + anios[3] + "," + anios[4] + "],    \"datasets\" : [      {        \"backgroundColor\": \"rgba(255,150,150,0.5)\",       \"borderColor\": \"rgb(255,150,150)\",       \"data\": " + datitos + ",        \"label\": \"Partidos jugados\",       \"fill\": \"origin\"      },{  \"backgroundColor\": \"rgba(54, 162, 235)\",       \"borderColor\": \"rgb(4, 162, 235, 0.5)\", \"data\": " + ppartidos+", \"label\":\"Puntos por Partido\"}    ]  }}";
                        
                        dynamic jsonString = JObject.Parse(prametros);
                        var httpContent = new StringContent(jsonString.ToString(), Encoding.UTF8);
                        fotos.url = url2 + "" + jsonString;

                    }
                }

                OpenControl(new Jugadores(fotos,equipito,jugadorr,ultAnio));
            }
            catch
            {
                MessageBox.Show("Numero de llamadas a la API superado, vuelve a intentarlo en unos segundos");
            }
        }
    }
}
