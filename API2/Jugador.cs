using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA_Analyzer.API
{
    internal class Jugador
    {
        public Jugador() { 
        }
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set;}
        public string position { get; set; }
        public Int32 height_feet { get; set; }
        public Int32 height_inches { get; set;}
        public Int32 weigth_pounds { get;set;}
        public Team equipo { get; set; }
    }
}
