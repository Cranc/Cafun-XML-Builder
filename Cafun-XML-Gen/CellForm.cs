using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafun_XML_Gen
{
    public partial class CellForm : Form
    {
        public CellForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool name = false;
            bool color = false;
            if(my_cell != null)
            {
                if (!this.textBoxName.Text.Equals(""))
                {
                    my_cell.cell_name = this.textBoxName.Text;
                    name = true;
                }
                    
                // here check with regex 
                if (this.textBoxColor.Text.Equals("255 255 255"))
                {
                    my_cell.cell_color = this.textBoxColor.Text;
                    color = true;
                }
                    
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
