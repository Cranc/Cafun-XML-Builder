using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafun_XML_Gen
{
    public enum SCOPE { NORTH_WEST = 0, NORTH, NORTH_EAST, EAST, SOUTH_EAST, SOUTH, SOUTH_WEST, WEST }
    public class Condition
    {
        public String cell_type { get; set; }
        public String min { get; set; }
        public String max { get; set; }
        public List<SCOPE> scope { get; set; }

        public Condition()
        {
            cell_type = null;
            min = null;
            max = null;
            scope = null;
        }

        public String toXML()
        {
            String mystr = "<condition cell-type=\"" + cell_type + "\"";

            if (min != null)
                mystr += " min=\"" + min + "\"";

            if (max != null)
                mystr += " max=\"" + max + "\"";

            if (scope != null) {
                mystr += " scope=\"";
                scope.ForEach(delegate (SCOPE s)
                {
                    switch (s)
                    {
                        case SCOPE.EAST: mystr += "east "; break;
                        case SCOPE.NORTH: mystr += "north "; break;
                        case SCOPE.NORTH_EAST: mystr += "north-east "; break;
                        case SCOPE.NORTH_WEST: mystr += "north-west "; break;
                        case SCOPE.SOUTH: mystr += "south "; break;
                        case SCOPE.SOUTH_EAST: mystr += "south-east "; break;
                        case SCOPE.SOUTH_WEST: mystr += "south-west "; break;
                        case SCOPE.WEST: mystr += "west "; break;
                    }
                });
                mystr.Remove(0, mystr.Length - 1);
                mystr += "\"";
            }

            mystr += ">";
            mystr += getEndTag();

            return mystr;
        }

        private String getEndTag()
        {
            return "</condition>";
        }
    }
}
