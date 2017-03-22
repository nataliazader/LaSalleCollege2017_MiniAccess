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
        public static Database db;
        public frmMain()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Title = "Create a new database";
            saveFD.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\App_Data";
            saveFD.Filter = "Database files(*.accdb)|*.accdb";
            saveFD.RestoreDirectory = true;

            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFD.FileName))
                    File.Delete(saveFD.FileName);
                db = dbe.CreateDatabase(saveFD.FileName, LanguageConstants.dbLangGeneral);
                labelName.Text = Path.GetFileName(saveFD.FileName);
                displayInfo();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Title = "Open an existing database";
            openFD.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\App_Data";
            openFD.Filter = "Database files(*.accdb)|*.accdb";
            openFD.FilterIndex = 2;
            openFD.RestoreDirectory = true;
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                db = dbe.OpenDatabase(openFD.FileName);
                labelName.Text = Path.GetFileName(openFD.FileName);
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
                    listBoxInfo.Items.Add("\t\tField:" + field.Name);
                //foreach (Index inx in oneTable.Indexes)
                //    listBoxInfo.Items.Add("\tIndex:" + inx.Name);
            }

            foreach (Relation rel in db.Relations)
            {
                listBoxInfo.Items.Add("Relation Name:" + rel.Name);
                listBoxInfo.Items.Add("Relation Table:" + rel.Table);
                listBoxInfo.Items.Add("Relation Foreign Table:" + rel.ForeignTable);
                foreach (Field fd in rel.Fields)
                {
                    listBoxInfo.Items.Add("field:" + fd.Name);
                    listBoxInfo.Items.Add("field:" + fd.ForeignName);
                }
            }
        }

        private void newTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelDatabase.Visible = false;
            frmNewTable frmNT = new frmNewTable();
            frmNT.Text = "Database : " + Path.GetFileName(db.Name) + " - Creating a new table";
            frmNT.MdiParent = this;
            frmNT.Show();
        }

    }
}
