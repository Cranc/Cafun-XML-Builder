namespace Cafun_XML_Gen
{
    partial class CellForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxColorRed = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.textBoxColorGreen = new System.Windows.Forms.TextBox();
            this.textBoxColorBlue = new System.Windows.Forms.TextBox();
            this.lableError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(92, 15);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxColorRed
            // 
            this.textBoxColorRed.Location = new System.Drawing.Point(92, 38);
            this.textBoxColorRed.Name = "textBoxColorRed";
            this.textBoxColorRed.Size = new System.Drawing.Size(57, 20);
            this.textBoxColorRed.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 78);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(172, 78);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Name:";
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(12, 41);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(34, 13);
            this.labelColor.TabIndex = 6;
            this.labelColor.Text = "Color:";
            // 
            // textBoxColorGreen
            // 
            this.textBoxColorGreen.Location = new System.Drawing.Point(154, 38);
            this.textBoxColorGreen.Name = "textBoxColorGreen";
            this.textBoxColorGreen.Size = new System.Drawing.Size(57, 20);
            this.textBoxColorGreen.TabIndex = 7;
            // 
            // textBoxColorBlue
            // 
            this.textBoxColorBlue.Location = new System.Drawing.Point(215, 38);
            this.textBoxColorBlue.Name = "textBoxColorBlue";
            this.textBoxColorBlue.Size = new System.Drawing.Size(57, 20);
            this.textBoxColorBlue.TabIndex = 8;
            // 
            // lableError
            // 
            this.lableError.AutoSize = true;
            this.lableError.Location = new System.Drawing.Point(12, 62);
            this.lableError.Name = "lableError";
            this.lableError.Size = new System.Drawing.Size(0, 13);
            this.lableError.TabIndex = 9;
            // 
            // CellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 113);
            this.Controls.Add(this.lableError);
            this.Controls.Add(this.textBoxColorBlue);
            this.Controls.Add(this.textBoxColorGreen);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxColorRed);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CellForm";
            this.Text = "Add Cell";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxColorRed;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.TextBox textBoxColorGreen;
        private System.Windows.Forms.TextBox textBoxColorBlue;
        private System.Windows.Forms.Label lableError;
    }
}