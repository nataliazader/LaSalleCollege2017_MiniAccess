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
    public partial class frmNewRelation : Form
    {
        Recordset recordSet;
        public frmNewRelation()
        {
            InitializeComponent();
        }


        private void frmNewRelation_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (TableDef oneTable in frmMain.db.TableDefs)
            {
                if (oneTable.Attributes == 0)
                {
                    i++;
                    comboBoxTable1.Items.Add(oneTable.Name);
                    comboBoxTable2.Items.Add(oneTable.Name);
                }
            }
            if (i == 0)
                MessageBox.Show("There are no tables in the database.");
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            bool exist = false;
            if (comboBoxTable1.Text == "" || comboBoxTable2.Text == "")
                MessageBox.Show("Select tables .");
            else if (comboBoxTable1.Text == comboBoxTable2.Text)
                MessageBox.Show("You have to select different tables.");
            else if (textBoxName.Text == "")
                MessageBox.Show("Enter a name for a relation.");
            else if (listBoxTable1.SelectedItems.Count != 1 || listBoxTable2.SelectedItems.Count != 1)
                MessageBox.Show("Select a field for a relation.");
            else if (frmMain.db.TableDefs[comboBoxTable1.Text].Fields[listBoxTable1.SelectedItem.ToString()].Type != frmMain.db.TableDefs[comboBoxTable2.Text].Fields[listBoxTable2.SelectedItem.ToString()].Type)
                MessageBox.Show("Fields must be same type.");
            else {
                foreach (Relation rl in frmMain.db.Relations)
                    if (rl.Name == textBoxName.Text)
                    {
                        MessageBox.Show("Relation : " + rl.Name + " is already exist.");
                        exist = true;
                    }                      
                    if(!exist)
                    {
                        Relation rel = frmMain.db.CreateRelation();
                        rel.Name = textBoxName.Text;
                        rel.Table = comboBoxTable1.Text;
                        rel.ForeignTable = comboBoxTable2.Text;
                        Field fd = rel.CreateField();
                        fd.Name = listBoxTable1.SelectedItem.ToString();
                        fd.ForeignName = listBoxTable2.SelectedItem.ToString();
                        rel.Fields.Append(fd);                       
                        frmMain.db.Relations.Append(rel);
                        MessageBox.Show("Relation : " + rel.Name + " successfully created.");
                        this.Close();
                    }
            }
        }
 


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Do you really want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if ((int)dialogResult == 6)
            {
                this.Close();
            }
        }

        private void comboBoxTable1_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxTable1.Items.Clear();
            recordSet = frmMain.db.OpenTable(comboBoxTable1.Text);
            foreach (Field field in recordSet.Fields)
                listBoxTable1.Items.Add(field.Name);
            recordSet.Close();
        }

        private void comboBoxTable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxTable2.Items.Clear();
            recordSet = frmMain.db.OpenTable(comboBoxTable2.Text);
            foreach (Field field in recordSet.Fields)
                listBoxTable2.Items.Add(field.Name);
            recordSet.Close();
        }
    }
}
