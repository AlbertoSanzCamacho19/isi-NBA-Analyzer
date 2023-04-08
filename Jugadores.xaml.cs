using NBA_Analyzer.API;
using NBA_Analyzer.API2;
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

namespace NBA_Analyzer
{
    /// <summary>
    /// Lógica de interacción para Jugadores.xaml
    /// </summary>
    public partial class Jugadores : UserControl
    {
        public Jugadores(Fotos foto,Team equipo,Jugador jugador, int anio)
        {
            InitializeComponent();
            DataContext = foto;
            label_jugador.Content = jugador.first_name + " " + jugador.last_name;
            label_anio.Content = "Último año: "+anio;
            label_altura.Content = "Altura: " + jugador.height_feet + " pies";
            label_posicion.Content = "Posicion: "+jugador.position;
            label_peso.Content = "Peso: " + jugador.weigth_pounds+" pounds";
            label_equipo.Content = "Equipo: " + equipo.full_name;
            label_conferencia.Content = "Conferencia: " + equipo.conference;
            label_ciudad.Content = "Ciudad: " + equipo.city;
            label_division.Content="Division: "+ equipo.division;
        }
    }
}
