using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA_Analyzer.API
{
    public class Jugador
    {

        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string position { get; set; }
        public Int32 height_feet { get; set; }
        public Int32 height_inches { get; set; }
        public Int32 weigth_pounds { get; set; }
        public Team equipo { get; set; }


        public Jugador(string id_, string first_name_, string last_name_, string position_, Int32 height_feet_, Int32 height_inches_, Int32 weigth_pounds_, Team equipo_)
        {
            id = id_;
            first_name = first_name_;
            last_name = last_name_;
            position = position_;
            height_feet = height_feet;
            height_inches = height_inches_;
            weigth_pounds = weigth_pounds_;
            equipo = equipo_;

        }
    }
}
