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
//using MySql.Data.MySqlClient;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;
using Label = System.Windows.Controls.Label;
using NBA_Analyzer.clases;

namespace NBA_Analyzer
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Team> lista_equipos=new List<Team>();
        public List<Jugador> lista_jugadores=new List<Jugador>();
        static HttpClient client = new HttpClient();

        //labels
        public static Label nombreUsuario;
        public static Label apellidosUsuario;
        public static Label ultimoInicio;



        public MainWindow(InicioSesion inicioSesion)
        {
            InitializeComponent();

            pedirEquipos();
            pedirJugadores();



        }

       

        private System.Windows.Controls.UserControl activeWindow = null;

        public void OpenControl(UserControl cont)
        {
            if (activeWindow != null)
            {
                ventana.Children.Clear();
            }
            activeWindow = cont;
            ventana.Children.Add(cont);
        }

        public void pedirEquipos()
        {
            using (var client = new HttpClient())
            {
                string url = "https://www.balldontlie.io/api/v1/teams";

                client.DefaultRequestHeaders.Clear();

                var response = client.GetAsync(url).Result;

                var res = response.Content.ReadAsStringAsync().Result;
                dynamic r = JObject.Parse(res);
                foreach (var team in r.data)
                {
                    string eid = team.id;
                    string eabb = team.abbreviation;
                    string eci = team.city;
                    string eco = team.conference;
                    string edi = team.division;
                    string efu = team.full_name;
                    string ena = team.name;

                    Team equipo = new Team(eid, eabb, eci, eco, edi, efu, ena);
                    lista_equipos.Add(equipo);
                }


            }

        }




        public void pedirJugadores()
        {
            Team equipo=new Team("","","","","","","");
                using (var client = new HttpClient())
                {
                    for (int i = 1; i < 3; i++)
                    {
                        string url = "https://www.balldontlie.io/api/v1/players?per_page=100&page=" + i;



                        var response = client.GetAsync(url).Result;

                        var res = response.Content.ReadAsStringAsync().Result;
                        dynamic r = JObject.Parse(res);
                        foreach (var jugador in r.data)
                        {
                            foreach (Team team in lista_equipos)
                        {
                            string id = jugador.team.id;
                            if (team.id == id)
                                equipo = team;
                        }
                            

                        string jid = jugador.id;
                        string jfi = jugador.first_name;
                        string jla=jugador.last_name;
                        string jpo = jugador.posicion;
                        Int32 jhef = 0;
                        Int32 jhei = 0;
                        Int32 jwe = 0;
                        try
                        {
                            jhef = jugador.heigth_feet;
                            jhei = jugador.heigth_inches;
                            jhef = jugador.weigth_pounds;
                        }catch
                        {

                        }

                            Jugador jugador1 = new Jugador(jid,jfi,jla,jpo,jhef,jhei,jwe, equipo);
                            lista_jugadores.Add(jugador1);

                        }
                    }
                }
            
        }

        private void Jugadores_Click(object sender, RoutedEventArgs e)
        {
            OpenControl(new equipos(lista_jugadores, lista_equipos));
        }

        public static void asignarUSuario(Administrador a)
        {
            nombreUsuario.Content = a.Nombre;
            apellidosUsuario.Content = a.Apellidos;
            ultimoInicio.Content = a.UltimoAcceso.ToString();
        }
    }
}
