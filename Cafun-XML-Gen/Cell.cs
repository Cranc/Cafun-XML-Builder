using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafun_XML_Gen
{
    /// <summary>
    /// Cell class contains information about a cell like name, color, and a list of mutations that belong to this cell
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// contains name of cell as String
        /// </summary>
        public String cell_name { get; set; }
        /// <summary>
        /// contains color of cell as String
        /// </summary>
        public String cell_color { get; set; }
        /// <summary>
        /// contains list of mutations
        /// </summary>
        public List<Mutation> mutations { get; set; }
        /// <summary>
        /// contains the xml code, after @to_XML() was called, as String
        /// </summary>
        public String xml { get; private set; }
        /// <summary>
        /// contains bool that defines if cell should be displayed in chart
        /// </summary>
        public bool chart { get; set; }
        /// <summary>
        /// Constructor initalizes cell default values
        /// </summary>
        public Cell()
        {
            mutations = new List<Mutation>();
            cell_name = null;
            cell_color = null;
            xml = null;
            chart = false;
        }
        /// <summary>
        /// to_XML() function calls the toXML function of its own mutations, generates a cafun usable XML code and safes it to @xml
        /// </summary>
        public void to_XML()
        {
            xml =  "<cell-type id=\"" + cell_name + "\" color=\"" + cell_color + "\"> \n";
            foreach (Mutation m in mutations)
            {
                xml += m.toXML();
            }
            getEndTag();
        }
        /// <summary>
        /// private function that adds the EndTag to @xml
        /// </summary>
        private void getEndTag()
        {
            xml +=  "</cell-type>";
        }
        /// <summary>
        /// function creates chart xml string out of objects values.
        /// </summary>
        /// <returns>String that contains xml usable code that represents chart entry</returns>
        public String to_Chart()
        {
            return "<indicator cell-type=\"" + cell_name + "\" color=\"" + cell_color + "\"/>";
        }
    }
}
