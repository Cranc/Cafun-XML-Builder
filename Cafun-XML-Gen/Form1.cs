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
        private List<Mutation> list_mutations;
        private List<Condition> list_conditions;

        public Form1()
        {
            InitializeComponent();
            // my Lists
            list_cells = new List<Cell>();
            list_mutations = new List<Mutation>();
            list_conditions = new List<Condition>();
        }

        private void buttonAddMut_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddCell_Click(object sender, EventArgs e)
        {
            CellForm form = new CellForm();
            Cell parent_cell = new Cell();
            form.Show();
            this.buttonAddCell.Enabled = false;
            form.my_cell = parent_cell;
            form.my_parent = this;
        }

        public void CellChildClosed(bool isokay, Cell myCell)
        {
            if (isokay)
            {
                if(myCell == null)
                {
                    throw new Exception("Cell was empty");
                }
                this.listBoxCells.Items.AddRange(new object[] { (myCell.cell_name + " " + myCell.cell_color) });
                this.list_cells.Add(myCell);
            }
            this.buttonAddCell.Enabled = true;
        }

        private void buttonDeleteCell_Click(object sender, EventArgs e)
        {
            int index = this.listBoxCells.SelectedIndex;
            if (index != -1)

                this.listBoxCells.Items.RemoveAt(index);
        }
    }
}
