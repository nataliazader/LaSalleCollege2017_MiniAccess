using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace prgMiniAccess_Zader
{
    class Validation
    {
        public static bool isValidName(string name)
        {
            Match match = Regex.Match(name, @"([A-Za-z]+)$", RegexOptions.IgnoreCase);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static bool isValidSize(string size)
        {
            Match match = Regex.Match(size, @"([0-9]+)$", RegexOptions.IgnoreCase);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static string isValidFields(DataGridView dgv)
        {
            string err = "";
            int index = 0;
            List<string> columnTableNames = new List<string>();

            foreach (DataGridViewRow row in dgv.Rows)
                if (row.Index != dgv.RowCount - 1)
                {
                    string errMessage = "";
                    index = row.Index;
                    if (dgv.Rows[index].Cells["ColumnTableName"].Value == null || !Validation.isValidName(dgv.Rows[index].Cells["ColumnTableName"].Value.ToString()))
                        errMessage += "Column name contains only letters.\n";
                    else
                        columnTableNames.Add(dgv.Rows[index].Cells["ColumnTableName"].Value.ToString());
                    if (dgv.Rows[index].Cells["ColumnType"].Value == null || dgv.Rows[index].Cells["ColumnType"].Value.ToString() == "")
                        errMessage += "Select type.\n";
                    if ((dgv.Rows[index].Cells["ColumnType"].Value == null || dgv.Rows[index].Cells["ColumnType"].Value.ToString() == "LONG" || dgv.Rows[index].Cells["ColumnType"].Value.ToString() == "DOUBLE" || dgv.Rows[index].Cells["ColumnType"].Value.ToString() == "TEXT") && (dgv.Rows[index].Cells["ColumnSize"].Value == null || !isValidSize(dgv.Rows[index].Cells["ColumnSize"].Value.ToString())))
                        errMessage += "Enter size\n";
                    if (dgv.Rows[index].Cells["ColumnAutoIncr"].Value != null && dgv.Rows[index].Cells["ColumnAutoIncr"].Value.ToString() == "T" && dgv.Rows[index].Cells["ColumnType"].Value.ToString() != "LONG")
                        errMessage += "Auto Increment only for Long type\n";
                    if (errMessage != "")
                        err += "Row " + (index + 1).ToString() + " : \n" + errMessage;
                }

            if (columnTableNames.Count != columnTableNames.Distinct().Count())
                err = "A table can not contain columns with the same name.\n" + err;
                return err;
        }
    }
}
