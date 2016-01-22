using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cafun_XML_Gen
{
    /// <summary>
    /// public form class contains main window and all functions for buttons
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// hidden List, contains cells mirrors the visible boxlist for cells
        /// </summary>
        private List<Cell> list_cells;
        /// <summary>
        /// consturctor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            // myLists
            list_cells = new List<Cell>();
        }
        // button-events
        /// <summary>
        /// function reacts on add mutation button click, creates a new mutation object opens the mutation form
        /// and on sucess of mutation form saves the mutation inside the cell.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonAddMut_Click(object sender, EventArgs e)
        {
            int index = this.listBoxCells.SelectedIndex;
            //check for selected cell
            if (index != -1)
            {
                //create and show mutation form
                MutationForm form = new MutationForm();
                form.ShowDialog();
                //check for sucess and save mutation
                if (form.DialogResult == DialogResult.OK)
                {
                    Mutation myMutation = form.my_mutation;
                    if (myMutation == null)
                    {
                        this.errorMessages("Somehow the mutation object was empty, try again.");
                    }else
                        this.list_cells[index].mutations.Add(myMutation);
                }
            }
            else
                this.errorMessages("No cell was selected!");
            // update lists
            this.listBoxCells_SelectedIndexChanged(null, null);
        }
        /// <summary>
        /// function opens MutationForm with slected Mutation to change its values
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonChangeMut_Click(object sender, EventArgs e)
        {
            int index = this.listBoxCells.SelectedIndex;
            int indexmut = this.listBoxMutations.SelectedIndex;
            //check for selected cell
            if (index != -1 && indexmut != -1)
            {
                //create and show mutation form
                MutationForm form = new MutationForm(this.list_cells[index].mutations[indexmut]);
                form.ShowDialog();
                //check for sucess and save mutation
                if (form.DialogResult == DialogResult.OK)
                {
                    Mutation myMutation = form.my_mutation;
                    if (myMutation == null)
                    {
                        this.errorMessages("Somehow the mutation object was empty, try again.");
                    }
                    else
                    {
                        this.list_cells[index].mutations.RemoveAt(indexmut);
                        this.list_cells[index].mutations.Add(myMutation);
                        this.listBoxCells_SelectedIndexChanged(null, null);
                    }
                }
            }
            else
                this.errorMessages("No cell and mutation was selected!");
        }
        /// <summary>
        /// function reacts on delete mutation button click and removes the mutation from the listbox and the hidden list.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonDeleteMut_Click(object sender, EventArgs e)
        {
            int index = this.listBoxMutations.SelectedIndex;
            //check for selected mutation
            if (index != -1)
            {
                this.listBoxMutations.Items.RemoveAt(index);
                this.list_cells[this.listBoxCells.SelectedIndex].mutations.RemoveAt(index);
            }
            else
                errorMessages("You need to select a mutation!");
        }
        /// <summary>
        /// function reacts on add cell button click, creates a new cell from and on sucess of that form saves the cell
        /// in the hidden list and the list box.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonAddCell_Click(object sender, EventArgs e)
        {
            CellForm form = new CellForm();
            form.ShowDialog();
            //check for sucess
            if (form.DialogResult == DialogResult.OK)
            {
                Cell myCell = form.my_cell;
                if (myCell == null)
                {
                    this.errorMessages("Somehow the cell object was empty, try again.");
                }
                else
                {
                    this.listBoxCells.Items.AddRange(new object[] { (myCell.cell_name + " " + myCell.cell_color) });
                    this.list_cells.Add(myCell);
                }
            }
        }
        /// <summary>
        /// function opens CellForm window with selected Cell to change data of cell.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonChangeCell_Click(object sender, EventArgs e)
        {
            int index = this.listBoxCells.SelectedIndex;
            if (index != -1)
            {
                CellForm form = new CellForm(list_cells[index]);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    Cell myCell = form.my_cell;
                    if (myCell == null)
                    {
                        this.errorMessages("Somehow the cell object was empty, try again.");
                    }
                    else
                    {
                        this.listBoxCells.Items.RemoveAt(index);
                        this.list_cells.RemoveAt(index);
                        this.listBoxCells.Items.AddRange(new object[] { (myCell.cell_name + " " + myCell.cell_color) });
                        this.list_cells.Add(myCell);
                    }
                }
            }
            else
            {
                this.errorMessages("You need to select a Cell to change it!");
            }
        }
        /// <summary>
        /// function reacts on delete cell button click and removes the entire cell from the hidden list and the listbox.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonDeleteCell_Click(object sender, EventArgs e)
        {
            int index = this.listBoxCells.SelectedIndex;
            //check for selected index
            if (index != -1)
            {
                this.listBoxCells.Items.RemoveAt(index);
                this.list_cells.RemoveAt(index);
            }
            else
                errorMessages("You need to select a cell!");
        }
        /// <summary>
        /// function reacts on add condition button click, creates a condition and form and on sucess
        /// saves condition in the selected mutation of the selected cell.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonAddCon_Click(object sender, EventArgs e)
        {
            int indexCell = this.listBoxCells.SelectedIndex;
            int indexMut = this.listBoxMutations.SelectedIndex;

            if (indexCell != -1 && indexMut != -1)
            {
                //create form
                ConditionForm form = new ConditionForm();
                form.ShowDialog();

                //check for sucess
                if (form.DialogResult == DialogResult.OK)
                {
                    Condition myCon = form.my_condition;
                    if (myCon != null)
                        this.list_cells[indexCell].mutations[indexMut].conditons.Add(myCon);
                    else
                        this.errorMessages("Somehow the condition object was empty, try again.");
                }
            }
            else
                errorMessages("You need to select a cell and mutation!");
            //update listbox
            this.listBoxMutations_SelectedIndexChanged(null, null);
        }
        /// <summary>
        /// function that opens Condition Form with selected Condition Information.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonChangeCon_Click(object sender, EventArgs e)
        {
            int index_c = this.listBoxCells.SelectedIndex;
            int index_m = this.listBoxMutations.SelectedIndex;
            int index = this.listBoxConditions.SelectedIndex;

            if(index != -1 && index_c != -1 && index_m != -1)
            {
                ConditionForm form = new ConditionForm(this.list_cells[index_c].mutations[index_m].conditons[index]);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    Condition myCon = form.my_condition;
                    if (myCon != null)
                    {
                        this.list_cells[index_c].mutations[index_m].conditons.RemoveAt(index);
                        this.list_cells[index_c].mutations[index_m].conditons.Add(myCon);
                        this.listBoxMutations_SelectedIndexChanged(null, null);
                    }
                    else
                        this.errorMessages("Somehow the condition object was empty, try again.");
                }
            }
            else
            {
                this.errorMessages("You need to select a cell, mutation and condition!");
            }
        }
        /// <summary>
        /// function reacts on delete condition button click, checks for selected indexs and removes the condition form
        /// the hidden list and the list box.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonDeleteCon_Click(object sender, EventArgs e)
        {
            int indexCell = this.listBoxCells.SelectedIndex;
            int indexMut = this.listBoxMutations.SelectedIndex;
            int indexCon = this.listBoxConditions.SelectedIndex;
            //check for selected indices
            if (indexCell != -1 && indexMut != -1 && indexCon != -1)
            {
                this.list_cells[indexCell].mutations[indexMut].conditons.RemoveAt(indexCon);
                listBoxMutations_SelectedIndexChanged(null, null);
            }
            else
                errorMessages("You need to select a condition!");
        }
        /// <summary>
        /// function reacts on write button click, creates the write form and on sucess
        /// starts the XmL write and save to file process.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonWrite_Click(object sender, EventArgs e)
        {
            WriteForm form = new WriteForm();
            form.ShowDialog();

            // check for sucess
            if(form.DialogResult == DialogResult.OK)
            {
                //get information from write form and create the description head
                var name = form.name;
                var author = form.author;
                var xml_descritpion = form.xml_description;
                String xml = "<simulation name=\"" + name + "\" author=\"" + author + "\">";

                xml += xml_descritpion;

                //call for each cell in the hidden list the to_XML function (calls mutation and condition itself)
                foreach (Cell c in list_cells)
                {
                    c.to_XML();
                    xml += c.xml;
                }

                //here charts
                xml += "<chart>";
                foreach (Cell c in list_cells)
                {
                    if(c.chart)
                        xml += c.to_Chart();
                }
                xml += "</chart>";

                //add end tag end make the xml pretty
                xml += "</simulation>";
                xml = formatXml(xml);

                //create a path and create a direcetory (if it doesnt exist yet)
                string path;
                path = Path.Combine(Environment.CurrentDirectory, "xml_files");
                Directory.CreateDirectory(path);

                //if name given use that name as file name if not use default
                if (!name.Equals(""))
                    path = Path.Combine(Environment.CurrentDirectory, "xml_files", name + ".xml");
                else
                    path = Path.Combine(Environment.CurrentDirectory, "xml_files", "XMLTEST.xml");
                //write file to path
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                    File.WriteAllText(path, xml);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("There already exist a file with that name, do you want to overwrite it?", "Overwrite?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //overwrite here
                        File.Delete(path);
                        File.Create(path).Close();
                        File.WriteAllText(path, xml);
                    }
                }
            }
        }
        /// <summary>
        /// function takes a string and uses Xml Linq to prettyfy the Xml, when it can.
        /// </summary>
        /// <param name="xml">string that contains xml</param>
        /// <returns>returns a string with prettyfied Xml on sucess on failure returns given string</returns>
        private string formatXml(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                return doc.ToString();
            }
            catch (Exception)
            {
                return xml;
            }
        }
        /// <summary>
        /// function that creates a form to show error messages.
        /// </summary>
        /// <param name="msg">String that contains the text to display.</param>
        private void errorMessages(String msg)
        {
            MessageBox.Show(msg);
        }

        //change events
        /// <summary>
        /// function that reactes on changed selected index in listbox mutation, and updates the condition listbox
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void listBoxMutations_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexCell = this.listBoxCells.SelectedIndex;
            int indexMut = this.listBoxMutations.SelectedIndex;
            this.listBoxConditions.Items.Clear();

            //check for selected indizes and add the conditions into the listbox condition
            if (indexCell != -1 && indexMut != -1)
            {
                foreach (Condition c in this.list_cells[indexCell].mutations[indexMut].conditons)
                {
                    this.listBoxConditions.Items.Add(c.cell_type + " max:" + c.max + " min:" + c.min);
                }
            }
        }
        /// <summary>
        /// function that reacts on changed select index in listbox cell and updates the list box mutation
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void listBoxCells_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listBoxCells.SelectedIndex;
            this.listBoxMutations.Items.Clear();
            this.listBoxConditions.Items.Clear();

            //check for selected index and add all mutations of selected cell to the listbox mutation
            if (index != -1)
            {
                List<Mutation> list_mut = this.list_cells[index].mutations;
                foreach (Mutation m in list_mut)
                {
                    if (m.name != null)
                        this.listBoxMutations.Items.Add(m.name);
                    else
                        this.listBoxMutations.Items.Add(m.cell_type + " " + m.probability + " " + m.priority);
                }
            }
        }
    }
}
