namespace prgMiniAccess_Zader
{
    partial class frmNewRelation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewRelation));
            this.comboBoxTable1 = new System.Windows.Forms.ComboBox();
            this.comboBoxTable2 = new System.Windows.Forms.ComboBox();
            this.listBoxTable1 = new System.Windows.Forms.ListBox();
            this.listBoxTable2 = new System.Windows.Forms.ListBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelSelectTables = new System.Windows.Forms.Label();
            this.labelFields = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxTable1
            // 
            this.comboBoxTable1.FormattingEnabled = true;
            this.comboBoxTable1.Location = new System.Drawing.Point(125, 42);
            this.comboBoxTable1.Name = "comboBoxTable1";
            this.comboBoxTable1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTable1.TabIndex = 0;
            this.comboBoxTable1.SelectedValueChanged += new System.EventHandler(this.comboBoxTable1_SelectedValueChanged);
            // 
            // comboBoxTable2
            // 
            this.comboBoxTable2.FormattingEnabled = true;
            this.comboBoxTable2.Location = new System.Drawing.Point(269, 42);
            this.comboBoxTable2.Name = "comboBoxTable2";
            this.comboBoxTable2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTable2.TabIndex = 1;
            this.comboBoxTable2.SelectedIndexChanged += new System.EventHandler(this.comboBoxTable2_SelectedIndexChanged);
            // 
            // listBoxTable1
            // 
            this.listBoxTable1.FormattingEnabled = true;
            this.listBoxTable1.Location = new System.Drawing.Point(73, 159);
            this.listBoxTable1.Name = "listBoxTable1";
            this.listBoxTable1.Size = new System.Drawing.Size(120, 186);
            this.listBoxTable1.TabIndex = 2;
            // 
            // listBoxTable2
            // 
            this.listBoxTable2.FormattingEnabled = true;
            this.listBoxTable2.Location = new System.Drawing.Point(330, 159);
            this.listBoxTable2.Name = "listBoxTable2";
            this.listBoxTable2.Size = new System.Drawing.Size(120, 186);
            this.listBoxTable2.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(214, 102);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(220, 75);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(94, 13);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Enter a name : ";
            // 
            // labelSelectTables
            // 
            this.labelSelectTables.AutoSize = true;
            this.labelSelectTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectTables.Location = new System.Drawing.Point(220, 9);
            this.labelSelectTables.Name = "labelSelectTables";
            this.labelSelectTables.Size = new System.Drawing.Size(89, 13);
            this.labelSelectTables.TabIndex = 7;
            this.labelSelectTables.Text = "Select tables :";
            // 
            // labelFields
            // 
            this.labelFields.AutoSize = true;
            this.labelFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFields.Location = new System.Drawing.Point(220, 159);
            this.labelFields.Name = "labelFields";
            this.labelFields.Size = new System.Drawing.Size(95, 13);
            this.labelFields.TabIndex = 8;
            this.labelFields.Text = "Choose fields : ";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.Location = new System.Drawing.Point(171, 360);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 9;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(269, 360);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // frmNewRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 395);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.labelFields);
            this.Controls.Add(this.labelSelectTables);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.listBoxTable2);
            this.Controls.Add(this.listBoxTable1);
            this.Controls.Add(this.comboBoxTable2);
            this.Controls.Add(this.comboBoxTable1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewRelation";
            this.Text = "Mini Access - Creating a new relation";
            this.Load += new System.EventHandler(this.frmNewRelation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTable1;
        private System.Windows.Forms.ComboBox comboBoxTable2;
        private System.Windows.Forms.ListBox listBoxTable1;
        private System.Windows.Forms.ListBox listBoxTable2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSelectTables;
        private System.Windows.Forms.Label labelFields;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCancel;
    }
}