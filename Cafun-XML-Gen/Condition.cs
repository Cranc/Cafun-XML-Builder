using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafun_XML_Gen
{
    /// <summary>
    /// enum that contains the different scope types.
    /// </summary>
    public enum SCOPE { NORTH_WEST = 0, NORTH, NORTH_EAST, EAST, SOUTH_EAST, SOUTH, SOUTH_WEST, WEST }
    /// <summary>
    /// public class that represents conditions of cafun.
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// contains cell type as String (default null).
        /// </summary>
        public String cell_type { get; set; }
        /// <summary>
        /// contains min value as String (default null).
        /// </summary>
        public String min { get; set; }
        /// <summary>
        /// contains max value as String (default null).
        /// </summary>
        public String max { get; set; }
        /// <summary>
        /// contains the list of scopes this condition uses (default null).
        /// </summary>
        public List<SCOPE> scope { get; set; }
        /// <summary>
        /// constructor, initilizes object with the right default values.
        /// </summary>
        public Condition()
        {
            cell_type = null;
            min = null;
            max = null;
            scope = null;
        }
        /// <summary>
        /// generates a XmL condition out of the object
        /// </summary>
        /// <returns>String with condition as String (gets called by Mutation class)</returns>
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
        /// <summary>
        /// end tag
        /// </summary>
        /// <returns>returns end tag as String</returns>
        private String getEndTag()
        {
            return "</condition>";
        }
    }
}
