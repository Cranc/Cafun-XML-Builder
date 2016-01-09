using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Cafun_XML_Gen
{
    public partial class CellForm : Form
    {
        private String color_pattern = @"^[0-9]{1,3}$";
        public CellForm()
        {
            InitializeComponent();
        }

        private String match_single_RGB(String str)
        {
            Regex regex = new Regex(color_pattern, RegexOptions.None);
            MatchCollection match = regex.Matches(str);

            if (match.Count == 1)
            {
                //check for value
                int i = Int32.Parse(str.ToString());
                if (i > 255 || i < 0)
                {
                    //throw new Exception("not in RGB Range (0 - 255)");
                    return "Range";
                }
                //add to string
                return str;
            }
            return null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool name = false;
            bool color = true;
            lableError.Text = "";
            if(my_cell != null)
            {
                if (!this.textBoxName.Text.Equals(""))
                {
                    my_cell.cell_name = this.textBoxName.Text;
                    name = true;
                }

                // here check with regex 
                String red = this.match_single_RGB(this.textBoxColorRed.Text);
                String green = this.match_single_RGB(this.textBoxColorGreen.Text);
                String blue = this.match_single_RGB(this.textBoxColorBlue.Text);

                //red
                if (red == null)
                {
                    this.lableError.Text += "R is not a valid number (0 - 255) ";
                    color = false;
                }
                else
                {
                    if (red.Contains("Range"))
                    {
                        this.lableError.Text += "R not in RGB Range (0 - 255) ";
                        color = false;
                    }
                }
                //green
                if (green == null)
                {
                    this.lableError.Text += "G is not a valid number (0 - 255) ";
                    color = false;
                }
                else
                {
                    if (green.Contains("Range"))
                    {
                        this.lableError.Text += "G not in RGB Range (0 - 255) ";
                        color = false;
                    }
                }
                //blue
                if (blue == null)
                {
                    this.lableError.Text += "B is not a valid number (0 - 255) ";
                    color = false;
                }
                else
                {
                    if (blue.Contains("Range"))
                    {
                        this.lableError.Text += "B not in RGB Range (0 - 255) ";
                        color = false;
                    }
                }

                if (color)
                    my_cell.cell_color = red + " " + green + " " + blue;
            }

            if(name && color)
            {
                //send parent information here
                my_parent.CellChildClosed(true, my_cell);
                this.Close();
            }
                
        }

        public Cell my_cell { get; set; }
        public Form1 my_parent { get; set; }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //send parent information here
            my_parent.CellChildClosed(false, null);
            this.Close();
        }
    }
}
