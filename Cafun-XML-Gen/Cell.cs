using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafun_XML_Gen
{
    public class Cell
    {
        //private String name = null;
        //private String color = null;

        public String cell_name { get; set; }
        public String cell_color { get; set; }
        public String to_XML()
        {
            return "<cell-type=\"" + cell_name + "\" color=\"" + cell_color + "\">";
        }
        public String getEndTag()
        {
            return "</cell-type>";
        }
    }
}
