namespace prgMiniAccess_Zader
{
    partial class frmNewTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewTable));
            this.textBoxTableName = new System.Windows.Forms.TextBox();
            this.labelTableName = new System.Windows.Forms.Label();
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.ColumnTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIndex = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnAutoIncr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.richTextBoxErr = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTableName
            // 
            this.textBoxTableName.Location = new System.Drawing.Point(123, 9);
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(120, 20);
            this.textBoxTableName.TabIndex = 0;
            // 
            // labelTableName
            // 
            this.labelTableName.AutoSize = true;
            this.labelTableName.Location = new System.Drawing.Point(12, 9);
            this.labelTableName.Name = "labelTableName";
            this.labelTableName.Size = new System.Drawing.Size(105, 13);
            this.labelTableName.TabIndex = 1;
            this.labelTableName.Text = "Enter a table name : ";
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTableName,
            this.ColumnType,
            this.ColumnSize,
            this.ColumnIndex,
            this.ColumnAutoIncr});
            this.dataGridViewTable.Location = new System.Drawing.Point(0, 47);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.RowHeadersWidth = 20;
            this.dataGridViewTable.Size = new System.Drawing.Size(534, 256);
            this.dataGridViewTable.TabIndex = 2;
            // 
            // ColumnTableName
            // 
            this.ColumnTableName.HeaderText = "Name";
            this.ColumnTableName.Name = "ColumnTableName";
            this.ColumnTableName.Width = 120;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.Name = "ColumnType";
            // 
            // ColumnSize
            // 
            this.ColumnSize.HeaderText = "Size";
            this.ColumnSize.Name = "ColumnSize";
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.HeaderText = "Index";
            this.ColumnIndex.Name = "ColumnIndex";
            // 
            // ColumnAutoIncr
            // 
            this.ColumnAutoIncr.HeaderText = "AutoIncrement";
            this.ColumnAutoIncr.Name = "ColumnAutoIncr";
            this.ColumnAutoIncr.TrueValue = "T";
            this.ColumnAutoIncr.Width = 90;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(448, 319);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 29);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(448, 354);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 29);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // richTextBoxErr
            // 
            this.richTextBoxErr.ForeColor = System.Drawing.Color.Red;
            this.richTextBoxErr.Location = new System.Drawing.Point(15, 319);
            this.richTextBoxErr.Name = "richTextBoxErr";
            this.richTextBoxErr.Size = new System.Drawing.Size(418, 64);
            this.richTextBoxErr.TabIndex = 5;
            this.richTextBoxErr.Text = "";
            // 
            // frmNewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 395);
            this.Controls.Add(this.richTextBoxErr);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewTable);
            this.Controls.Add(this.labelTableName);
            this.Controls.Add(this.textBoxTableName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewTable";
            this.Text = "Mini Access - Creating a new table";
            this.Load += new System.EventHandler(this.frmNewTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTableName;
        private System.Windows.Forms.Label labelTableName;
        private System.Windows.Forms.DataGridView dataGridViewTable;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RichTextBox richTextBoxErr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTableName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnAutoIncr;
    }
}