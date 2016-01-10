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
    public partial class MutationForm : Form
    {
        public Mutation my_mutation { get; set; }

        public MutationForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool name = false;
            bool celltype = false;
            bool probability = false;

            if (!this.textBoxName.Text.Equals(""))
                name = true;

            if (!this.textBoxCell.Text.Equals(""))
                celltype = true;

            if (!this.textBoxProb.Text.Equals(""))
                probability = true;

            if (celltype && probability)
            {
                my_mutation.cell_type = this.textBoxCell.Text;
                my_mutation.probability = this.textBoxProb.Text;
                my_mutation.priority = this.checkedRadioButton();

                if (name)
                    my_mutation.name = this.textBoxName.Text;
                else
                    my_mutation.name = null;

                this.DialogResult = DialogResult.OK;
            }
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private PRIORITY checkedRadioButton()
        {
            if (this.radioButtonDefault.Checked)
                return PRIORITY.default_;
            if (this.radioButtonHigh.Checked)
                return PRIORITY.high;
            if (this.radioButtonLow.Checked)
                return PRIORITY.low;
            if (this.radioButtonLowest.Checked)
                return PRIORITY.lowest;
            if (this.radioButtonMedium.Checked)
                return PRIORITY.medium;
            if (this.radioButtontop.Checked)
                return PRIORITY.top;
            if (this.radioButtonVeryHigh.Checked)
                return PRIORITY.very_high;
            if (this.radioButtonVeryLow.Checked)
                return PRIORITY.very_low;

            return PRIORITY.default_;
        }
    }
}
