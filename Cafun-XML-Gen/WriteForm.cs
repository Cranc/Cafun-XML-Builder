using System;
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
            this.toolTipName.SetToolTip(this.labelName, "Defines the name of the file and the name of the simulation.");
            this.toolTipGuide.SetToolTip(this.labelGuide, "Defines the information displayed in the guide of the simulation.");
            this.toolTipDesciption.SetToolTip(this.labelDescription, "Defines the description of the simulation");
            this.toolTipAuthor.SetToolTip(this.labelAuthor, "Defines the name of the author displayed in the simulation");
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
