using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafun_XML_Gen
{
    public enum PRIORITY { top = 0, very_high, high, medium, default_, low, very_low, lowest};
    public class Mutation
    {

        public Mutation()
        {
            name = null;
            cell_type = null;
            probability = null;
            priority = PRIORITY.default_;
            conditons = new List<Condition>();
        }

        public String name { get; set; }
        public String cell_type { get; set; }
        public String probability { get; set; }
        public PRIORITY priority { get; set; }
        public List<Condition> conditons { get; set; }

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
                default: throw new Exception("can´t define priority!");
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
