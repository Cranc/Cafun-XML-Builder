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
    public partial class Form1 : Form
    {
        private List<Cell> list_cells;

        public Form1()
        {
            InitializeComponent();
            // myLists
            list_cells = new List<Cell>();
        }

        private void buttonAddMut_Click(object sender, EventArgs e)
        {
            int index = this.listBoxCells.SelectedIndex;
            if (index != -1)
            {
                MutationForm form = new MutationForm();
                Mutation parent_mut = new Mutation();
                form.my_mutation = parent_mut;
                form.ShowDialog();
                if(form.DialogResult == DialogResult.OK)
                {
                    Mutation myMutation = form.my_mutation;
                    if (myMutation == null)
                    {
                        throw new Exception("Mutation was empty");
                    }
                    this.list_cells[index].mutations.Add(myMutation);
                }
            }
            else
                throw new Exception("no selected cell");
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
                    throw new Exception("Cell was empty");
                }
                this.listBoxCells.Items.AddRange(new object[] { (myCell.cell_name + " " + myCell.cell_color) });
                this.list_cells.Add(myCell);
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
