using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace prgMiniAccess_Zader
{
    public partial class frmOpenTable : Form
    {
        public frmOpenTable()
        {
            InitializeComponent();
        }

        private void frmOpenTable_Load(object sender, EventArgs e)
        {
            foreach (string tName in frmMain.tableNames)
            {
                listBoxTable.Items.Add(tName);
            }

            listBoxTable.SelectedIndex = 0;
            Recordset rec = frmMain.db.OpenRecordset(listBoxTable.SelectedItem.ToString());
            displayRecords(dataGridViewTable, rec);
        }

        private void displayRecords(DataGridView dgv,Recordset rec) {
            dgv.Columns.Clear();
            int rowIndex = 0;
            foreach (Field fd in rec.Fields)
                dgv.Columns.Add("column" + fd.Name, fd.Name);
            while (!rec.EOF) {
                dgv.Rows.Add();             
                foreach (Field fd in rec.Fields) {
                    dgv.Rows[rowIndex].Cells["column"+fd.Name].Value = rec.Fields[fd.Name].Value;
                }
                rowIndex++;
                rec.MoveNext();
            }
        }

        private void listBoxTable_SelectedValueChanged(object sender, EventArgs e)
        {
            Recordset rec = frmMain.db.OpenRecordset(listBoxTable.SelectedItem.ToString());
            displayRecords(dataGridViewTable, rec);
        }
    }
}
