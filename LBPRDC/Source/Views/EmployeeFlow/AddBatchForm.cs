using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace LBPRDC.Source.Views
{
    public partial class frmAddBatchEmployees : Form
    {
        public frmAddBatchEmployees(string filePath)
        {
            InitializeComponent();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            if (filePath != null)
            {
                LoadDataIntoDataGridView(filePath);
            }
        }

        private void LoadDataIntoDataGridView(string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var dataTable = new DataTable();

                lblFilePath.Text = $"File path: {filePath}";
                lblRowCount.Text = $"Total row count: {(worksheet.Dimension.End.Row - 1).ToString()}"; // Get total row count excluding row 1 'Column Names'

                for (int colIndex = worksheet.Dimension.Start.Column; colIndex <= worksheet.Dimension.End.Column; colIndex++)
                {
                    string colName = worksheet.Cells[1, colIndex].Text;
                    dataTable.Columns.Add(colName, typeof(string));
                }

                for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                {
                    bool isRowEmpty = true;
                    DataRow dataRow = dataTable.NewRow();

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        string colName = column.ColumnName;
                        int colIndex = -1;

                        for (int i = worksheet.Dimension.Start.Column; i <= worksheet.Dimension.End.Column; i++)
                        {
                            if (worksheet.Cells[1, i].Text == colName)
                            {
                                colIndex = i;
                                break;
                            }
                        }

                        if (colIndex != -1)
                        {
                            var cell = worksheet.Cells[row, colIndex];
                            dataRow[colName] = cell.Text;

                            if (!string.IsNullOrEmpty(cell.Text))
                            {
                                isRowEmpty = false;
                            }
                        }
                    }

                    if (!isRowEmpty)
                    {
                        dataTable.Rows.Add(dataRow);
                    }
                }

                dgvRawData.DataSource = dataTable;
            }
        }
    }
}
