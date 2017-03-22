using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
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
            string[] colType = {"LONG","FLOAT", "TEXT","DATE/TIME" };
            foreach(string str in colType)
                ColumnType.Items.Add(str);
            string[] colIndex = { "PRIMARY", "UNIQUE" };
            foreach (string str in colIndex)
                ColumnIndex.Items.Add(str);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!isValidName(textBoxTableName.Text))
                MessageBox.Show("Table name contains only letters");
            else
            {
                table = frmMain.db.CreateTableDef(textBoxTableName.Text);
                if (dataGridViewTable.RowCount > 1)
                {
                    if (isValidFields(dataGridViewTable) == "")
                    {
                        createTable(dataGridViewTable);
                        this.Close();
                    }
                    else
                        richTextBoxErr.Text = isValidFields(dataGridViewTable);
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

        private bool isValidName(string name)
        {
            Match match = Regex.Match(name, @"([A-Za-z]+)$", RegexOptions.IgnoreCase);
            if (match.Success)
                return true;
            else
                return false;
        }

        private bool isValidSize(string size)
        {
            Match match = Regex.Match(size, @"([0-9]+)$", RegexOptions.IgnoreCase);
            if (match.Success)
                return true;
            else
                return false;
        }

        private string isValidFields(DataGridView dgv)
        {
            string err = "";
            int index = 0;
            foreach (DataGridViewRow row in dgv.Rows)
                if (row.Index != dataGridViewTable.RowCount - 1)
                {
                    string errMessage = "";
                    index = row.Index;
                    if (dgv.Rows[index].Cells["ColumnTableName"].Value == null || !isValidName(dgv.Rows[index].Cells[0].Value.ToString()))
                        errMessage += "Table name contains only letters.\n";
                    if (dgv.Rows[index].Cells["ColumnType"].Value == null || dgv.Rows[index].Cells["ColumnType"].Value.ToString() == "")
                        errMessage += "Select type.\n";
                    if ((dgv.Rows[index].Cells["ColumnType"].Value == null || dgv.Rows[index].Cells["ColumnType"].Value.ToString() == "LONG" || dgv.Rows[index].Cells["ColumnType"].Value.ToString() == "FLOAT" || dgv.Rows[index].Cells["ColumnType"].Value.ToString() == "TEXT")&& (dgv.Rows[index].Cells["ColumnSize"].Value == null || !isValidSize(dgv.Rows[index].Cells["ColumnSize"].Value.ToString())))
                        errMessage += "Enter size\n";
                    if(dgv.Rows[index].Cells["ColumnAutoIncr"].Value != null && dgv.Rows[index].Cells["ColumnAutoIncr"].Value.ToString() == "T" && dgv.Rows[index].Cells["ColumnType"].Value.ToString() != "LONG")
                        errMessage += "Auto Increment only for Long type\n";
                    if (errMessage != "")
                        err += "Row " + (index+1).ToString()+ " : \n" + errMessage;
                }
            return err;
        }

        private void createTable(DataGridView dgv) {
            foreach (DataGridViewRow row in dgv.Rows)
                if (row.Index != dataGridViewTable.RowCount - 1)
                {
                    createField(dgv, row.Index);
                }
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

            else if (dgv.Rows[indexRow].Cells["ColumnType"].Value.ToString() == "FLOAT")
            {
                size = Convert.ToInt16(dgv.Rows[indexRow].Cells["ColumnSize"].Value.ToString());
                field = table.CreateField(name, DAO.DataTypeEnum.dbFloat, size);
            }

            else if (dgv.Rows[indexRow].Cells["ColumnType"].Value.ToString() == "TEXT")
            {
                size = Convert.ToInt16(dgv.Rows[indexRow].Cells["ColumnSize"].Value.ToString());
                field = table.CreateField(name, DAO.DataTypeEnum.dbText, size);
            }
            else
            {
                size = Convert.ToInt16(dgv.Rows[indexRow].Cells["ColumnSize"].Value.ToString());
                field = table.CreateField(name, DAO.DataTypeEnum.dbDate);
            }

            table.Fields.Append(field);

            if (dgv.Rows[indexRow].Cells["ColumnIndex"].Value != null && dgv.Rows[indexRow].Cells["ColumnIndex"].Value.ToString() == "PRIMARY")
            {
                Index index = table.CreateIndex("Primary key");
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

            
            frmMain.db.TableDefs.Append(table);
        }
    }
}
