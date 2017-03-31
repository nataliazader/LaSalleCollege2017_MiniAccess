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
    public partial class frmNewTable : Form
    {
        TableDef table;
        
        public frmNewTable()
        {
            InitializeComponent();
        }

        private void frmNewTable_Load(object sender, EventArgs e)
        {
            string[] colType = {"LONG", "DOUBLE", "TEXT","DATE/TIME" };
            foreach(string str in colType)
                ColumnType.Items.Add(str);
            string[] colIndex = { "PRIMARY", "UNIQUE","INDEX" };
            foreach (string str in colIndex)
                ColumnIndex.Items.Add(str);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            richTextBoxErr.Text = "";

            if (!Validation.isValidName(textBoxTableName.Text))
                richTextBoxErr.Text = "Table name can contain only letters.\n";
            if (frmMain.tableNames.Contains(textBoxTableName.Text))
                richTextBoxErr.Text = "Database already contains a table with the same \n";
            else
            {
                table = frmMain.db.CreateTableDef(textBoxTableName.Text);
                if (dataGridViewTable.RowCount > 1)
                {
                    if (Validation.isValidFields(dataGridViewTable) == "")
                    {
                        createTable(dataGridViewTable);
                        MessageBox.Show("Table : " + textBoxTableName.Text + " successfully created.");
                        this.Close();
                    }
                    else
                        richTextBoxErr.Text += Validation.isValidFields(dataGridViewTable);
                }
                else {
                    richTextBoxErr.Text += "Enter a fields";
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

        private void createTable(DataGridView dgv) {
            foreach (DataGridViewRow row in dgv.Rows)
                if (row.Index != dgv.RowCount - 1)
                {
                    createField(dgv, row.Index);
                }
            frmMain.db.TableDefs.Append(table);
        }

        private void createField(DataGridView dgv,int indexRow) {
            string name;
            name = dgv.Rows[indexRow].Cells["ColumnTableName"].Value.ToString();
            int size;
            Field field = new Field();
            if (dgv.Rows[indexRow].Cells["ColumnType"].Value.ToString() == "LONG")
            {
                size = Convert.ToInt16(dgv.Rows[indexRow].Cells["ColumnSize"].Value.ToString());
                field = table.CreateField(name, DAO.DataTypeEnum.dbLong, size);
                if (dgv.Rows[indexRow].Cells["ColumnAutoIncr"].Value != null && dgv.Rows[indexRow].Cells["ColumnAutoIncr"].Value.ToString() == "T")
                {
                    field.Attributes = (int)DAO.FieldAttributeEnum.dbAutoIncrField;
                }
            }

            else if (dgv.Rows[indexRow].Cells["ColumnType"].Value.ToString() == "DOUBLE")
            {
                size = Convert.ToInt16(dgv.Rows[indexRow].Cells["ColumnSize"].Value.ToString());
                field = table.CreateField(name, DAO.DataTypeEnum.dbDouble,size);
            }

            else if (dgv.Rows[indexRow].Cells["ColumnType"].Value.ToString() == "TEXT")
            {
                size = Convert.ToInt16(dgv.Rows[indexRow].Cells["ColumnSize"].Value.ToString());
                field = table.CreateField(name, DAO.DataTypeEnum.dbText, size);
            }
            else
            {
                field = table.CreateField(name, DAO.DataTypeEnum.dbDate);
            }

            table.Fields.Append(field);

            if (dgv.Rows[indexRow].Cells["ColumnIndex"].Value != null && dgv.Rows[indexRow].Cells["ColumnIndex"].Value.ToString() == "PRIMARY")
            {
                Index index = table.CreateIndex("Primary key" + name);
                field = index.CreateField(name);
                index.Primary = true;
                index.Required = true;
                index.IgnoreNulls = false;
                ((IndexFields)index.Fields).Append(field);
                table.Indexes.Append(index);
            }

            else if (dgv.Rows[indexRow].Cells["ColumnIndex"].Value != null && dgv.Rows[indexRow].Cells["ColumnIndex"].Value.ToString() == "UNIQUE")
            {
                Index index = table.CreateIndex("Unique");
                field = index.CreateField(name);
                index.Required = true;
                index.Unique = true;
                index.IgnoreNulls = false;
                ((IndexFields)index.Fields).Append(field);
                table.Indexes.Append(index);
            }
            else if (dgv.Rows[indexRow].Cells["ColumnIndex"].Value != null && dgv.Rows[indexRow].Cells["ColumnIndex"].Value.ToString() == "INDEX")
            {
                Index index = table.CreateIndex("Index" + name);
                field = index.CreateField(name);
                index.Required = true;
                index.Unique = true;
                index.IgnoreNulls = false;
                ((IndexFields)index.Fields).Append(field);
                table.Indexes.Append(index);
            }
        }

    }
}
