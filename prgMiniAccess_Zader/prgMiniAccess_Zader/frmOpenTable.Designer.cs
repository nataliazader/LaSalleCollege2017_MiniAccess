namespace prgMiniAccess_Zader
{
    partial class frmOpenTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpenTable));
            this.listBoxTable = new System.Windows.Forms.ListBox();
            this.labelSelectTable = new System.Windows.Forms.Label();
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxTable
            // 
            this.listBoxTable.FormattingEnabled = true;
            this.listBoxTable.Location = new System.Drawing.Point(27, 49);
            this.listBoxTable.Name = "listBoxTable";
            this.listBoxTable.Size = new System.Drawing.Size(99, 316);
            this.listBoxTable.TabIndex = 0;
            this.listBoxTable.SelectedValueChanged += new System.EventHandler(this.listBoxTable_SelectedValueChanged);
            // 
            // labelSelectTable
            // 
            this.labelSelectTable.AutoSize = true;
            this.labelSelectTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectTable.Location = new System.Drawing.Point(24, 20);
            this.labelSelectTable.Name = "labelSelectTable";
            this.labelSelectTable.Size = new System.Drawing.Size(86, 13);
            this.labelSelectTable.TabIndex = 2;
            this.labelSelectTable.Text = "Select a table";
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Location = new System.Drawing.Point(161, 49);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.ReadOnly = true;
            this.dataGridViewTable.Size = new System.Drawing.Size(353, 316);
            this.dataGridViewTable.TabIndex = 3;
            // 
            // frmOpenTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 395);
            this.Controls.Add(this.dataGridViewTable);
            this.Controls.Add(this.labelSelectTable);
            this.Controls.Add(this.listBoxTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOpenTable";
            this.Text = "frmOpenTable";
            this.Load += new System.EventHandler(this.frmOpenTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTable;
        private System.Windows.Forms.Label labelSelectTable;
        private System.Windows.Forms.DataGridView dataGridViewTable;
    }
}