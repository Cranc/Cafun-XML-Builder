using System;
using System.Collections.Generic;

namespace Cafun_XML_Gen
{
    /// <summary>
    /// public enum displaying the different prioritys of cafun mutations
    /// </summary>
    public enum PRIORITY { top = 0, very_high, high, medium, default_, low, very_low, lowest};
    /// <summary>
    /// public class that represents mutations.
    /// </summary>
    public class Mutation
    {
        /// <summary>
        /// public default consturctor initilizes all values.
        /// </summary>
        public Mutation()
        {
            name = null;
            cell_type = null;
            probability = null;
            priority = PRIORITY.default_;
            conditons = new List<Condition>();
        }
        /// <summary>
        /// String contains (optional) name of the mutation object.
        /// </summary>
        public String name { get; set; }
        /// <summary>
        /// String that contains the cell_type.
        /// </summary>
        public String cell_type { get; set; }
        /// <summary>
        /// String that contains the probability.
        /// </summary>
        public String probability { get; set; }
        /// <summary>
        /// String that contains the priority.
        /// </summary>
        public PRIORITY priority { get; set; }
        /// <summary>
        /// List of conditions that contains all conditions assoziated with this mutation.
        /// </summary>
        public List<Condition> conditons { get; set; }

        /// <summary>
        /// function that turns this class into cafun Xml is called by Cell class (no need to call it ourselfs)
        /// </summary>
        /// <returns>String that contains the object as Xml.</returns>
        public String toXML()
        {
            String mystr = "<mutation cell-type=\"" + cell_type + "\"";
            if(probability != null)
                mystr += " probability=\"" + probability + "\"";

            switch (priority)
            {
                case PRIORITY.default_: break;
                case PRIORITY.high: mystr += " priority=\"high\""; break;
                case PRIORITY.low: mystr += " priority=\"high\""; break;
                case PRIORITY.lowest: mystr += " priority=\"high\""; break;
                case PRIORITY.medium: mystr += " priority=\"high\""; break;
                case PRIORITY.top: mystr += " priority=\"high\""; break;
                case PRIORITY.very_high: mystr += " priority=\"high\""; break;
                case PRIORITY.very_low: mystr += " priority=\"high\""; break;
                default: break;
            }

            mystr += ">";

            foreach (Condition c in conditons)
            {
                mystr += c.toXML();
            }

            mystr += getEndTag();

            return mystr;
        }

        private String getEndTag()
        {
            return "</mutation>";
        }
    }
}
