using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA_Analyzer.API
{
    public class Team
    {
        public string id { get; set; }
        public string abbreviation { get; set; }
        public string city { get; set; }
        public string conference { get; set; }
        public string division { get; set; }
        public string full_name { get; set; }
        public string name { get; set; }


        public Team(string id_,string abbreviation_, string city_, string conference_, string division_, string full_name_, string name_)
        {
            id= id_;
            abbreviation= abbreviation_;
            city= city_;
            conference= conference_;
            division= division_;
            full_name= full_name_;
            name= name_;
        }
    }

}
