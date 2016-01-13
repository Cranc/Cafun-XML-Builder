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
    public partial class WriteForm : Form
    {
        public WriteForm()
        {
            InitializeComponent();
        }

        public String xml_description { get; set; }
        public String name { get; set; }
        public String author { get; set; }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            xml_description = "<description> \n";
            xml_description += "<section caption = \"Guide\" >" + this.richTextBoxGuide.Text + "</section>";
            xml_description += "<section caption=\"Description\">" + this.richTextBoxDescription.Text + "</section>";
            xml_description += "</description>";

            name = this.textBoxName.Text;
            author = this.textBoxAuthor.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
