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
        public static List<string> tableNames= new List<string>();
        bool status = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (status)
                db.Close();
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Title = "Create a new database";
            saveFD.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\App_Data";
            saveFD.Filter = "Database files(*.accdb)|*.accdb";
            saveFD.RestoreDirectory = true;

            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFD.FileName))
                {
                    File.Delete(saveFD.FileName);
                }

                db = dbe.CreateDatabase(saveFD.FileName, LanguageConstants.dbLangGeneral);
                labelName.Text = Path.GetFileName(saveFD.FileName);
                displayInfo();
                status = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (status)
                db.Close();
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
                status = true;
            }
        }

        private void displayInfo() {
            panelDatabase.Visible = tableToolStripMenuItem.Enabled = relationToolStripMenuItem.Enabled =true;
            listBoxInfo.Items.Clear();
            listBoxInfo.Items.Add("Path : " + db.Name);
            listBoxInfo.Items.Add("Number of tables : " + db.TableDefs.Count);
            tableNames.Clear();
            foreach (TableDef oneTable in db.TableDefs)
            {
                if (oneTable.Attributes == 0)
                {
                    tableNames.Add(oneTable.Name);
                    listBoxInfo.Items.Add("\tTable:" + oneTable.Name);
                    foreach (Field field in oneTable.Fields)
                        listBoxInfo.Items.Add("\t\tField:" + field.Name);
                    foreach (Index inx in oneTable.Indexes)
                        listBoxInfo.Items.Add("\t\t\tIndex:" + inx.Name);
                }
            }

            foreach (Relation rel in db.Relations)
            {
                if (rel.Attributes == 0)
                {
                    listBoxInfo.Items.Add("\tRelation Name:" + rel.Name);
                    listBoxInfo.Items.Add("\t\tRelation Table:" + rel.Table);
                    listBoxInfo.Items.Add("\t\tRelation Foreign Table:" + rel.ForeignTable);
                    foreach (Field fd in rel.Fields)
                    {
                        listBoxInfo.Items.Add("\t\t\tField:" + fd.Name);
                        listBoxInfo.Items.Add("\t\t\tField:" + fd.ForeignName);
                    }
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

        private void openTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tableNames.Count == 0)
                MessageBox.Show("Database : " + Path.GetFileName(db.Name) + " does not contain tables.\n");
            else {
                panelDatabase.Visible = false;
                frmOpenTable frmOT = new frmOpenTable();
                frmOT.Text = "Database : " + Path.GetFileName(db.Name) + " - Opening tables";
                frmOT.MdiParent = this;
                frmOT.Show();
            }
        }    

        private void newRelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelDatabase.Visible = false;
            frmNewRelation frmNR = new frmNewRelation();
            frmNR.Text = "Database : " + Path.GetFileName(db.Name) + " - Creating a new relation";
            frmNR.MdiParent = this;
            frmNR.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (status)
                displayInfo();
            else
                MessageBox.Show("Open a database.");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if ((int)dialogResult == 6)
            {
                db.Close();
                this.Close();
            }
        }
    }
}
