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
    /// public class that represents the write form.
    /// </summary>
    public partial class WriteForm : Form
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public WriteForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// String that contains description in xml format.
        /// </summary>
        public String xml_description { get; set; }
        /// <summary>
        /// String that contains name of project.
        /// </summary>
        public String name { get; set; }
        /// <summary>
        /// String that contains name of author.
        /// </summary>
        public String author { get; set; }
        /// <summary>
        /// function reacts on write button click, creates the description and adds the values
        /// to the public Strings.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonWrite_Click(object sender, EventArgs e)
        {
            //create description
            xml_description = "<description> \n";
            xml_description += "<section caption = \"Guide\">" + this.richTextBoxGuide.Text + "</section>";
            xml_description += "<section caption=\"Description\">" + this.richTextBoxDescription.Text + "</section>";
            xml_description += "</description>";
            //add name and author
            name = this.textBoxName.Text;
            author = this.textBoxAuthor.Text;
            //send sucess result and close the form
            DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// function reacts to Cancle button click and closes the form with cancle message for parent.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
