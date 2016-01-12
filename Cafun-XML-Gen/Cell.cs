using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafun_XML_Gen
{
    public class Cell
    {
        //<cell-type id="IsotopeA" color="200 255 255">
        //private String name = null;
        //private String color = null;

        public String cell_name { get; set; }
        public String cell_color { get; set; }
        public List<Mutation> mutations { get; set; }

        public Cell()
        {
            mutations = new List<Mutation>();
            cell_name = null;
            cell_color = null;
        }

        public String to_XML()
        {
            return "<cell-type id=\"" + cell_name + "\" color=\"" + cell_color + ">";
        }
        public String getEndTag()
        {
            return "</cell-type>";
        }
    }
}
