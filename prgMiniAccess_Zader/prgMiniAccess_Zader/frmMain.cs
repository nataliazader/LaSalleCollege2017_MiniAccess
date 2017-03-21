using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DAO;

namespace prgMiniAccess_Zader
{
    public partial class frmMain : Form
    {
        DBEngine dbe = new DBEngine();
        Database db;
        public frmMain()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Create a new database";
            saveFileDialog.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\App_Data";
            saveFileDialog.Filter = "Database files(*.accdb)|*.accdb";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                    File.Delete(saveFileDialog.FileName);
                db = dbe.CreateDatabase(saveFileDialog.FileName, LanguageConstants.dbLangGeneral);
                labelName.Text = Path.GetFileName(saveFileDialog.FileName);
                displayInfo();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open an existing database";
            openFileDialog.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\App_Data";
            openFileDialog.Filter = "Database files(*.accdb)|*.accdb";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                db = dbe.OpenDatabase(openFileDialog.FileName);
                labelName.Text = Path.GetFileName(openFileDialog.FileName);
                displayInfo();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if ((int)dialogResult == 6)
            {
                this.Close();
            }
        }

        private void displayInfo() {
            panelDatabase.Visible = tableToolStripMenuItem.Enabled = true;
            listBoxInfo.Items.Clear();
            listBoxInfo.Items.Add("Path : " + db.Name);
            listBoxInfo.Items.Add("Number of tables : " + db.TableDefs.Count);

            foreach (TableDef oneTable in db.TableDefs)
            {
                listBoxInfo.Items.Add("\tTable:" + oneTable.Name);
                foreach (Field field in oneTable.Fields)
                    listBoxInfo.Items.Add("\tField:" + field.Name);
                //foreach (Index inx in oneTable.Indexes)
                //    listBoxInfo.Items.Add("\tIndex:" + inx.Name);
            }

            foreach (Relation rel in db.Relations)
            {
                listBoxInfo.Items.Add("RElation Name:" + rel.Name);
                listBoxInfo.Items.Add("RElation Name:" + rel.Table);
                listBoxInfo.Items.Add("RElation Name:" + rel.ForeignTable);
                foreach (Field fd in rel.Fields)
                {
                    listBoxInfo.Items.Add("field:" + fd.Name);
                    listBoxInfo.Items.Add("field:" + fd.ForeignName);
                }
            }
        }
    }
}
