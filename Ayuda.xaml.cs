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
using System.Windows.Shapes;

namespace NBA_Analyzer
{
    /// <summary>
    /// Lógica de interacción para Ayuda.xaml
    /// </summary>
    public partial class Ayuda : Window
    {
        private List<Ayuda> ayudas;
        //private Ayuda ayudaSel;

        public static TabControl tc_ayudaG;



        internal List<Ayuda> Ayudas
        {
            get => ayudas; set => ayudas = value;
        }

        public Ayuda(InicioSesion inicioSesion)
        {
            InitializeComponent();
            tc_ayudaG = tc_ayudas;

            //Ayudas = ayds;

            //cargar lista de ayudas
            //lb_ayuda.ItemsSource = Ayudas;
            //lb_ayuda.SelectedIndex = -1;

            //ti_desc.Visibility = Visibility.Collapsed;

        }

        /*
        private void lb_ayuda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_ayuda.SelectedIndex != -1)
            {
                ti_desc.Visibility = Visibility.Visible;
                tc_ayudas.SelectedIndex = 1;
                ayudaSel = (Ayuda)lb_ayuda.SelectedItem;

                cargarContenidoDesc();
            }
        }
        */

        /*
        private void cargarContenidoDesc()
        {
            if (ayudaSel != null)
            {
                //cargar titulo
                lbl_titulo.Content = ayudaSel.Titulo;
                //cargar nPasos
                sp_pasos.Children.RemoveRange(0, 50);

                for (int i = 0; i < ayudaSel.Pasos.Length; i++)
                {
                    RadioButton r = new RadioButton();
                    r.Name = "RB_" + i;
                    r.Click += RB_Click;
                    r.Content = i + 1;
                    r.Margin = new Thickness(3, 0, 3, 0);
                    r.Foreground = (SolidColorBrush)Application.Current.Resources["bordeOscuro"];
                    if (i == 0)
                    {
                        r.IsChecked = true;
                    }
                    sp_pasos.Children.Add(r);
                }

                //cargar paso 1
                //sp_pasos.Children..IsChecked = true;
                txt_descripcion.Text = ayudaSel.Pasos.ElementAt(0).Descripcion;
                //cargar foto
                var bitmap = new BitmapImage(ayudaSel.Pasos[0].Foto);
                img_foto.Source = bitmap;
            }
        }
        */

        private void RB_Click(object sender, RoutedEventArgs e)
        {
            RadioButton r = e.Source as RadioButton;
            string nombre = r.Name;
            string id = nombre.Substring(3);
            int sel = int.Parse(id);

            //txt_descripcion.Text = ayudaSel.Pasos.ElementAt(sel).Descripcion;
            //cambiar foto
            //var bitmap = new BitmapImage(ayudaSel.Pasos[sel].Foto);
            //img_foto.Source = bitmap;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InicioSesion.b_ayuda_L.IsEnabled = true;
            //Menu.b_ayuda_C.IsEnabled = true;
        }

        /*
        private void tc_ayudas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ti_lista.IsSelected)
            {
                ti_desc.Visibility = Visibility.Collapsed;
                lb_ayuda.SelectedIndex = -1;
            }
        }
        */
    }
}
