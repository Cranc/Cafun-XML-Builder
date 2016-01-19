﻿using System;
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
    /// public class that represents the Form for condition creation (is called by main form).
    /// </summary>
    public partial class ConditionForm : Form
    {
        /// <summary>
        /// constructor, initilizes object with default values for my_condition
        /// </summary>
        public ConditionForm()
        {
            InitializeComponent();
            my_condition = null;
        }
        /// <summary>
        /// contains an object of condition (default null, has to be set by caller)
        /// </summary>
        public Condition my_condition { get; set; }
        /// <summary>
        /// function is called on "Add" button click. Checks if all inputs are made 
        /// and on correct input closes form and sends a sucess message.
        /// </summary>
        /// <param name="sender">contains object of sender</param>
        /// <param name="e">contains event</param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool type;
            type = false;
            if (my_condition != null)
            {
                if (!this.textBoxcelltype.Text.Equals(""))
                {
                    this.my_condition.cell_type = this.textBoxcelltype.Text;
                    type = true;
                }
                if (!this.textBoxMin.Text.Equals(""))
                {
                    this.my_condition.min = this.textBoxMin.Text;
                }
                if (!this.textBoxMax.Text.Equals(""))
                {
                    this.my_condition.max = this.textBoxMax.Text;
                }

                List<SCOPE> myList = getScopes();
                if (myList.Count > 0)
                {
                    my_condition.scope = myList;
                }

                if (type)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
                MessageBox.Show("there was no condition object for this windows close and try again.");
        }
        /// <summary>
        /// checks what checkboxes are checked, converts them to SCOPE enum and returns results.
        /// </summary>
        /// <returns>returns a list of SCOPE</returns>
        private List<SCOPE> getScopes()
        {
            List<SCOPE> scopes = new List<SCOPE>();

            if (this.checkBoxEast.Checked)
                scopes.Add(SCOPE.EAST);
            if (this.checkBoxNorth.Checked)
                scopes.Add(SCOPE.NORTH);
            if (this.checkBoxNorthEast.Checked)
                scopes.Add(SCOPE.NORTH_EAST);
            if (this.checkBoxNorthWest.Checked)
                scopes.Add(SCOPE.NORTH_WEST);
            if (this.checkBoxSouth.Checked)
                scopes.Add(SCOPE.SOUTH);
            if (this.checkBoxSouthEast.Checked)
                scopes.Add(SCOPE.SOUTH_EAST);
            if (this.checkBoxSouthWest.Checked)
                scopes.Add(SCOPE.SOUTH_WEST);
            if (this.checkBoxWest.Checked)
                scopes.Add(SCOPE.WEST);

            return scopes;
        }
        /// <summary>
        /// function gets called on cancel button click and closes the form with cancel message
        /// </summary>
        /// <param name="sender">contains object of sender</param>
        /// <param name="e">contains event</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
