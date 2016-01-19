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
    /// <summary>
    /// public class that represents the mutation form
    /// </summary>
    public partial class MutationForm : Form
    {
        /// <summary>
        /// contains a mutation object given by the parent form.
        /// </summary>
        public Mutation my_mutation { get; set; }
        /// <summary>
        /// default consturctor
        /// </summary>
        public MutationForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// function reacts on add button click, cheks if needed values are given and adds them to the mutation object.
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool name = false;
            bool celltype = false;
            bool probability = false;

            //check for not empty text boxes
            if (!this.textBoxName.Text.Equals(""))
                name = true;
            if (!this.textBoxCell.Text.Equals(""))
                celltype = true;

            if (!this.textBoxProb.Text.Equals(""))
                probability = true;
            //add to object and end with sucess
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
        /// <summary>
        /// function react on cancle button click and closes the form with cancel message for parent.
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// function checks which radio button is checked.
        /// </summary>
        /// <returns>PRIORITY equivalent the button</returns>
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
