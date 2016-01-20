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
        /// <summary>
        /// String that contains the Regex for defining part of the color pattern.
        /// </summary>
        private String color_pattern = @"^[0-9]{1,3}$";
        /// <summary>
        /// Contains the cell used by this form.
        /// </summary>
        public Cell my_cell { get; set; }

        public CellForm()
        {
            InitializeComponent();
            toolTipName.SetToolTip(this.labelName, "Name of the cell-type");
            toolTipColor.SetToolTip(this.labelColor, "Decimal RGB value of the color used by this cell-type");
            toolTipChart.SetToolTip(this.checkBoxChart, "Makes sure this cell will be added to the Cafun chart");
        }

        /// <summary>
        /// takes a String and checks if the String contains a decimal RGB part. (0-255)
        /// </summary>
        /// <param name="str">contains String to check</param>
        /// <returns>returns 0, when String does not contain 1-3 digits. returns "Range" when value is not within range of 0-255, else returns the String</returns>
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
        /// <summary>
        /// function that reactes on Add Cell button click, extracts the Information out of the form and signlas Main Form sucess before closing it.
        /// </summary>
        /// <param name="sender">contains send object</param>
        /// <param name="e">contains event</param>
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

                if (this.checkBoxChart.Checked)
                    my_cell.chart = true;

                // here check with regex 
                String red = this.match_single_RGB(this.textBoxColorRed.Text);
                String green = this.match_single_RGB(this.textBoxColorGreen.Text);
                String blue = this.match_single_RGB(this.textBoxColorBlue.Text);

                //red
                if (red == null)
                {
                    //this.lableError.Text += "R is not a valid number (0 - 255) ";
                    color = false;
                }
                else
                {
                    if (red.Contains("Range"))
                    {
                        //this.lableError.Text += "R not in RGB Range (0 - 255) ";
                        color = false;
                    }
                }
                //green
                if (green == null)
                {
                    //this.lableError.Text += "G is not a valid number (0 - 255) ";
                    color = false;
                }
                else
                {
                    if (green.Contains("Range"))
                    {
                        //this.lableError.Text += "G not in RGB Range (0 - 255) ";
                        color = false;
                    }
                }
                //blue
                if (blue == null)
                {
                    //this.lableError.Text += "B is not a valid number (0 - 255) ";
                    color = false;
                }
                else
                {
                    if (blue.Contains("Range"))
                    {
                        //this.lableError.Text += "B not in RGB Range (0 - 255) ";
                        color = false;
                    }
                }

                if (color)
                    my_cell.cell_color = red + " " + green + " " + blue;
            }

            if(name && color)
            {
                //send parent information here
                this.DialogResult = DialogResult.OK;
            }
                
        }
        /// <summary>
        /// function that cancles the action and closes the form.
        /// </summary>
        /// <param name="sender">contains send object</param>
        /// <param name="e">contains event</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //send parent information here
            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// function checks if entered digit is a valid for this textbox
        /// </summary>
        /// <param name="sender">send object</param>
        /// <param name="e">event arguments</param>
        private void textBoxColorRed_TextChanged(object sender, EventArgs e)
        {
            String res = match_single_RGB(this.textBoxColorRed.Text);
            if(res == null || res.Equals("Range"))
            {
                this.textBoxColorRed.Text = this.textBoxColorRed.Text.Substring(0, this.textBoxColorRed.Text.Length - 1);
            }
        }
        /// <summary>
        /// function checks if entered digit is a valid for this textbox
        /// </summary>
        /// <param name="sender">send object</param>
        /// <param name="e">event arguments</param>
        private void textBoxColorGreen_TextChanged(object sender, EventArgs e)
        {
            String res = match_single_RGB(this.textBoxColorGreen.Text);
            if (res == null || res.Equals("Range"))
            {
                this.textBoxColorGreen.Text = this.textBoxColorGreen.Text.Substring(0, this.textBoxColorGreen.Text.Length - 1);
            }
        }
        /// <summary>
        /// function checks if entered digit is a valid for this textbox
        /// </summary>
        /// <param name="sender">send object</param>
        /// <param name="e">event arguments</param>
        private void textBoxColorBlue_TextChanged(object sender, EventArgs e)
        {
            String res = match_single_RGB(this.textBoxColorBlue.Text);
            if (res == null || res.Equals("Range"))
            {
                this.textBoxColorBlue.Text = this.textBoxColorBlue.Text.Substring(0, this.textBoxColorBlue.Text.Length - 1);
                this.textBoxColorBlue.Select(0,this.textBoxColorBlue.Text.Length);
            }
        }
    }
}
