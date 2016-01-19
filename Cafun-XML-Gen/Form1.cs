using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Deployment;

namespace Cafun_XML_Gen
{
    public partial class Form1 : Form
    {
        private List<Cell> list_cells;

        public Form1()
        {
            InitializeComponent();
            // myLists
            list_cells = new List<Cell>();
        }
        // button-events
        private void buttonAddMut_Click(object sender, EventArgs e)
        {
            int index = this.listBoxCells.SelectedIndex;
            if (index != -1)
            {
                MutationForm form = new MutationForm();
                Mutation parent_mut = new Mutation();
                form.my_mutation = parent_mut;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Mutation myMutation = form.my_mutation;
                    if (myMutation == null)
                    {
                        this.errorMessages("somehow the mutation object was empty, try again.");
                    }else
                        this.list_cells[index].mutations.Add(myMutation);
                }
            }
            else
                this.errorMessages("no Cell was selected");
            this.listBoxCells_SelectedIndexChanged(null, null);
        }

        private void buttonDeleteMut_Click(object sender, EventArgs e)
        {
            int index = this.listBoxMutations.SelectedIndex;

            if (index != -1)
            {
                this.listBoxMutations.Items.RemoveAt(index);
                this.list_cells[this.listBoxCells.SelectedIndex].mutations.RemoveAt(index);
            }
            else
                errorMessages("you need to select a mutation");
        }

        private void buttonAddCell_Click(object sender, EventArgs e)
        {
            CellForm form = new CellForm();
            Cell parent_cell = new Cell();
            form.my_cell = parent_cell;
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                Cell myCell = form.my_cell;
                if (myCell == null)
                {
                    this.errorMessages("somehow the cell object was empty, try again.");
                }
                else
                {
                    this.listBoxCells.Items.AddRange(new object[] { (myCell.cell_name + " " + myCell.cell_color) });
                    this.list_cells.Add(myCell);
                }
            }
        }

        private void buttonDeleteCell_Click(object sender, EventArgs e)
        {
            int index = this.listBoxCells.SelectedIndex;

            if (index != -1)
            {
                this.listBoxCells.Items.RemoveAt(index);
                this.list_cells.RemoveAt(index);
            }
            else
                errorMessages("you need to select a cell");
        }

        private void buttonAddCon_Click(object sender, EventArgs e)
        {
            int indexCell = this.listBoxCells.SelectedIndex;
            int indexMut = this.listBoxMutations.SelectedIndex;

            if (indexCell != -1 && indexMut != -1)
            {
                ConditionForm form = new ConditionForm();
                Condition parent_condition = new Condition();
                form.my_condition = parent_condition;
                form.ShowDialog();

                //stuff after finish here

                if (form.DialogResult == DialogResult.OK)
                {
                    Condition myCon = form.my_condition;
                    if (myCon != null)
                        this.list_cells[indexCell].mutations[indexMut].conditons.Add(myCon);
                    else
                        this.errorMessages("somehow the condition object was empty, try again.");
                }
            }
            else
                errorMessages("you need to select a cell and mutation.");

            this.listBoxMutations_SelectedIndexChanged(null, null);
        }

        private void buttonDeleteCon_Click(object sender, EventArgs e)
        {
            int indexCell = this.listBoxCells.SelectedIndex;
            int indexMut = this.listBoxMutations.SelectedIndex;
            int indexCon = this.listBoxConditions.SelectedIndex;

            if (indexCell != -1 && indexMut != -1 && indexCon != -1)
            {
                this.list_cells[indexCell].mutations[indexMut].conditons.RemoveAt(indexCon);
                listBoxMutations_SelectedIndexChanged(null, null);
            }
            else
                errorMessages("you need to select a condition.");
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            WriteForm form = new WriteForm();
            form.ShowDialog();


            if(form.DialogResult == DialogResult.OK)
            {
                var name = form.name;
                var author = form.author;
                var xml_descritpion = form.xml_description;
                String xml = "<simulation name=\"" + name + "\" author=\"" + author + "\">";

                xml += xml_descritpion;
                foreach (Cell c in list_cells)
                {
                    c.to_XML();
                    xml += c.xml;
                }

                //here charts

                //end tag
                xml += "</simulation>";

                xml = formatXml(xml);

                string path;

                path = Path.Combine(Environment.CurrentDirectory, "xml_files");

                Directory.CreateDirectory(path);

                if (!name.Equals(""))
                    path = Path.Combine(Environment.CurrentDirectory, "xml_files", name + ".xml");
                else
                    path = Path.Combine(Environment.CurrentDirectory, "xml_files", "XMLTEST.xml");

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

        private void errorMessages(String msg)
        {
            MessageBox.Show(msg);
        }

        //Change events

        private void listBoxConditions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxMutations_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexCell = this.listBoxCells.SelectedIndex;
            int indexMut = this.listBoxMutations.SelectedIndex;

            this.listBoxConditions.Items.Clear();

            if (indexCell != -1 && indexMut != -1)
            {
                foreach (Condition c in this.list_cells[indexCell].mutations[indexMut].conditons)
                {
                    this.listBoxConditions.Items.Add(c.cell_type + " max:" + c.max + " min:" + c.min);
                }
            }
        }

        private void listBoxCells_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listBoxCells.SelectedIndex;

            this.listBoxMutations.Items.Clear();

            if (index != -1)
            {
                List<Mutation> list_mut = this.list_cells[index].mutations;
                foreach (Mutation m in list_mut)
                {
                    if (m.name != null)
                        this.listBoxMutations.Items.Add(m.name);
                    else
                        this.listBoxMutations.Items.Add(m.cell_type + m.probability + m.priority);
                }
            }
        }

    }
}
