namespace Cafun_XML_Gen
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxCells = new System.Windows.Forms.ListBox();
            this.labelCellList = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.labelmutations = new System.Windows.Forms.Label();
            this.listBoxConditions = new System.Windows.Forms.ListBox();
            this.labelConditions = new System.Windows.Forms.Label();
            this.buttonAddCell = new System.Windows.Forms.Button();
            this.buttonDeleteCell = new System.Windows.Forms.Button();
            this.buttonAddMut = new System.Windows.Forms.Button();
            this.buttonDeleteMut = new System.Windows.Forms.Button();
            this.buttonAddCon = new System.Windows.Forms.Button();
            this.buttonDeleteCon = new System.Windows.Forms.Button();
            this.buttonChangeCell = new System.Windows.Forms.Button();
            this.buttonChangeMut = new System.Windows.Forms.Button();
            this.buttonChangeCon = new System.Windows.Forms.Button();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxCells
            // 
            this.listBoxCells.FormattingEnabled = true;
            this.listBoxCells.Location = new System.Drawing.Point(12, 29);
            this.listBoxCells.Name = "listBoxCells";
            this.listBoxCells.Size = new System.Drawing.Size(315, 173);
            this.listBoxCells.TabIndex = 0;
            // 
            // labelCellList
            // 
            this.labelCellList.AutoSize = true;
            this.labelCellList.Location = new System.Drawing.Point(13, 13);
            this.labelCellList.Name = "labelCellList";
            this.labelCellList.Size = new System.Drawing.Size(29, 13);
            this.labelCellList.TabIndex = 1;
            this.labelCellList.Text = "Cells";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Mutations"});
            this.listBox1.Location = new System.Drawing.Point(356, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(316, 173);
            this.listBox1.TabIndex = 2;
            // 
            // labelmutations
            // 
            this.labelmutations.AutoSize = true;
            this.labelmutations.Location = new System.Drawing.Point(619, 9);
            this.labelmutations.Name = "labelmutations";
            this.labelmutations.Size = new System.Drawing.Size(53, 13);
            this.labelmutations.TabIndex = 3;
            this.labelmutations.Text = "Mutations";
            // 
            // listBoxConditions
            // 
            this.listBoxConditions.FormattingEnabled = true;
            this.listBoxConditions.Items.AddRange(new object[] {
            "Conditions"});
            this.listBoxConditions.Location = new System.Drawing.Point(12, 283);
            this.listBoxConditions.Name = "listBoxConditions";
            this.listBoxConditions.Size = new System.Drawing.Size(315, 199);
            this.listBoxConditions.TabIndex = 4;
            // 
            // labelConditions
            // 
            this.labelConditions.AutoSize = true;
            this.labelConditions.Location = new System.Drawing.Point(13, 267);
            this.labelConditions.Name = "labelConditions";
            this.labelConditions.Size = new System.Drawing.Size(56, 13);
            this.labelConditions.TabIndex = 5;
            this.labelConditions.Text = "Conditions";
            // 
            // buttonAddCell
            // 
            this.buttonAddCell.Location = new System.Drawing.Point(12, 208);
            this.buttonAddCell.Name = "buttonAddCell";
            this.buttonAddCell.Size = new System.Drawing.Size(100, 23);
            this.buttonAddCell.TabIndex = 6;
            this.buttonAddCell.Text = "Add Cell";
            this.buttonAddCell.UseVisualStyleBackColor = true;
            this.buttonAddCell.Click += new System.EventHandler(this.buttonAddCell_Click);
            // 
            // buttonDeleteCell
            // 
            this.buttonDeleteCell.Location = new System.Drawing.Point(227, 208);
            this.buttonDeleteCell.Name = "buttonDeleteCell";
            this.buttonDeleteCell.Size = new System.Drawing.Size(100, 23);
            this.buttonDeleteCell.TabIndex = 7;
            this.buttonDeleteCell.Text = "Delete Cell";
            this.buttonDeleteCell.UseVisualStyleBackColor = true;
            this.buttonDeleteCell.Click += new System.EventHandler(this.buttonDeleteCell_Click);
            // 
            // buttonAddMut
            // 
            this.buttonAddMut.Location = new System.Drawing.Point(356, 209);
            this.buttonAddMut.Name = "buttonAddMut";
            this.buttonAddMut.Size = new System.Drawing.Size(100, 23);
            this.buttonAddMut.TabIndex = 8;
            this.buttonAddMut.Text = "Add Mutation";
            this.buttonAddMut.UseVisualStyleBackColor = true;
            this.buttonAddMut.Click += new System.EventHandler(this.buttonAddMut_Click);
            // 
            // buttonDeleteMut
            // 
            this.buttonDeleteMut.Location = new System.Drawing.Point(572, 209);
            this.buttonDeleteMut.Name = "buttonDeleteMut";
            this.buttonDeleteMut.Size = new System.Drawing.Size(100, 23);
            this.buttonDeleteMut.TabIndex = 9;
            this.buttonDeleteMut.Text = "Delete Mutation";
            this.buttonDeleteMut.UseVisualStyleBackColor = true;
            // 
            // buttonAddCon
            // 
            this.buttonAddCon.Location = new System.Drawing.Point(333, 283);
            this.buttonAddCon.Name = "buttonAddCon";
            this.buttonAddCon.Size = new System.Drawing.Size(100, 23);
            this.buttonAddCon.TabIndex = 10;
            this.buttonAddCon.Text = "Add Condition";
            this.buttonAddCon.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteCon
            // 
            this.buttonDeleteCon.Location = new System.Drawing.Point(333, 459);
            this.buttonDeleteCon.Name = "buttonDeleteCon";
            this.buttonDeleteCon.Size = new System.Drawing.Size(100, 23);
            this.buttonDeleteCon.TabIndex = 11;
            this.buttonDeleteCon.Text = "Delete Condition";
            this.buttonDeleteCon.UseVisualStyleBackColor = true;
            // 
            // buttonChangeCell
            // 
            this.buttonChangeCell.Location = new System.Drawing.Point(121, 208);
            this.buttonChangeCell.Name = "buttonChangeCell";
            this.buttonChangeCell.Size = new System.Drawing.Size(100, 23);
            this.buttonChangeCell.TabIndex = 12;
            this.buttonChangeCell.Text = "Change Cell";
            this.buttonChangeCell.UseVisualStyleBackColor = true;
            // 
            // buttonChangeMut
            // 
            this.buttonChangeMut.Location = new System.Drawing.Point(462, 208);
            this.buttonChangeMut.Name = "buttonChangeMut";
            this.buttonChangeMut.Size = new System.Drawing.Size(100, 23);
            this.buttonChangeMut.TabIndex = 13;
            this.buttonChangeMut.Text = "Change Mutation";
            this.buttonChangeMut.UseVisualStyleBackColor = true;
            // 
            // buttonChangeCon
            // 
            this.buttonChangeCon.Location = new System.Drawing.Point(333, 369);
            this.buttonChangeCon.Name = "buttonChangeCon";
            this.buttonChangeCon.Size = new System.Drawing.Size(100, 23);
            this.buttonChangeCon.TabIndex = 14;
            this.buttonChangeCon.Text = "Change Condition";
            this.buttonChangeCon.UseVisualStyleBackColor = true;
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(597, 456);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(75, 23);
            this.buttonWrite.TabIndex = 15;
            this.buttonWrite.Text = "Write";
            this.buttonWrite.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 491);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.buttonChangeCon);
            this.Controls.Add(this.buttonChangeMut);
            this.Controls.Add(this.buttonChangeCell);
            this.Controls.Add(this.buttonDeleteCon);
            this.Controls.Add(this.buttonAddCon);
            this.Controls.Add(this.buttonDeleteMut);
            this.Controls.Add(this.buttonAddMut);
            this.Controls.Add(this.buttonDeleteCell);
            this.Controls.Add(this.buttonAddCell);
            this.Controls.Add(this.labelConditions);
            this.Controls.Add(this.listBoxConditions);
            this.Controls.Add(this.labelmutations);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.labelCellList);
            this.Controls.Add(this.listBoxCells);
            this.MinimumSize = new System.Drawing.Size(700, 530);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Cafun XML Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCells;
        private System.Windows.Forms.Label labelCellList;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label labelmutations;
        private System.Windows.Forms.ListBox listBoxConditions;
        private System.Windows.Forms.Label labelConditions;
        private System.Windows.Forms.Button buttonAddCell;
        private System.Windows.Forms.Button buttonDeleteCell;
        private System.Windows.Forms.Button buttonAddMut;
        private System.Windows.Forms.Button buttonDeleteMut;
        private System.Windows.Forms.Button buttonAddCon;
        private System.Windows.Forms.Button buttonDeleteCon;
        private System.Windows.Forms.Button buttonChangeCell;
        private System.Windows.Forms.Button buttonChangeMut;
        private System.Windows.Forms.Button buttonChangeCon;
        private System.Windows.Forms.Button buttonWrite;
    }
}

