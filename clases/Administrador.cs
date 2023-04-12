using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA_Analyzer.clases
{
    public class Administrador
    {
        public string Usuario { set; get; }
        public string Contrasenia { set; get; }
        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public DateTime UltimoAcceso { set; get; }

        public Administrador(string usuario, string contrasenia, string nombre, string apellidos, DateTime ultimoAcceso)
        {
            Usuario = usuario;
            Contrasenia = contrasenia;
            Nombre = nombre;
            Apellidos = apellidos;
            UltimoAcceso = ultimoAcceso;
        }
        public Administrador(string usuario, string contrasenia, string nombre, string apellidos)
        {
            Usuario = usuario;
            Contrasenia = contrasenia;
            Nombre = nombre;
            Apellidos = apellidos;
            UltimoAcceso = DateTime.Now;
        }
    }
}