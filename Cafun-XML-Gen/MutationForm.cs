using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Cafun_XML_Gen
{
    /// <summary>
    /// public class that represents the mutation form
    /// </summary>
    public partial class MutationForm : Form
    {
        private Regex reg;
        /// <summary>
        /// contains a mutation object given by the parent form.
        /// </summary>
        public Mutation my_mutation { get; private set; }
        /// <summary>
        /// default consturctor
        /// </summary>
        public MutationForm()
        {
            InitializeComponent();
            my_mutation = new Mutation();
            Init();
        }
        /// <summary>
        /// constructor for already existing mutations.
        /// </summary>
        /// <param name="mut">Mutation that is loaded in this form</param>
        public MutationForm(Mutation mut)
        {
            InitializeComponent();
            this.buttonAdd.Text = "Change";
            my_mutation = mut;
            Init();
            try
            {
                this.textBoxName.Text = mut.name;
                this.textBoxCell.Text = mut.cell_type;
                this.textBoxProb.Text = mut.probability;
                this.checkRadioButton(mut.priority);
            }catch (Exception e)
            {

            }
        }
        private void Init()
        {
            reg = new Regex(@"^[0][.]?[0-9]*$|^[1]$");//matches everything from 0.0 -> 1
            this.toolTipName.SetToolTip(this.labelName, "Defines the name the mutation shows up in the list box (optional).");
            this.toolTipCellType.SetToolTip(this.labelCell, "Defines the cell-type the cell will change to.");
            this.toolTipProbability.SetToolTip(this.labelProb, "Defines the probability of the mutation happening (optional).");
            this.toolTipPriotity.SetToolTip(this.labelprio, "Defines the Priority of the mutation" +
                "(<!ATTLIST mutation priority (top | very-high | high | medium | default | low | very - low | lowest) \"default\" >).");
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
            if (celltype)
            {
                my_mutation.cell_type = this.textBoxCell.Text;
                my_mutation.priority = this.checkedRadioButton();

                if(probability)
                    my_mutation.probability = this.textBoxProb.Text;
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
        /// <summary>
        /// Takes a priority and checks the right radiobutton.
        /// </summary>
        /// <param name="prioity">PRIORITY to check radio buton for.</param>
        private void checkRadioButton(PRIORITY prioity)
        {
            switch (prioity)
            {
                case PRIORITY.default_: this.radioButtonDefault.Checked = true;  break;
                case PRIORITY.high: this.radioButtonHigh.Checked = true; break;
                case PRIORITY.low: this.radioButtonLow.Checked = true; break;
                case PRIORITY.lowest: this.radioButtonLowest.Checked = true; break;
                case PRIORITY.medium: this.radioButtonMedium.Checked = true; break;
                case PRIORITY.top: this.radioButtontop.Checked = true; break;
                case PRIORITY.very_high: this.radioButtonVeryHigh.Checked = true; break;
                case PRIORITY.very_low: this.radioButtonVeryLow.Checked = true; break;
                default: this.radioButtonDefault.Checked = true; break;
            }
        }
        /// <summary>
        /// checks if the type of input is allowed
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void textBoxProb_TextChanged(object sender, EventArgs e)
        {
            if (!reg.IsMatch(this.textBoxProb.Text))
            {
                this.textBoxProb.Text = this.textBoxProb.Text.Substring(0, this.textBoxProb.Text.Length - 1);
                this.textBoxProb.Select(0, this.textBoxProb.Text.Length);
            }
        }
    }
}
